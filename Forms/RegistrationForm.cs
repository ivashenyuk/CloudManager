using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Graduation_Work.Classes;
using MetroFramework.Forms;

namespace Graduation_Work.Forms
{
    public partial class RegistrationForm : MetroForm
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void loginForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void registrationBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameField.Text) || nameField.Text.Length < 6)
            {
                return;
            }
            if (!RegexUtilities.IsValidEmail(emailField.Text))
            {
                return;
            }
            if (string.IsNullOrEmpty(passwordField1.Text) || string.IsNullOrEmpty(passwordField2.Text))
            {
                return;
            }
            if (passwordField1.Text.Length < 7 || passwordField2.Text.Length < 7)
            {
                return;
            }
            if (passwordField1.Text != passwordField2.Text)
            {
                return;
            }

            LoginForm.user = new UserInformation();
            LoginForm.user.Name = nameField.Text;
            LoginForm.user.Email = emailField.Text;
            LoginForm.user.Password = passwordField1.Text;

            byte[] userInfo = LoginForm.user.PackToXml();

            if (SendRegistration(userInfo))
            {
                this.Hide();
                new MainForm().Show();
            }
        }

        private bool SendRegistration(byte[] userInfo, int port=2006)
        {
            // Соединяемся с удаленным устройством

            // Устанавливаем удаленную точку для сокета
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Соединяем сокет с удаленной точкой
            try
            {
                sender.Connect(ipEndPoint);

                sender.Send(userInfo);

                byte[] receiveBytes = new byte[5000];
                int bytesRec = sender.Receive(receiveBytes);

                UserInformation response = receiveBytes.UnpackFromXml<UserInformation>();

                // Освобождаем сокет
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();

                if (response != null)
                {
                    LoginForm.user = response;
                    return true;
                }
                else return false;
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Не має підключення до сервера!\n{ex.Message}", "Попередження!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
    }
}
