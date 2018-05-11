namespace Graduation_Work.Forms
{
    partial class LoginForm
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
            this.emailField = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.passwordField = new MetroFramework.Controls.MetroTextBox();
            this.loginBtn = new MetroFramework.Controls.MetroButton();
            this.registrationBtn = new MetroFramework.Controls.MetroLabel();
            this.restorationBtn = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // emailField
            // 
            // 
            // 
            // 
            this.emailField.CustomButton.Image = null;
            this.emailField.CustomButton.Location = new System.Drawing.Point(295, 1);
            this.emailField.CustomButton.Name = "";
            this.emailField.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.emailField.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.emailField.CustomButton.TabIndex = 1;
            this.emailField.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.emailField.CustomButton.UseSelectable = true;
            this.emailField.CustomButton.Visible = false;
            this.emailField.Lines = new string[0];
            this.emailField.Location = new System.Drawing.Point(23, 115);
            this.emailField.MaxLength = 32767;
            this.emailField.Name = "emailField";
            this.emailField.PasswordChar = '\0';
            this.emailField.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.emailField.SelectedText = "";
            this.emailField.SelectionLength = 0;
            this.emailField.SelectionStart = 0;
            this.emailField.ShortcutsEnabled = true;
            this.emailField.Size = new System.Drawing.Size(317, 23);
            this.emailField.TabIndex = 0;
            this.emailField.UseSelectable = true;
            this.emailField.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.emailField.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(24, 90);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(41, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Email";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(24, 145);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(54, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Пароль";
            // 
            // passwordField
            // 
            // 
            // 
            // 
            this.passwordField.CustomButton.Image = null;
            this.passwordField.CustomButton.Location = new System.Drawing.Point(294, 1);
            this.passwordField.CustomButton.Name = "";
            this.passwordField.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.passwordField.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.passwordField.CustomButton.TabIndex = 1;
            this.passwordField.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.passwordField.CustomButton.UseSelectable = true;
            this.passwordField.CustomButton.Visible = false;
            this.passwordField.Lines = new string[0];
            this.passwordField.Location = new System.Drawing.Point(24, 168);
            this.passwordField.MaxLength = 32767;
            this.passwordField.Name = "passwordField";
            this.passwordField.PasswordChar = '*';
            this.passwordField.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passwordField.SelectedText = "";
            this.passwordField.SelectionLength = 0;
            this.passwordField.SelectionStart = 0;
            this.passwordField.ShortcutsEnabled = true;
            this.passwordField.Size = new System.Drawing.Size(316, 23);
            this.passwordField.TabIndex = 3;
            this.passwordField.UseSelectable = true;
            this.passwordField.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.passwordField.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(265, 210);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(75, 23);
            this.loginBtn.TabIndex = 4;
            this.loginBtn.Text = "Вхід";
            this.loginBtn.UseSelectable = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // registrationBtn
            // 
            this.registrationBtn.AutoSize = true;
            this.registrationBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registrationBtn.Location = new System.Drawing.Point(24, 213);
            this.registrationBtn.Name = "registrationBtn";
            this.registrationBtn.Size = new System.Drawing.Size(74, 19);
            this.registrationBtn.TabIndex = 5;
            this.registrationBtn.Text = "Реєстрація";
            this.registrationBtn.Click += new System.EventHandler(this.registrationBtn_Click);
            // 
            // restorationBtn
            // 
            this.restorationBtn.AutoSize = true;
            this.restorationBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.restorationBtn.Location = new System.Drawing.Point(105, 213);
            this.restorationBtn.Name = "restorationBtn";
            this.restorationBtn.Size = new System.Drawing.Size(106, 19);
            this.restorationBtn.TabIndex = 6;
            this.restorationBtn.Text = "Забули пароль?";
            this.restorationBtn.Click += new System.EventHandler(this.restorationBtn_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 259);
            this.Controls.Add(this.restorationBtn);
            this.Controls.Add(this.registrationBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.passwordField);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.emailField);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(363, 259);
            this.MinimumSize = new System.Drawing.Size(363, 259);
            this.Name = "LoginForm";
            this.Text = "Login Form";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox emailField;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox passwordField;
        private MetroFramework.Controls.MetroButton loginBtn;
        private MetroFramework.Controls.MetroLabel registrationBtn;
        private MetroFramework.Controls.MetroLabel restorationBtn;
    }
}