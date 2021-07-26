using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Project1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //password encryption
        public static class Hashing
        {
            private static string GetRandomSalt()
            {
                return BCrypt.Net.BCrypt.GenerateSalt(12);
            }
            public static string HashPassword(string password)
            {
                return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
            }
            public static bool ValidatePassword(string password, string correctHash)
            {
                return BCrypt.Net.BCrypt.Verify(password, correctHash);
            }
        }
        //database connection info
        public static class Data
        {
            public static string Server = "******.******.amazonaws.com";
            public static string Database = "******";
            public static string User = "******";
            public static string Password = "******";
        }

        public class DB
        {
            public DataTable DtTb { get; private set; }

            public DB(string query)
            {
                try
                {
                    DataTable Tb = new DataTable();
                    MySqlConnectionStringBuilder mysqlCSB = new MySqlConnectionStringBuilder();
                    MySqlConnection connection = new MySqlConnection();
                    mysqlCSB.Server = Data.Server;
                    mysqlCSB.Database = Data.Database;
                    mysqlCSB.UserID = Data.User;
                    mysqlCSB.Password = Data.Password;
                    connection.ConnectionString = mysqlCSB.ConnectionString;
                    MySqlDataAdapter DtA = new MySqlDataAdapter(query, connection);

                    connection.Open();
                    DtA.Fill(Tb);
                    connection.Close();
                    DtTb = Tb;
                }
                catch(MySqlException)
                {
                    MessageBox.Show("Помилка з'єднання!");
                }
            }
        }
        //user info class
        public static class user
        {
            public static string Login { get; set; }
            public static int CinemaID { get; set; }
            public static string Position { get; set; }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            passwordTextbox.isPassword = true;
            RegisterPass.isPassword = true;
            RegisterPassValidate.isPassword = true;
            CodeWord.isPassword = true;
        }

        //Close the login form
        private void loginCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Show "wrong login or pass" message
        private void LoginFailed()
        {
            loginAlert.Visible = true;
        }
        //LoginFailed message
        private void LoginFailedHide()
        {
            loginAlert.Visible = false;
        }
        //function that adds new account to the DB
        private void Register(string login, string pass, string cinema_id, string position)
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

                comm.CommandText = "INSERT into Staff (login, password, Cinema_id, position) " +
                    "values(@login, @password, @Cinema_id, @position)";
                comm.Parameters.AddWithValue("@login", login);
                //Hashing the password
                string HashedPass = Hashing.HashPassword(pass);
                comm.Parameters.AddWithValue("@password", HashedPass);
                comm.Parameters.AddWithValue("@Cinema_id", cinema_id);
                comm.Parameters.AddWithValue("@position", position);
                comm.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Користувача зареєстровано!");
            }
            catch(MySqlException)
            {
                MessageBox.Show("Помилка з'єднання");
            }
            
        }
        //login button
        private void loginButton_Click(object sender, EventArgs e)
        {
            //if login or password textbox is empty
            if (loginTextbox.Text.ToString() == "" || passwordTextbox.Text.ToString() == "")
            {
                //Show alert
                LoginFailed();
            }
            else
            {
                try
                {
                    //set up DB connection
                    string queryString = @"SELECT * FROM Staff";
                    DB DB = new DB(queryString);

                    //check login and password
                    for (int i = 0; i < DB.DtTb.Rows.Count; i++)
                    {
                        //If login found
                        if (DB.DtTb.Rows[i]["login"].ToString() == loginTextbox.Text)
                            //check password. If found
                            if (Hashing.ValidatePassword(passwordTextbox.Text.ToString(), DB.DtTb.Rows[i]["password"].ToString()))
                            {
                                //store user data
                                user.Login = loginTextbox.Text;
                                user.CinemaID = Convert.ToInt32(DB.DtTb.Rows[i]["Cinema_id"]);
                                user.Position = DB.DtTb.Rows[i]["position"].ToString();

                                //hide LoginFailed message
                                LoginFailedHide();

                                //open admin form
                                MainForm f2 = new MainForm();
                                f2.Show();
                                f2.Location = this.Location;
                                f2.FormClosing += (obj, args) => { this.Close(); };
                                this.Hide();

                                //exit search loop
                                break;
                            }
                            else
                                //Show LoginFailed message
                                LoginFailed();
                        //if reached end of 'staff' table
                        else if (i == DB.DtTb.Rows.Count - 1)
                            //Show LoginFailed message
                            LoginFailed();
                    }
                }
                catch(MySqlException)
                {
                    MessageBox.Show("Помилка з'єднання");
                }
            }
        }

        //відкрити вікно реєстрації
        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            try
            {
                CityDropdownList.Items.Clear();
                //set up DB connection\
                string queryString = @"SELECT * FROM Cinema";
                DB DB = new DB(queryString);

                //заповненя випадаючого списку назвами міст
                for (int i = 0; i < DB.DtTb.Rows.Count; i++)
                    CityDropdownList.Items.Add(DB.DtTb.Rows[i]["city"].ToString());

                LoginPanel.Visible = false;
                RegistrationPanel.Visible = true;
            }
            catch(MySqlException)
            {
                MessageBox.Show("Помилка з'єднання");
            }
        }

        private void RegistrationPanel_VisibleChanged(object sender, EventArgs e)
        {
            //якщо панель реєстрації відкрита - приховати кнопку "зареєструватись"
            if (RegistrationPanel.Visible)
                RegistrationButton.Visible = false;
            else
                RegistrationButton.Visible = true;
        }

        private void ReturnToLoginButton_Click(object sender, EventArgs e)
        {
            RegistrationPanel.Visible = false;
            LoginPanel.Visible = true;
        }

        //підтвердити реєстрацію
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            try
            {
                //set up DB connection
                string queryString = @"SELECT * FROM Cinema";
                DB DB = new DB(queryString);

                for (int i = 0; i < DB.DtTb.Rows.Count; i++)
                {
                    //find city to extract cinema_id
                    if (DB.DtTb.Rows[i]["city"].ToString() == CityDropdownList.SelectedItem.ToString())
                    {
                        string cinema_id = DB.DtTb.Rows[i]["id"].ToString();
                        //validate code, if corresponds
                        if (DB.DtTb.Rows[i]["code"].ToString() == CodeWord.Text)
                        {
                            //if passwords are the same
                            if (RegisterPass.Text == RegisterPassValidate.Text)
                                Register(RegisterLogin.Text, RegisterPass.Text, cinema_id, RegisterPosition.Text);
                            RegistrationPanel.Visible = false;
                            LoginPanel.Visible = true;
                        }
                        else
                        {
                            RegisterErrorAlert.Visible = true;
                            CodeWord.Text = "";
                        }
                    }
                }
                
            }
            catch(MySqlException)
            {
                MessageBox.Show("Помилка з'єднання");
            }
        }

        private void passwordTextbox_Enter(object sender, EventArgs e)
        {
            passwordTextbox.Text = "a";
            passwordTextbox.isPassword = true;
            passwordTextbox.Text = "";
        }

        private void RegisterPass_Enter(object sender, EventArgs e)
        {
            RegisterPass.Text = "a";
            RegisterPass.isPassword = true;
            RegisterPass.Text = "";
        }

        private void RegisterPassValidate_Enter(object sender, EventArgs e)
        {
            RegisterPassValidate.Text = "a";
            RegisterPassValidate.isPassword = true;
            RegisterPassValidate.Text = "";
        }

        private void CodeWord_Enter(object sender, EventArgs e)
        {
            CodeWord.Text = "a";
            CodeWord.isPassword = true;
            CodeWord.Text = "";
        }
    }
}
