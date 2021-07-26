namespace Project1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.loginTextbox = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.passwordTextbox = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.loginAlert = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.RegistrationButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.loginButton = new Bunifu.Framework.UI.BunifuThinButton2();
            this.RegistrationPanel = new System.Windows.Forms.Panel();
            this.CityDropdownList = new MetroFramework.Controls.MetroComboBox();
            this.RegisterErrorAlert = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.RegisterPosition = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuCustomLabel9 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.ReturnToLoginButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.RegisterButton = new Bunifu.Framework.UI.BunifuThinButton2();
            this.CodeWord = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuCustomLabel8 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel7 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.RegisterPassValidate = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuCustomLabel6 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel5 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.RegisterLogin = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.RegisterPass = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.loginCloseButton = new Bunifu.Framework.UI.BunifuImageButton();
            this.LoginPanel.SuspendLayout();
            this.RegistrationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginCloseButton)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // loginTextbox
            // 
            this.loginTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.loginTextbox.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginTextbox.ForeColor = System.Drawing.Color.White;
            this.loginTextbox.HintForeColor = System.Drawing.Color.White;
            this.loginTextbox.HintText = "";
            this.loginTextbox.isPassword = false;
            this.loginTextbox.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.loginTextbox.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.loginTextbox.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.loginTextbox.LineThickness = 4;
            this.loginTextbox.Location = new System.Drawing.Point(293, 118);
            this.loginTextbox.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.loginTextbox.Name = "loginTextbox";
            this.loginTextbox.Size = new System.Drawing.Size(328, 43);
            this.loginTextbox.TabIndex = 2;
            this.loginTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(289, 89);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(63, 24);
            this.bunifuCustomLabel1.TabIndex = 3;
            this.bunifuCustomLabel1.Text = "Логін";
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(289, 183);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(88, 24);
            this.bunifuCustomLabel2.TabIndex = 4;
            this.bunifuCustomLabel2.Text = "Пароль";
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passwordTextbox.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordTextbox.ForeColor = System.Drawing.Color.White;
            this.passwordTextbox.HintForeColor = System.Drawing.Color.White;
            this.passwordTextbox.HintText = "";
            this.passwordTextbox.isPassword = true;
            this.passwordTextbox.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.passwordTextbox.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.passwordTextbox.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.passwordTextbox.LineThickness = 4;
            this.passwordTextbox.Location = new System.Drawing.Point(293, 212);
            this.passwordTextbox.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.Size = new System.Drawing.Size(329, 43);
            this.passwordTextbox.TabIndex = 5;
            this.passwordTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.passwordTextbox.Enter += new System.EventHandler(this.passwordTextbox_Enter);
            // 
            // loginAlert
            // 
            this.loginAlert.AutoSize = true;
            this.loginAlert.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginAlert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.loginAlert.Location = new System.Drawing.Point(331, 313);
            this.loginAlert.Name = "loginAlert";
            this.loginAlert.Size = new System.Drawing.Size(259, 22);
            this.loginAlert.TabIndex = 8;
            this.loginAlert.Text = "Невірний логін або пароль";
            this.loginAlert.Visible = false;
            // 
            // RegistrationButton
            // 
            this.RegistrationButton.Activecolor = System.Drawing.Color.Transparent;
            this.RegistrationButton.BackColor = System.Drawing.Color.Transparent;
            this.RegistrationButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RegistrationButton.BorderRadius = 0;
            this.RegistrationButton.ButtonText = "Зареєструватись";
            this.RegistrationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegistrationButton.DisabledColor = System.Drawing.Color.Gray;
            this.RegistrationButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistrationButton.Iconcolor = System.Drawing.Color.Transparent;
            this.RegistrationButton.Iconimage = null;
            this.RegistrationButton.Iconimage_right = null;
            this.RegistrationButton.Iconimage_right_Selected = null;
            this.RegistrationButton.Iconimage_Selected = null;
            this.RegistrationButton.IconMarginLeft = 0;
            this.RegistrationButton.IconMarginRight = 0;
            this.RegistrationButton.IconRightVisible = true;
            this.RegistrationButton.IconRightZoom = 0D;
            this.RegistrationButton.IconVisible = true;
            this.RegistrationButton.IconZoom = 90D;
            this.RegistrationButton.IsTab = false;
            this.RegistrationButton.Location = new System.Drawing.Point(403, 604);
            this.RegistrationButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.RegistrationButton.Name = "RegistrationButton";
            this.RegistrationButton.Normalcolor = System.Drawing.Color.Transparent;
            this.RegistrationButton.OnHovercolor = System.Drawing.Color.Transparent;
            this.RegistrationButton.OnHoverTextColor = System.Drawing.Color.DeepSkyBlue;
            this.RegistrationButton.selected = false;
            this.RegistrationButton.Size = new System.Drawing.Size(183, 32);
            this.RegistrationButton.TabIndex = 10;
            this.RegistrationButton.Text = "Зареєструватись";
            this.RegistrationButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RegistrationButton.Textcolor = System.Drawing.Color.DodgerBlue;
            this.RegistrationButton.TextFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistrationButton.Click += new System.EventHandler(this.RegistrationButton_Click);
            // 
            // LoginPanel
            // 
            this.LoginPanel.Controls.Add(this.bunifuCustomLabel1);
            this.LoginPanel.Controls.Add(this.loginTextbox);
            this.LoginPanel.Controls.Add(this.loginAlert);
            this.LoginPanel.Controls.Add(this.bunifuCustomLabel2);
            this.LoginPanel.Controls.Add(this.loginButton);
            this.LoginPanel.Controls.Add(this.passwordTextbox);
            this.LoginPanel.Location = new System.Drawing.Point(43, 171);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(910, 425);
            this.LoginPanel.TabIndex = 11;
            // 
            // loginButton
            // 
            this.loginButton.ActiveBorderThickness = 2;
            this.loginButton.ActiveCornerRadius = 10;
            this.loginButton.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(102)))), ((int)(((byte)(166)))));
            this.loginButton.ActiveForecolor = System.Drawing.Color.White;
            this.loginButton.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.loginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(34)))), ((int)(((byte)(56)))));
            this.loginButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loginButton.BackgroundImage")));
            this.loginButton.ButtonText = "Увійти";
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginButton.ForeColor = System.Drawing.Color.SeaGreen;
            this.loginButton.IdleBorderThickness = 2;
            this.loginButton.IdleCornerRadius = 10;
            this.loginButton.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(63)))), ((int)(((byte)(102)))));
            this.loginButton.IdleForecolor = System.Drawing.Color.White;
            this.loginButton.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.loginButton.Location = new System.Drawing.Point(386, 265);
            this.loginButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(142, 50);
            this.loginButton.TabIndex = 7;
            this.loginButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // RegistrationPanel
            // 
            this.RegistrationPanel.Controls.Add(this.CityDropdownList);
            this.RegistrationPanel.Controls.Add(this.RegisterErrorAlert);
            this.RegistrationPanel.Controls.Add(this.RegisterPosition);
            this.RegistrationPanel.Controls.Add(this.bunifuCustomLabel9);
            this.RegistrationPanel.Controls.Add(this.ReturnToLoginButton);
            this.RegistrationPanel.Controls.Add(this.RegisterButton);
            this.RegistrationPanel.Controls.Add(this.CodeWord);
            this.RegistrationPanel.Controls.Add(this.bunifuCustomLabel8);
            this.RegistrationPanel.Controls.Add(this.bunifuCustomLabel7);
            this.RegistrationPanel.Controls.Add(this.RegisterPassValidate);
            this.RegistrationPanel.Controls.Add(this.bunifuCustomLabel6);
            this.RegistrationPanel.Controls.Add(this.bunifuCustomLabel5);
            this.RegistrationPanel.Controls.Add(this.bunifuCustomLabel3);
            this.RegistrationPanel.Controls.Add(this.RegisterLogin);
            this.RegistrationPanel.Controls.Add(this.bunifuCustomLabel4);
            this.RegistrationPanel.Controls.Add(this.RegisterPass);
            this.RegistrationPanel.Location = new System.Drawing.Point(49, 157);
            this.RegistrationPanel.Name = "RegistrationPanel";
            this.RegistrationPanel.Size = new System.Drawing.Size(909, 447);
            this.RegistrationPanel.TabIndex = 12;
            this.RegistrationPanel.Visible = false;
            this.RegistrationPanel.VisibleChanged += new System.EventHandler(this.RegistrationPanel_VisibleChanged);
            // 
            // CityDropdownList
            // 
            this.CityDropdownList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(106)))));
            this.CityDropdownList.FontSize = MetroFramework.MetroComboBoxSize.Tall;
            this.CityDropdownList.ForeColor = System.Drawing.Color.White;
            this.CityDropdownList.FormattingEnabled = true;
            this.CityDropdownList.ItemHeight = 29;
            this.CityDropdownList.Location = new System.Drawing.Point(492, 196);
            this.CityDropdownList.Name = "CityDropdownList";
            this.CityDropdownList.Size = new System.Drawing.Size(209, 35);
            this.CityDropdownList.TabIndex = 22;
            this.CityDropdownList.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CityDropdownList.UseCustomBackColor = true;
            this.CityDropdownList.UseCustomForeColor = true;
            this.CityDropdownList.UseSelectable = true;
            this.CityDropdownList.UseStyleColors = true;
            // 
            // RegisterErrorAlert
            // 
            this.RegisterErrorAlert.AutoSize = true;
            this.RegisterErrorAlert.BackColor = System.Drawing.Color.Transparent;
            this.RegisterErrorAlert.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegisterErrorAlert.ForeColor = System.Drawing.Color.Red;
            this.RegisterErrorAlert.Location = new System.Drawing.Point(350, 387);
            this.RegisterErrorAlert.Name = "RegisterErrorAlert";
            this.RegisterErrorAlert.Size = new System.Drawing.Size(209, 20);
            this.RegisterErrorAlert.TabIndex = 21;
            this.RegisterErrorAlert.Text = "Помилка у введених даних";
            this.RegisterErrorAlert.Visible = false;
            // 
            // RegisterPosition
            // 
            this.RegisterPosition.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.RegisterPosition.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegisterPosition.ForeColor = System.Drawing.Color.White;
            this.RegisterPosition.HintForeColor = System.Drawing.Color.White;
            this.RegisterPosition.HintText = "";
            this.RegisterPosition.isPassword = false;
            this.RegisterPosition.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.RegisterPosition.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.RegisterPosition.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.RegisterPosition.LineThickness = 4;
            this.RegisterPosition.Location = new System.Drawing.Point(493, 99);
            this.RegisterPosition.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.RegisterPosition.Name = "RegisterPosition";
            this.RegisterPosition.Size = new System.Drawing.Size(329, 43);
            this.RegisterPosition.TabIndex = 20;
            this.RegisterPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel9
            // 
            this.bunifuCustomLabel9.AutoSize = true;
            this.bunifuCustomLabel9.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel9.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bunifuCustomLabel9.Location = new System.Drawing.Point(489, 70);
            this.bunifuCustomLabel9.Name = "bunifuCustomLabel9";
            this.bunifuCustomLabel9.Size = new System.Drawing.Size(93, 24);
            this.bunifuCustomLabel9.TabIndex = 19;
            this.bunifuCustomLabel9.Text = "Посада";
            // 
            // ReturnToLoginButton
            // 
            this.ReturnToLoginButton.Activecolor = System.Drawing.Color.Transparent;
            this.ReturnToLoginButton.BackColor = System.Drawing.Color.Transparent;
            this.ReturnToLoginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ReturnToLoginButton.BorderRadius = 0;
            this.ReturnToLoginButton.ButtonText = "Повернутись назад";
            this.ReturnToLoginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReturnToLoginButton.DisabledColor = System.Drawing.Color.Gray;
            this.ReturnToLoginButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReturnToLoginButton.Iconcolor = System.Drawing.Color.Transparent;
            this.ReturnToLoginButton.Iconimage = null;
            this.ReturnToLoginButton.Iconimage_right = null;
            this.ReturnToLoginButton.Iconimage_right_Selected = null;
            this.ReturnToLoginButton.Iconimage_Selected = null;
            this.ReturnToLoginButton.IconMarginLeft = 0;
            this.ReturnToLoginButton.IconMarginRight = 0;
            this.ReturnToLoginButton.IconRightVisible = true;
            this.ReturnToLoginButton.IconRightZoom = 0D;
            this.ReturnToLoginButton.IconVisible = true;
            this.ReturnToLoginButton.IconZoom = 90D;
            this.ReturnToLoginButton.IsTab = false;
            this.ReturnToLoginButton.Location = new System.Drawing.Point(365, 413);
            this.ReturnToLoginButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ReturnToLoginButton.Name = "ReturnToLoginButton";
            this.ReturnToLoginButton.Normalcolor = System.Drawing.Color.Transparent;
            this.ReturnToLoginButton.OnHovercolor = System.Drawing.Color.Transparent;
            this.ReturnToLoginButton.OnHoverTextColor = System.Drawing.Color.DeepSkyBlue;
            this.ReturnToLoginButton.selected = false;
            this.ReturnToLoginButton.Size = new System.Drawing.Size(178, 26);
            this.ReturnToLoginButton.TabIndex = 13;
            this.ReturnToLoginButton.Text = "Повернутись назад";
            this.ReturnToLoginButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ReturnToLoginButton.Textcolor = System.Drawing.Color.DodgerBlue;
            this.ReturnToLoginButton.TextFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReturnToLoginButton.Click += new System.EventHandler(this.ReturnToLoginButton_Click);
            // 
            // RegisterButton
            // 
            this.RegisterButton.ActiveBorderThickness = 2;
            this.RegisterButton.ActiveCornerRadius = 10;
            this.RegisterButton.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(102)))), ((int)(((byte)(166)))));
            this.RegisterButton.ActiveForecolor = System.Drawing.Color.White;
            this.RegisterButton.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.RegisterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(34)))), ((int)(((byte)(56)))));
            this.RegisterButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RegisterButton.BackgroundImage")));
            this.RegisterButton.ButtonText = "Зареєструватись";
            this.RegisterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegisterButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegisterButton.ForeColor = System.Drawing.Color.SeaGreen;
            this.RegisterButton.IdleBorderThickness = 2;
            this.RegisterButton.IdleCornerRadius = 10;
            this.RegisterButton.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(63)))), ((int)(((byte)(102)))));
            this.RegisterButton.IdleForecolor = System.Drawing.Color.White;
            this.RegisterButton.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.RegisterButton.Location = new System.Drawing.Point(352, 339);
            this.RegisterButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(205, 49);
            this.RegisterButton.TabIndex = 17;
            this.RegisterButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // CodeWord
            // 
            this.CodeWord.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CodeWord.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CodeWord.ForeColor = System.Drawing.Color.White;
            this.CodeWord.HintForeColor = System.Drawing.Color.White;
            this.CodeWord.HintText = "";
            this.CodeWord.isPassword = true;
            this.CodeWord.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.CodeWord.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CodeWord.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CodeWord.LineThickness = 4;
            this.CodeWord.Location = new System.Drawing.Point(492, 277);
            this.CodeWord.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.CodeWord.Name = "CodeWord";
            this.CodeWord.Size = new System.Drawing.Size(329, 43);
            this.CodeWord.TabIndex = 16;
            this.CodeWord.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CodeWord.Enter += new System.EventHandler(this.CodeWord_Enter);
            // 
            // bunifuCustomLabel8
            // 
            this.bunifuCustomLabel8.AutoSize = true;
            this.bunifuCustomLabel8.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel8.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bunifuCustomLabel8.Location = new System.Drawing.Point(488, 248);
            this.bunifuCustomLabel8.Name = "bunifuCustomLabel8";
            this.bunifuCustomLabel8.Size = new System.Drawing.Size(157, 24);
            this.bunifuCustomLabel8.TabIndex = 15;
            this.bunifuCustomLabel8.Text = "Кодове слово";
            // 
            // bunifuCustomLabel7
            // 
            this.bunifuCustomLabel7.AutoSize = true;
            this.bunifuCustomLabel7.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel7.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bunifuCustomLabel7.Location = new System.Drawing.Point(489, 159);
            this.bunifuCustomLabel7.Name = "bunifuCustomLabel7";
            this.bunifuCustomLabel7.Size = new System.Drawing.Size(68, 24);
            this.bunifuCustomLabel7.TabIndex = 13;
            this.bunifuCustomLabel7.Text = "Місто";
            // 
            // RegisterPassValidate
            // 
            this.RegisterPassValidate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.RegisterPassValidate.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegisterPassValidate.ForeColor = System.Drawing.Color.White;
            this.RegisterPassValidate.HintForeColor = System.Drawing.Color.White;
            this.RegisterPassValidate.HintText = "";
            this.RegisterPassValidate.isPassword = true;
            this.RegisterPassValidate.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.RegisterPassValidate.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.RegisterPassValidate.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.RegisterPassValidate.LineThickness = 4;
            this.RegisterPassValidate.Location = new System.Drawing.Point(98, 277);
            this.RegisterPassValidate.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.RegisterPassValidate.Name = "RegisterPassValidate";
            this.RegisterPassValidate.Size = new System.Drawing.Size(329, 43);
            this.RegisterPassValidate.TabIndex = 12;
            this.RegisterPassValidate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.RegisterPassValidate.Enter += new System.EventHandler(this.RegisterPassValidate_Enter);
            // 
            // bunifuCustomLabel6
            // 
            this.bunifuCustomLabel6.AutoSize = true;
            this.bunifuCustomLabel6.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel6.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bunifuCustomLabel6.Location = new System.Drawing.Point(94, 248);
            this.bunifuCustomLabel6.Name = "bunifuCustomLabel6";
            this.bunifuCustomLabel6.Size = new System.Drawing.Size(203, 24);
            this.bunifuCustomLabel6.TabIndex = 11;
            this.bunifuCustomLabel6.Text = "Підтвердіть пароль";
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.AutoSize = true;
            this.bunifuCustomLabel5.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel5.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(392, 19);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(125, 24);
            this.bunifuCustomLabel5.TabIndex = 10;
            this.bunifuCustomLabel5.Text = "Реєстрація";
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(94, 70);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(63, 24);
            this.bunifuCustomLabel3.TabIndex = 7;
            this.bunifuCustomLabel3.Text = "Логін";
            // 
            // RegisterLogin
            // 
            this.RegisterLogin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.RegisterLogin.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegisterLogin.ForeColor = System.Drawing.Color.White;
            this.RegisterLogin.HintForeColor = System.Drawing.Color.White;
            this.RegisterLogin.HintText = "";
            this.RegisterLogin.isPassword = false;
            this.RegisterLogin.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.RegisterLogin.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.RegisterLogin.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.RegisterLogin.LineThickness = 4;
            this.RegisterLogin.Location = new System.Drawing.Point(98, 99);
            this.RegisterLogin.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.RegisterLogin.Name = "RegisterLogin";
            this.RegisterLogin.Size = new System.Drawing.Size(328, 43);
            this.RegisterLogin.TabIndex = 8;
            this.RegisterLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(94, 159);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(88, 24);
            this.bunifuCustomLabel4.TabIndex = 8;
            this.bunifuCustomLabel4.Text = "Пароль";
            // 
            // RegisterPass
            // 
            this.RegisterPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.RegisterPass.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegisterPass.ForeColor = System.Drawing.Color.White;
            this.RegisterPass.HintForeColor = System.Drawing.Color.White;
            this.RegisterPass.HintText = "";
            this.RegisterPass.isPassword = true;
            this.RegisterPass.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.RegisterPass.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.RegisterPass.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.RegisterPass.LineThickness = 4;
            this.RegisterPass.Location = new System.Drawing.Point(98, 188);
            this.RegisterPass.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.RegisterPass.Name = "RegisterPass";
            this.RegisterPass.Size = new System.Drawing.Size(329, 43);
            this.RegisterPass.TabIndex = 9;
            this.RegisterPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.RegisterPass.Enter += new System.EventHandler(this.RegisterPass_Enter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(312, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(376, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // loginCloseButton
            // 
            this.loginCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(34)))), ((int)(((byte)(56)))));
            this.loginCloseButton.Image = ((System.Drawing.Image)(resources.GetObject("loginCloseButton.Image")));
            this.loginCloseButton.ImageActive = ((System.Drawing.Image)(resources.GetObject("loginCloseButton.ImageActive")));
            this.loginCloseButton.Location = new System.Drawing.Point(973, 2);
            this.loginCloseButton.Name = "loginCloseButton";
            this.loginCloseButton.Size = new System.Drawing.Size(25, 25);
            this.loginCloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loginCloseButton.TabIndex = 0;
            this.loginCloseButton.TabStop = false;
            this.loginCloseButton.Zoom = 0;
            this.loginCloseButton.Click += new System.EventHandler(this.loginCloseButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(34)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.RegistrationButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.loginCloseButton);
            this.Controls.Add(this.LoginPanel);
            this.Controls.Add(this.RegistrationPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CineMax Tickets";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.RegistrationPanel.ResumeLayout(false);
            this.RegistrationPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginCloseButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuImageButton loginCloseButton;
        private Bunifu.Framework.UI.BunifuMaterialTextbox loginTextbox;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox passwordTextbox;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuThinButton2 loginButton;
        private Bunifu.Framework.UI.BunifuCustomLabel loginAlert;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuFlatButton RegistrationButton;
        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.Panel RegistrationPanel;
        private Bunifu.Framework.UI.BunifuThinButton2 RegisterButton;
        private Bunifu.Framework.UI.BunifuMaterialTextbox CodeWord;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel8;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel7;
        private Bunifu.Framework.UI.BunifuMaterialTextbox RegisterPassValidate;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel6;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel5;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuMaterialTextbox RegisterLogin;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
        private Bunifu.Framework.UI.BunifuMaterialTextbox RegisterPass;
        private Bunifu.Framework.UI.BunifuFlatButton ReturnToLoginButton;
        private Bunifu.Framework.UI.BunifuMaterialTextbox RegisterPosition;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel9;
        private Bunifu.Framework.UI.BunifuCustomLabel RegisterErrorAlert;
        private MetroFramework.Controls.MetroComboBox CityDropdownList;
    }
}

