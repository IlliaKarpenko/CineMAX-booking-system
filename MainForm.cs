using MetroFramework.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static Project1.Form1;
using AlignObjectsLib;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;
using ZXing;
using System.IO;
using System.Drawing.Imaging;

namespace Project1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        MySqlDataAdapter dtA;
        DataTable dtTb;
        bool f = true;
        DateTime PremiereDate;
        int duration;
        int Movie_id; //selected movie id
        TimeSpan Hours = new TimeSpan(10, 0, 0);
        TimeSpan EndHours = new TimeSpan(22, 0, 0);

        //for auto-align function
        List<Control> Chart = new List<Control>(1);

        //2D array to store seats numbers;
        char[,] SelectedSeat = new char[10, 14]; //f-vacant //t-selected //s-sold

        public void ClearArray()
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 14; j++)
                    SelectedSeat[i, j] = 'f';
        }

        //close window
        private void loginCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Width = 1000;
            this.Height = 650;
            //Вікно акаунта відкривається першим при запуску
            LoadAccountInfo();
            LoadFilms(MovieComboBox);
            //for auto-align function
            Chart.Add(SeatingChart);
            MyAlign.CenterControlsAsGroup(Chart, MyAlign.Direction.Both);
            if (user.Position == "касир")
            {
                metroTabControl1.HideTab(AddMovieTabPage);
                metroTabControl1.HideTab(NewSessionTabPage);
            }
        }

        //encode reservation id
        public string Base64Encode(int Reservation_id)
        {
            string id = Reservation_id.ToString();
            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(id);
            return System.Convert.ToBase64String(data);
        }

        //decode reservation id
        public int Base64Decode(string code)
        {
            try
            {
                byte[] data = System.Convert.FromBase64String(code);
                return Convert.ToInt32(System.Text.ASCIIEncoding.ASCII.GetString(data));
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Помилка!");
                return 0;
            }
        }

        //get hall id
        public int GetHallOrPrice(bool a) //pass 1 - to get selected hall_id.
        {
            try
            {
                //                             pass 0 - to get price for a ticket in selected hall
                MySqlConnectionStringBuilder mysqlCSB = new MySqlConnectionStringBuilder();
                mysqlCSB = new MySqlConnectionStringBuilder();
                mysqlCSB.Server = Data.Server;
                mysqlCSB.Database = Data.Database;
                mysqlCSB.UserID = Data.User;
                mysqlCSB.Password = Data.Password;

                string queryString = @"SELECT id, price FROM Hall WHERE name='" + SessionHallList.SelectedItem + "'";
                MySqlConnection connection = new MySqlConnection();
                connection.ConnectionString = mysqlCSB.ConnectionString;
                connection.Open();
                dtA = new MySqlDataAdapter(queryString, connection);
                dtTb = new DataTable();
                dtA.Fill(dtTb);
                connection.Close();
                if (a)
                    return Convert.ToInt32(dtTb.Rows[0]["id"].ToString());
                else
                    return Convert.ToInt32(dtTb.Rows[0]["price"].ToString());
            }
            catch (MySqlException)
            {
                MessageBox.Show("Помилка з'єднання!");
                return 0;
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Спочатку оберіть сеанс!");
                return 0;
            }
        }

        //get session id
        public int GetSessionID(DateTime date, string time, int Hall_id, int Movie_id)
        {
            MySqlConnectionStringBuilder mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = Data.Server;
            mysqlCSB.Database = Data.Database;
            mysqlCSB.UserID = Data.User;
            mysqlCSB.Password = Data.Password;

            string queryString = @"SELECT id FROM Session WHERE date='" + date.ToString("yyyy-MM-dd") +
            "' AND time='" + time + ":00' AND Cinema_id='" + user.CinemaID + "' AND Hall_id='" + Hall_id +
            "' AND Movie_id='" + Movie_id + "'";
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = mysqlCSB.ConnectionString;
            connection.Open();
            dtA = new MySqlDataAdapter(queryString, connection);
            dtTb = new DataTable();
            dtA.Fill(dtTb);
            connection.Close();

            return Convert.ToInt32(dtTb.Rows[0]["id"].ToString());
        }

        public int GetReservationID(int Session_id, int TableRow, int TableSeat) //seat # count from 1!!!
        {
            //!!!!!!!TableRow and Table seat number starts from 1 and shows actual seat!!!
            MySqlConnectionStringBuilder mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = Data.Server;
            mysqlCSB.Database = Data.Database;
            mysqlCSB.UserID = Data.User;
            mysqlCSB.Password = Data.Password;

            string queryString = @"SELECT id FROM Reservation WHERE Session_id='" + Session_id + "' AND rown='" + TableRow +
                "' AND seat='" + TableSeat + "'";
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = mysqlCSB.ConnectionString;
            connection.Open();
            dtA = new MySqlDataAdapter(queryString, connection);
            dtTb = new DataTable();
            dtA.Fill(dtTb);
            connection.Close();

            return Convert.ToInt32(dtTb.Rows[0]["id"]);
        }

        //Convert image to stream
        public static Stream ToStream(Image image, ImageFormat format)
        {
            var stream = new System.IO.MemoryStream();
            image.Save(stream, format);
            stream.Position = 0;
            return stream;
        }

        //Print ticket to PDF fle
        public void PrintTicket(int Reservation_id)
        {
            try
            {
                MySqlConnectionStringBuilder mysqlCSB = new MySqlConnectionStringBuilder();
                mysqlCSB = new MySqlConnectionStringBuilder();
                mysqlCSB.Server = Data.Server;
                mysqlCSB.Database = Data.Database;
                mysqlCSB.UserID = Data.User;
                mysqlCSB.Password = Data.Password;

                string queryString = @"SELECT Movie.title, Movie.duration, Session.date, Session.time, Hall.name, Hall.price,  
            Reservation.rown, Reservation.seat, Cinema.city FROM Reservation JOIN Session ON Reservation.Session_id=Session.id 
            JOIN Movie ON Session.Movie_id=Movie.id JOIN Hall ON Session.Hall_id=Hall.id JOIN Cinema ON 
            Session.Cinema_id=Cinema.id WHERE Reservation.id='" + Reservation_id + "'";
                MySqlConnection connection = new MySqlConnection();
                connection.ConnectionString = mysqlCSB.ConnectionString;
                connection.Open();
                dtA = new MySqlDataAdapter(queryString, connection);
                dtTb = new DataTable();
                dtA.Fill(dtTb);
                connection.Close();

                string title = dtTb.Rows[0]["title"].ToString();
                //string duration = dtTb.Rows[0]["duration"].ToString();
                string date = dtTb.Rows[0]["date"].ToString();
                date = date.Substring(0, date.IndexOf(" ") + 1);
                string time = dtTb.Rows[0]["time"].ToString();
                time = time.Substring(0, 5);
                string hall = dtTb.Rows[0]["name"].ToString();
                string row = dtTb.Rows[0]["rown"].ToString();
                string seat = dtTb.Rows[0]["seat"].ToString();
                string city = dtTb.Rows[0]["city"].ToString();
                string price = dtTb.Rows[0]["price"].ToString();

                BarcodeWriter writer = new BarcodeWriter { Format = BarcodeFormat.QR_CODE };
                string encoded_id = Base64Encode(Reservation_id);
                var result = writer.Write(encoded_id);
                var qrcodeBitmap = new Bitmap(result);
                Image QRCode = (Image)qrcodeBitmap;
                var QRCodeStream = ToStream(QRCode, ImageFormat.Jpeg);
                XImage image = XImage.FromStream(QRCodeStream);

                PdfDocument pdf = new PdfDocument();
                PdfPage pdfPage = pdf.AddPage();
                XGraphics graph = XGraphics.FromPdfPage(pdfPage);
                XFont font = new XFont("Verdana", 15, XFontStyle.Regular);
                XFont font2 = new XFont("Verdana", 10, XFontStyle.BoldItalic);
                XFont font3 = new XFont("Verdana", 20, XFontStyle.Bold);
                XFont font4 = new XFont("Calibri", 5, XFontStyle.Regular);
                graph.DrawImage(image, 245, 130, 100, 100);
                graph.DrawString("CineMAX " + city, font2, XBrushes.Black, new XRect(0, 8, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                graph.DrawString("\"" + title + "\"", font3, XBrushes.Black, new XRect(0, 20, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                graph.DrawString(date, font, XBrushes.Black, new XRect(0, 40, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                graph.DrawString("Час: " + time, font, XBrushes.Black, new XRect(0, 60, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                graph.DrawString("Зал: " + hall, font, XBrushes.Black, new XRect(0, 80, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                graph.DrawString("Ряд: " + row + "  Місце: " + seat, font, XBrushes.Black, new XRect(0, 100, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                graph.DrawString("Вартість: " + price + "грн.", font, XBrushes.Black, new XRect(0, 120, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                graph.DrawString(encoded_id, font, XBrushes.Black, new XRect(0, 210, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                string pdfFilename = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), encoded_id + ".pdf");
                pdf.Save(pdfFilename);
                Process.Start(pdfFilename);
            }
            catch (MySqlException) { MessageBox.Show("Помилка з'єднання!"); }
            catch (NotSupportedException) { MessageBox.Show("Помилка!"); }
        }

        //Delete reservation
        public void ReturnTicket(int Reservation_id)
        {
            MySqlConnectionStringBuilder mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = Data.Server;
            mysqlCSB.Database = Data.Database;
            mysqlCSB.UserID = Data.User;
            mysqlCSB.Password = Data.Password;

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = mysqlCSB.ConnectionString;
            connection.Open();
            MySqlCommand comm = connection.CreateCommand();
            comm.CommandText = "DELETE FROM Reservation WHERE id='" + Reservation_id + "'";
            comm.ExecuteNonQuery();
            connection.Close();
        }

        public void ClearSeatingChart()
        {
            //uncheck and disable all checkboxes
            foreach (Control c in SeatingChart.Controls)
                if (c is Panel)
                    foreach (Control b in c.Controls)
                        if (b is CheckBox)
                        {
                            CheckBox cb = (CheckBox)b;
                            cb.Enabled = false;
                            cb.Checked = false;
                        }
        }

        public void LoadBookingData(int Session_id)
        {
            MySqlConnectionStringBuilder mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = Data.Server;
            mysqlCSB.Database = Data.Database;
            mysqlCSB.UserID = Data.User;
            mysqlCSB.Password = Data.Password;

            string queryString = @"SELECT rown, seat FROM Reservation WHERE Session_id='" + Session_id + "'";
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = mysqlCSB.ConnectionString;
            connection.Open();
            dtA = new MySqlDataAdapter(queryString, connection);
            dtTb = new DataTable();
            dtA.Fill(dtTb);
            connection.Close();

            //If seat is in the table - it's reserved.
            //If seat is reserved - write char 's' to the array.
            ClearArray();
            for (int n = 0; n < dtTb.Rows.Count; n++)
            {
                int row = Convert.ToInt32(dtTb.Rows[n]["rown"].ToString());
                int seat = Convert.ToInt32(dtTb.Rows[n]["seat"].ToString());
                SelectedSeat[row - 1, seat - 1] = 's';
            }

            int i = 0;
            int j = 0;
            foreach (Control c in SeatingChart.Controls)
                if (c is Panel)
                    foreach (Control b in c.Controls)
                    {
                        //the loop begins from the object that has the highest level ('bring to front' button in VisualSt)
                        if (b is CheckBox)
                        {
                            CheckBox cb = (CheckBox)b;
                            //if the seat is reserved(sold) - disable 
                            if (SelectedSeat[i, j] == 's')
                            {
                                cb.Enabled = false;
                                cb.CheckState = CheckState.Indeterminate;
                            }
                            else
                            {
                                cb.Enabled = true;
                                cb.Checked = false;
                            }
                            //go on the next seat
                            j++;
                            //go on the next row in array
                            if (j == 14)
                            {
                                j = 0;
                                i++;
                            }
                        }
                    }
        }

        //load info on account tab page
        public void LoadAccountInfo()
        {
            MySqlConnectionStringBuilder mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = Data.Server;
            mysqlCSB.Database = Data.Database;
            mysqlCSB.UserID = Data.User;
            mysqlCSB.Password = Data.Password;

            string queryString = @"SELECT city FROM Cinema WHERE id=" + user.CinemaID + "";
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = mysqlCSB.ConnectionString;
            connection.Open();
            dtA = new MySqlDataAdapter(queryString, connection);
            dtTb = new DataTable();
            dtA.Fill(dtTb);
            connection.Close();

            cityLabel.Text = dtTb.Rows[0]["city"].ToString();
            accountLabel.Text = user.Login;
            positionLabel.Text = user.Position;
        }
        //function that fills the dropdown list with movies' titles
        public void LoadFilms(MetroComboBox Dropdown)
        {
            MySqlConnectionStringBuilder mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = Data.Server;
            mysqlCSB.Database = Data.Database;
            mysqlCSB.UserID = Data.User;
            mysqlCSB.Password = Data.Password;

            string queryString = @"SELECT title FROM Movie";
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = mysqlCSB.ConnectionString;
            connection.Open();
            dtA = new MySqlDataAdapter(queryString, connection);
            dtTb = new DataTable();
            dtA.Fill(dtTb);
            connection.Close();
            //fill dropdown list
            for (int i = 0; i < dtTb.Rows.Count; i++)
            {
                Dropdown.Items.Add(dtTb.Rows[i]["title"].ToString());
            }
        }
        //function that fills list with halls' types
        public void LoadHalls(MetroComboBox Dropdown)
        {
            MySqlConnectionStringBuilder mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = Data.Server;
            mysqlCSB.Database = Data.Database;
            mysqlCSB.UserID = Data.User;
            mysqlCSB.Password = Data.Password;

            string queryString = @"SELECT * FROM Hall";
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = mysqlCSB.ConnectionString;
            connection.Open();
            dtA = new MySqlDataAdapter(queryString, connection);
            dtTb = new DataTable();
            dtA.Fill(dtTb);
            connection.Close();
            //fill dropdown list
            for (int i = 0; i < dtTb.Rows.Count; i++)
            {
                Dropdown.Items.Add(dtTb.Rows[i]["name"].ToString());
            }
        }
        //function that adds NEW MOVIE to the databse
        public void AddMovie(string title, DateTime premiere, int duration, string poster)
        {
            try
            {
                MySqlConnectionStringBuilder mysqlCSB = new MySqlConnectionStringBuilder();
                mysqlCSB = new MySqlConnectionStringBuilder();
                mysqlCSB.Server = Data.Server;
                mysqlCSB.Database = Data.Database;
                mysqlCSB.UserID = Data.User;
                mysqlCSB.Password = Data.Password;

                MySqlConnection connection = new MySqlConnection();
                connection.ConnectionString = mysqlCSB.ConnectionString;
                connection.Open();
                MySqlCommand comm = connection.CreateCommand();

                comm.CommandText = "INSERT into Movie (title, premiere, duration, poster) " +
                    "values(@title, @premiere, @duration, @poster)";
                comm.Parameters.AddWithValue("@title", title);
                comm.Parameters.AddWithValue("@premiere", premiere);
                comm.Parameters.AddWithValue("@duration", duration);
                comm.Parameters.AddWithValue("@poster", poster);
                comm.ExecuteNonQuery();

                connection.Close();
                NewMovieTitle.Text = "";
                NewMovieLength.Text = "";
                NewMoviePoster.Text = "";
                AddMovieSuccessLabel.Visible = true;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Помилка з'єднання");
            }
        }
        //function that adds NEW SESSION to the database
        public void AddSession(DateTime date, int hall_id, int movie_id, int N) //N - number of new sessions
        {
            try
            {
                MySqlConnectionStringBuilder mysqlCSB = new MySqlConnectionStringBuilder();
                mysqlCSB = new MySqlConnectionStringBuilder();
                mysqlCSB.Server = Data.Server;
                mysqlCSB.Database = Data.Database;
                mysqlCSB.UserID = Data.User;
                mysqlCSB.Password = Data.Password;
                MySqlConnection connection = new MySqlConnection();
                connection.ConnectionString = mysqlCSB.ConnectionString;
                connection.Open();
                //write new sessions N times
                for (int i = 0; i < N; i++)
                {
                    //REALLY IMPORTANT
                    UpdateHours(ref Hours, hall_id, date);
                    // ^^^

                    MySqlCommand comm = connection.CreateCommand();
                    if (EndHours.TotalMinutes - Hours.TotalMinutes > duration)
                    {
                        comm.CommandText = "INSERT into Session (date, time, end_time, Cinema_id, Hall_id, Movie_id) " +
                            "values(@date, @time, @end_time, @Cinema_id, @Hall_id, @Movie_id)";
                        comm.Parameters.AddWithValue("@date", date);
                        comm.Parameters.AddWithValue("@time", Hours);
                        //add the duration of the movie
                        TimeSpan ts = new TimeSpan(0, duration, 0);
                        Hours = Hours.Add(ts);
                        //write in end_time
                        comm.Parameters.AddWithValue("@end_time", Hours);
                        comm.Parameters.AddWithValue("@Cinema_id", user.CinemaID);
                        comm.Parameters.AddWithValue("@Hall_id", hall_id);
                        comm.Parameters.AddWithValue("@Movie_id", movie_id);
                        comm.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Досягнута максимальна кількість сеансів в залі!");
                        break;
                    }
                }
                connection.Close();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Помилка з'єднання");
            }
        }
        //function that updates the 'variable Hours' for a specific hall and date
        public void UpdateHours(ref TimeSpan Hours, int Hall_id, DateTime date)
        {
            try
            {
                MySqlConnectionStringBuilder mysqlCSB = new MySqlConnectionStringBuilder();
                mysqlCSB = new MySqlConnectionStringBuilder();
                mysqlCSB.Server = Data.Server;
                mysqlCSB.Database = Data.Database;
                mysqlCSB.UserID = Data.User;
                mysqlCSB.Password = Data.Password;

                string queryString = @"SELECT end_time FROM Session WHERE Hall_id='" + Hall_id + "' " +
                    "AND date='" + date.ToString("yyyy-MM-dd") + "' AND Cinema_id='" + user.CinemaID + "' ORDER BY end_time DESC LIMIT 1";
                MySqlConnection connection = new MySqlConnection();
                connection.ConnectionString = mysqlCSB.ConnectionString;
                connection.Open();
                dtA = new MySqlDataAdapter(queryString, connection);
                dtTb = new DataTable();
                dtA.Fill(dtTb);
                connection.Close();
                TimeSpan LastTime = (TimeSpan)dtTb.Rows[0]["end_time"];
                Hours = new TimeSpan(LastTime.Hours, LastTime.Minutes + 15, 0);
            }
            catch (IndexOutOfRangeException)
            {
                Hours = new TimeSpan(10, 0, 0); //if 0 rows in table for the specific hall and date
            }
        }
        //Load poster
        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(MovieComboBox.SelectedIndex!=-1 && MovieComboBox.SelectedItem.ToString()!="")
            try
            {
                SessionsDropdown.Items.Clear();
                SessionHallList.Items.Clear();
                SessionsDropdown.SelectedIndex = -1;
                SessionHallList.SelectedIndex = -1;
                MovieDatePicker_ValueChanged(sender, e);

                ClearSeatingChart();

                MySqlConnectionStringBuilder mysqlCSB = new MySqlConnectionStringBuilder();
                mysqlCSB = new MySqlConnectionStringBuilder();
                mysqlCSB.Server = Data.Server;
                mysqlCSB.Database = Data.Database;
                mysqlCSB.UserID = Data.User;
                mysqlCSB.Password = Data.Password;

                string queryString = @"SELECT poster, id FROM Movie WHERE title='" + MovieComboBox.SelectedItem.ToString() + "'";
                MySqlConnection connection = new MySqlConnection();
                connection.ConnectionString = mysqlCSB.ConnectionString;
                connection.Open();
                dtA = new MySqlDataAdapter(queryString, connection);
                dtTb = new DataTable();
                dtA.Fill(dtTb);
                //get poster url from table

                string url = dtTb.Rows[0]["poster"].ToString();
                Movie_id = Convert.ToInt32(dtTb.Rows[0]["id"].ToString());
                pictureBox2.Load(url);

                //get date for datetimepicker auto-change
                queryString = @"SELECT premiere AS date FROM Movie WHERE title='" + MovieComboBox.SelectedItem.ToString() + "'";
                connection = new MySqlConnection();
                connection.ConnectionString = mysqlCSB.ConnectionString;
                dtA = new MySqlDataAdapter(queryString, connection);
                dtTb = new DataTable();
                dtA.Fill(dtTb);
                connection.Close();

                PremiereDate = (DateTime)dtTb.Rows[0]["date"];
                MovieDatePicker.Value = PremiereDate;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Помилка з'єднання");
            }
        }
        //ADD NEW MOVIE
        private void NewMovieButton_Click(object sender, EventArgs e)
        {
            string message = "Додати новий фільм?";
            string title = "Додати фільм";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
                AddMovie(NewMovieTitle.Text, NewMoviePremiere.Value, int.Parse(NewMovieLength.Text), NewMoviePoster.Text);
        }
        //ADD SESSION load info
        private void metroComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            NewSessionSuccessLabel.Visible = false;

            MySqlConnectionStringBuilder mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = Data.Server;
            mysqlCSB.Database = Data.Database;
            mysqlCSB.UserID = Data.User;
            mysqlCSB.Password = Data.Password;

            string queryString = @"SELECT duration, DATE_FORMAT(premiere, '%d.%m.%Y') AS 'date' 
                    FROM Movie WHERE title='" + NewSessionMovie.SelectedItem.ToString() + "'";
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = mysqlCSB.ConnectionString;
            connection.Open();
            dtA = new MySqlDataAdapter(queryString, connection);
            dtTb = new DataTable();
            dtA.Fill(dtTb);
            //get premiere date and duration from table
            label5.Text = "Прем'єра: " + dtTb.Rows[0]["date"].ToString();
            duration = (int)dtTb.Rows[0]["duration"];
            label8.Text = duration + " хв";

            //get date for datetimepicker auto-change
            queryString = @"SELECT premiere AS date FROM Movie WHERE title='" + NewSessionMovie.SelectedItem.ToString() + "'";
            connection = new MySqlConnection();
            connection.ConnectionString = mysqlCSB.ConnectionString;
            dtA = new MySqlDataAdapter(queryString, connection);
            dtTb = new DataTable();
            dtA.Fill(dtTb);
            connection.Close();

            PremiereDate = (DateTime)dtTb.Rows[0]["date"];
            NewSessionDate.Value = PremiereDate;
        }
        //ADD SESSION LOAD FILMS
        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroTabControl1.SelectedTab == metroTabControl1.TabPages["NewSessionTabPage"] && f)
            {
                LoadFilms(NewSessionMovie);
                LoadHalls(NewSessionHall);
                f = false;
                NewSessionDate.Value = DateTime.Today;
                label11.Text = "Сьогодні: " + DateTime.Today.ToString("dd.MM.yyyy");
            }
            if (metroTabControl1.SelectedTab == metroTabControl1.TabPages["MoviesTabPage"])
            {
                MovieComboBox.Items.Clear();
                LoadFilms(MovieComboBox);
                //metroComboBox1_SelectedIndexChanged(sender, e); все ломает
                MovieDatePicker_ValueChanged(sender, e);
            }
        }
        //ADD SESSION DATE
        private void NewSessionDate_ValueChanged(object sender, EventArgs e)
        {
            NewSessionSuccessLabel.Visible = false;
            if (NewSessionDate.Value < PremiereDate && NewSessionMovie.SelectedIndex != -1 && NewSessionMovie.SelectedItem.ToString() != "")
            {
                MessageBox.Show("Показ не може відбутися до прем'єри");
                NewSessionDate.Value = PremiereDate;
            }
        }

        private void NewSessionButton_Click(object sender, EventArgs e)
        {
            string message = "Додати новий сеанс?";
            string title = "Додати сеанс";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                //get 'hall_id'
                MySqlConnectionStringBuilder mysqlCSB = new MySqlConnectionStringBuilder();
                mysqlCSB = new MySqlConnectionStringBuilder();
                mysqlCSB.Server = Data.Server;
                mysqlCSB.Database = Data.Database;
                mysqlCSB.UserID = Data.User;
                mysqlCSB.Password = Data.Password;
                string queryString = @"SELECT * FROM Hall WHERE name='" + NewSessionHall.SelectedItem + "'";
                MySqlConnection connection = new MySqlConnection();
                connection.ConnectionString = mysqlCSB.ConnectionString;
                connection.Open();
                dtA = new MySqlDataAdapter(queryString, connection);
                dtTb = new DataTable();
                dtA.Fill(dtTb);

                int Hall_id = (int)dtTb.Rows[0]["id"];

                //get 'movie_id'
                queryString = @"SELECT * FROM Movie WHERE title='" + NewSessionMovie.SelectedItem + "'";
                connection = new MySqlConnection();
                connection.ConnectionString = mysqlCSB.ConnectionString;
                dtA = new MySqlDataAdapter(queryString, connection);
                dtTb = new DataTable();
                dtA.Fill(dtTb);
                connection.Close();

                int Movie_id = (int)dtTb.Rows[0]["id"];
                //Add N number of sessions
                //all the new sessions in this function are recorded during one database connection
                AddSession(NewSessionDate.Value, Hall_id, Movie_id, NewSessionAmount.SelectedIndex + 1);
                NewSessionSuccessLabel.Visible = true;
            }
        }
        //Select session time
        private void MovieDatePicker_ValueChanged(object sender, EventArgs e)
        {
            SessionsDropdown.Items.Clear();
            SessionsDropdown.ResetText();
            SessionsDropdown.Focus();
            SessionHallList.Items.Clear();
            SessionHallList.ResetText();
            SessionHallList.Focus();
            ClearSeatingChart();
            if (MovieComboBox.SelectedIndex != -1)
                try
                {
                    MySqlConnectionStringBuilder mysqlCSB = new MySqlConnectionStringBuilder();
                    mysqlCSB = new MySqlConnectionStringBuilder();
                    mysqlCSB.Server = Data.Server;
                    mysqlCSB.Database = Data.Database;
                    mysqlCSB.UserID = Data.User;
                    mysqlCSB.Password = Data.Password;

                    string queryString = @"SELECT DISTINCT time FROM Session JOIN Movie ON Session.Movie_id=Movie.id WHERE Session.Cinema_id='" + user.CinemaID +
                        "' AND Movie.title='" + MovieComboBox.SelectedItem.ToString() + "' AND Session.date='" +
                         MovieDatePicker.Value.ToString("yyyy-MM-dd") + "' ORDER BY time ASC";
                    MySqlConnection connection = new MySqlConnection();
                    connection.ConnectionString = mysqlCSB.ConnectionString;
                    connection.Open();
                    dtA = new MySqlDataAdapter(queryString, connection);
                    dtTb = new DataTable();
                    dtA.Fill(dtTb);
                    connection.Close();
                    SessionsDropdown.Items.Clear();
                    for (int i = 0; i < dtTb.Rows.Count; i++)
                    {
                        //format without seconds
                        TimeSpan ts = (TimeSpan)dtTb.Rows[i]["time"];
                        string formated = string.Format("{0:00}:{1:00}", ts.Hours, ts.Minutes);
                        SessionsDropdown.Items.Add(formated);
                    }
                }
                catch (MySqlException) { MessageBox.Show("Помилка з'єднання!"); }
                catch (IndexOutOfRangeException) { MessageBox.Show("Помилка!"); }
        }

        //select hall
        private void SessionsDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SessionHallList.Items.Clear();
                SessionHallList.ResetText();
                SessionHallList.Focus();

                //uncheck and disable all checkboxes
                ClearSeatingChart();

                MySqlConnectionStringBuilder mysqlCSB = new MySqlConnectionStringBuilder();
                mysqlCSB = new MySqlConnectionStringBuilder();
                mysqlCSB.Server = Data.Server;
                mysqlCSB.Database = Data.Database;
                mysqlCSB.UserID = Data.User;
                mysqlCSB.Password = Data.Password;

                string queryString = @"SELECT Hall.name FROM Session JOIN Movie ON Session.Movie_id=Movie.id " +
                    "JOIN Hall ON Session.Hall_id=Hall.id WHERE Movie.title='" + MovieComboBox.SelectedItem.ToString()
                    + "' AND Session.date='" + MovieDatePicker.Value.ToString("yyyy-MM-dd") + "' AND Session.time = '" +
                    SessionsDropdown.SelectedItem.ToString() + ":00' AND Session.Cinema_id='" + user.CinemaID + "'";
                MySqlConnection connection = new MySqlConnection();
                connection.ConnectionString = mysqlCSB.ConnectionString;
                connection.Open();
                dtA = new MySqlDataAdapter(queryString, connection);
                dtTb = new DataTable();
                dtA.Fill(dtTb);
                connection.Close();
                //fill 'halls list'
                SessionHallList.Items.Clear();
                for (int i = 0; i < dtTb.Rows.Count; i++)
                    SessionHallList.Items.Add(dtTb.Rows[i]["name"]);
            }
            catch (MySqlException) { MessageBox.Show("Помилка з'єднання!"); }
        }

        private void SessionHallList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelCheckoutSuccess.Visible = false;
            int Hall_id = GetHallOrPrice(true);
            int Session_id = 0;
            try
            {
                Session_id = GetSessionID(MovieDatePicker.Value,
                    SessionsDropdown.SelectedItem.ToString(), Hall_id, Movie_id);
            }
            catch (NullReferenceException) { }
            //show if seats are reserved(sold) on the seating chart (checkbox array)
            LoadBookingData(Session_id);

            string hall = "";
            if (SessionHallList.SelectedItem != null)
                hall = SessionHallList.SelectedItem.ToString();
            //change seating chart
            switch (hall)
            {
                case "2D #1":
                case "2D #2":
                    row8.Visible = false;
                    row9.Visible = false;
                    row10.Visible = false;
                    SeatingChart.Size = new Size(358, SeatingChart.Size.Height);
                    MyAlign.CenterControlsAsGroup(Chart, MyAlign.Direction.Both);
                    break;
                case "3D #1":
                case "3D #2":
                    row8.Visible = true;
                    row9.Visible = false;
                    row10.Visible = false;
                    SeatingChart.Size = new Size(425, SeatingChart.Size.Height);
                    MyAlign.CenterControlsAsGroup(Chart, MyAlign.Direction.Both);
                    break;
                case "IMAX":
                    row8.Visible = true;
                    row9.Visible = true;
                    row10.Visible = true;
                    SeatingChart.Size = new Size(570, SeatingChart.Size.Height);
                    MyAlign.CenterControlsAsGroup(Chart, MyAlign.Direction.Both);
                    break;
                default:
                    row8.Visible = false;
                    row9.Visible = false;
                    row10.Visible = false;
                    SeatingChart.Size = new Size(358, SeatingChart.Size.Height);
                    MyAlign.CenterControlsAsGroup(Chart, MyAlign.Direction.Both);
                    //disable all elements
                    foreach (Control c in SeatingChart.Controls)
                        c.Enabled = false;
                    break;
            }
        }

        //if checkbox is checked (seat is chosen) - write 'true' to the 2D collection
        public void CheckSeat(Control a, int row)
        {
            int i = 0;
            foreach (Control b in a.Controls)
            {
                if (b is CheckBox)
                {
                    CheckBox cb = (CheckBox)b;
                    if (cb.CheckState == CheckState.Checked)
                        SelectedSeat[row, i] = 't';
                    i++;
                }
            }
        }
        //fill 2D collection with 'checked'(chosen) seats
        public void CheckSeating(Control Panel)
        {
            foreach (Control a in Panel.Controls)
            {
                switch (a.Name)
                {
                    case "row1":
                        CheckSeat(a, 0);
                        break;
                    case "row2":
                        CheckSeat(a, 1);
                        break;
                    case "row3":
                        CheckSeat(a, 2);
                        break;
                    case "row4":
                        CheckSeat(a, 3);
                        break;
                    case "row5":
                        CheckSeat(a, 4);
                        break;
                    case "row6":
                        CheckSeat(a, 5);
                        break;
                    case "row7":
                        CheckSeat(a, 6);
                        break;
                    case "row8":
                        CheckSeat(a, 7);
                        break;
                    case "row9":
                        CheckSeat(a, 8);
                        break;
                    case "row10":
                        CheckSeat(a, 9);
                        break;
                }
            }
        }

        private void CheckOutButton_Click(object sender, EventArgs e)
        {
            int TicketPrice = GetHallOrPrice(false);
            int TicketCount = 0;
            CheckSeating(SeatingChart);
            //count selected seats to calculate price for all tickets
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 14; j++)
                    if (SelectedSeat[i, j] == 't')
                        TicketCount++;
            //Show price to pay for the tickets
            string message = "До сплати: " + TicketCount + " x " + TicketPrice + "грн. = " + TicketCount * TicketPrice +
                "грн." + Environment.NewLine + Environment.NewLine + "Підтвердити операцію?";
            string title = "Бронювання";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                int Hall_id = GetHallOrPrice(true);
                int Session_id = GetSessionID(MovieDatePicker.Value,
                                    SessionsDropdown.SelectedItem.ToString(), Hall_id, Movie_id);
                CheckSeating(SeatingChart);
                for (int i = 0; i < 10; i++)
                    for (int j = 0; j < 14; j++)
                        if (SelectedSeat[i, j] == 't')
                        {
                            MySqlConnectionStringBuilder mysqlCSB = new MySqlConnectionStringBuilder();
                            mysqlCSB = new MySqlConnectionStringBuilder();
                            mysqlCSB.Server = Data.Server;
                            mysqlCSB.Database = Data.Database;
                            mysqlCSB.UserID = Data.User;
                            mysqlCSB.Password = Data.Password;

                            MySqlConnection connection = new MySqlConnection();
                            connection.ConnectionString = mysqlCSB.ConnectionString;
                            connection.Open();
                            MySqlCommand comm = connection.CreateCommand();

                            comm.CommandText = "INSERT into Reservation (Session_id, rown, seat) " +
                                "values(@Session_id, @rown, @seat)";
                            comm.Parameters.AddWithValue("@Session_id", Session_id);
                            comm.Parameters.AddWithValue("@rown", i + 1);
                            comm.Parameters.AddWithValue("@seat", j + 1);
                            comm.ExecuteNonQuery();
                            connection.Close();
                            //create pdf file with ticket info
                            int Reservation_id = GetReservationID(Session_id, i + 1, j + 1);
                            PrintTicket(Reservation_id);
                        }
                LabelCheckoutSuccess.Visible = true;
                //clear 'seats array' and ticks from the chart
                ClearArray();
                ClearSeatingChart();
                //update seating chart
                LoadBookingData(Session_id);
            }
        }

        private void ReturnTicketButton_Click(object sender, EventArgs e)
        {
            string message = "Повернути квиток?";
            string title = "Повернення квитка";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                string code = ReturnTicketTextBox.Text;
                if (code == "")
                    MessageBox.Show("Відскануйте або введіть код з квитка!");
                else
                {
                    int Reservation_id = Base64Decode(code);
                    if (Reservation_id != 0)
                    {
                        MySqlConnectionStringBuilder mysqlCSB = new MySqlConnectionStringBuilder();
                        mysqlCSB = new MySqlConnectionStringBuilder();
                        mysqlCSB.Server = Data.Server;
                        mysqlCSB.Database = Data.Database;
                        mysqlCSB.UserID = Data.User;
                        mysqlCSB.Password = Data.Password;
                        string queryString = @"SELECT date, time FROM Reservation JOIN Session on Reservation.Session_id=Session.id 
                WHERE Reservation.id='" + Reservation_id + "'";
                        MySqlConnection connection = new MySqlConnection();
                        connection.ConnectionString = mysqlCSB.ConnectionString;
                        connection.Open();
                        dtA = new MySqlDataAdapter(queryString, connection);
                        dtTb = new DataTable();
                        dtA.Fill(dtTb);
                        connection.Close();
                        DateTime TicketDate = (DateTime)dtTb.Rows[0]["date"];
                        TimeSpan TicketTime = (TimeSpan)dtTb.Rows[0]["time"];
                        TicketDate = TicketDate.Add(TicketTime);
                        DateTime TimeNow = DateTime.Now;

                        TimeSpan Difference = TicketDate.Subtract(TimeNow);

                        if (Difference.TotalMinutes >= 0)
                        {
                            ReturnTicket(Reservation_id);
                            ReturnTicketTextBox.Text = "";
                            ReturnTicketLabel.Visible = true;
                        }
                        else
                            MessageBox.Show("Повернути квиток після початку сеансу не можливо!");
                    }
                }
            }
        }

        private void ReturnTicketTextBox_OnValueChanged(object sender, EventArgs e)
        {
            ReturnTicketLabel.Visible = false;
        }

        private void NewSessionAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
            NewSessionSuccessLabel.Visible = false;
        }

        private void NewSessionHall_SelectedIndexChanged(object sender, EventArgs e)
        {
            NewSessionSuccessLabel.Visible = false;
        }

        private void NewMovieTitle_OnValueChanged(object sender, EventArgs e)
        {
            AddMovieSuccessLabel.Visible = false;
        }


    }
}