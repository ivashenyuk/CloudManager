namespace Graduation_Work.Forms
{
    partial class RegistrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.nameField = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.emailField = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.passwordField1 = new MetroFramework.Controls.MetroTextBox();
            this.passwordField2 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.registrationBtn = new MetroFramework.Controls.MetroButton();
            this.loginForm = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 92);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(68, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Ваше ім\'я";
            // 
            // nameField
            // 
            // 
            // 
            // 
            this.nameField.CustomButton.Image = null;
            this.nameField.CustomButton.Location = new System.Drawing.Point(356, 1);
            this.nameField.CustomButton.Name = "";
            this.nameField.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.nameField.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.nameField.CustomButton.TabIndex = 1;
            this.nameField.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.nameField.CustomButton.UseSelectable = true;
            this.nameField.CustomButton.Visible = false;
            this.nameField.Lines = new string[0];
            this.nameField.Location = new System.Drawing.Point(24, 114);
            this.nameField.MaxLength = 32767;
            this.nameField.Name = "nameField";
            this.nameField.PasswordChar = '\0';
            this.nameField.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.nameField.SelectedText = "";
            this.nameField.SelectionLength = 0;
            this.nameField.SelectionStart = 0;
            this.nameField.ShortcutsEnabled = true;
            this.nameField.Size = new System.Drawing.Size(378, 23);
            this.nameField.TabIndex = 1;
            this.nameField.UseSelectable = true;
            this.nameField.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.nameField.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(24, 144);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(41, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Email";
            // 
            // emailField
            // 
            // 
            // 
            // 
            this.emailField.CustomButton.Image = null;
            this.emailField.CustomButton.Location = new System.Drawing.Point(356, 1);
            this.emailField.CustomButton.Name = "";
            this.emailField.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.emailField.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.emailField.CustomButton.TabIndex = 1;
            this.emailField.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.emailField.CustomButton.UseSelectable = true;
            this.emailField.CustomButton.Visible = false;
            this.emailField.Lines = new string[0];
            this.emailField.Location = new System.Drawing.Point(24, 167);
            this.emailField.MaxLength = 32767;
            this.emailField.Name = "emailField";
            this.emailField.PasswordChar = '\0';
            this.emailField.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.emailField.SelectedText = "";
            this.emailField.SelectionLength = 0;
            this.emailField.SelectionStart = 0;
            this.emailField.ShortcutsEnabled = true;
            this.emailField.Size = new System.Drawing.Size(378, 23);
            this.emailField.TabIndex = 3;
            this.emailField.UseSelectable = true;
            this.emailField.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.emailField.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(24, 197);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(54, 19);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "Пароль";
            // 
            // passwordField1
            // 
            // 
            // 
            // 
            this.passwordField1.CustomButton.Image = null;
            this.passwordField1.CustomButton.Location = new System.Drawing.Point(356, 1);
            this.passwordField1.CustomButton.Name = "";
            this.passwordField1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.passwordField1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.passwordField1.CustomButton.TabIndex = 1;
            this.passwordField1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.passwordField1.CustomButton.UseSelectable = true;
            this.passwordField1.CustomButton.Visible = false;
            this.passwordField1.Lines = new string[0];
            this.passwordField1.Location = new System.Drawing.Point(24, 220);
            this.passwordField1.MaxLength = 32767;
            this.passwordField1.Name = "passwordField1";
            this.passwordField1.PasswordChar = '*';
            this.passwordField1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passwordField1.SelectedText = "";
            this.passwordField1.SelectionLength = 0;
            this.passwordField1.SelectionStart = 0;
            this.passwordField1.ShortcutsEnabled = true;
            this.passwordField1.Size = new System.Drawing.Size(378, 23);
            this.passwordField1.TabIndex = 5;
            this.passwordField1.UseSelectable = true;
            this.passwordField1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.passwordField1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // passwordField2
            // 
            // 
            // 
            // 
            this.passwordField2.CustomButton.Image = null;
            this.passwordField2.CustomButton.Location = new System.Drawing.Point(356, 1);
            this.passwordField2.CustomButton.Name = "";
            this.passwordField2.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.passwordField2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.passwordField2.CustomButton.TabIndex = 1;
            this.passwordField2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.passwordField2.CustomButton.UseSelectable = true;
            this.passwordField2.CustomButton.Visible = false;
            this.passwordField2.Lines = new string[0];
            this.passwordField2.Location = new System.Drawing.Point(24, 269);
            this.passwordField2.MaxLength = 32767;
            this.passwordField2.Name = "passwordField2";
            this.passwordField2.PasswordChar = '*';
            this.passwordField2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passwordField2.SelectedText = "";
            this.passwordField2.SelectionLength = 0;
            this.passwordField2.SelectionStart = 0;
            this.passwordField2.ShortcutsEnabled = true;
            this.passwordField2.Size = new System.Drawing.Size(378, 23);
            this.passwordField2.TabIndex = 7;
            this.passwordField2.UseSelectable = true;
            this.passwordField2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.passwordField2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(24, 246);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(101, 19);
            this.metroLabel4.TabIndex = 6;
            this.metroLabel4.Text = "Пароль ще раз";
            // 
            // registrationBtn
            // 
            this.registrationBtn.Location = new System.Drawing.Point(296, 308);
            this.registrationBtn.Name = "registrationBtn";
            this.registrationBtn.Size = new System.Drawing.Size(106, 31);
            this.registrationBtn.TabIndex = 8;
            this.registrationBtn.Text = "Зареєструватися";
            this.registrationBtn.UseSelectable = true;
            this.registrationBtn.Click += new System.EventHandler(this.registrationBtn_Click);
            // 
            // loginForm
            // 
            this.loginForm.AutoSize = true;
            this.loginForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginForm.Location = new System.Drawing.Point(23, 320);
            this.loginForm.Name = "loginForm";
            this.loginForm.Size = new System.Drawing.Size(163, 19);
            this.loginForm.TabIndex = 9;
            this.loginForm.Text = "Ввійти в існуючий акаунт";
            this.loginForm.Click += new System.EventHandler(this.loginForm_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 357);
            this.Controls.Add(this.loginForm);
            this.Controls.Add(this.registrationBtn);
            this.Controls.Add(this.passwordField2);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.passwordField1);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.emailField);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.nameField);
            this.Controls.Add(this.metroLabel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(425, 357);
            this.MinimumSize = new System.Drawing.Size(425, 357);
            this.Name = "RegistrationForm";
            this.Text = "Registration Form";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegistrationForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox nameField;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox emailField;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox passwordField1;
        private MetroFramework.Controls.MetroTextBox passwordField2;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroButton registrationBtn;
        private MetroFramework.Controls.MetroLabel loginForm;
    }
}