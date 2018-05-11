using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Components;
using Graduation_Work.Classes;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;

namespace Graduation_Work.Forms
{
    public partial class LoginForm : MetroForm
    {
        public static UserInformation user = new UserInformation();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            const string cond = @"(\w + ([-+.]\w +)*@\w + ([-.]\w +)*\.\w + ([-.]\w +)*)";
            if (!RegexUtilities.IsValidEmail(emailField.Text))
            {
                return;
            }
            if (string.IsNullOrEmpty(passwordField.Text) || passwordField.Text.Length < 7)
            {
                return;
            }

            user.Email = emailField.Text;
            user.Password = passwordField.Text;
            user.Name = "";

            byte[] userInfo = user.PackToXml();

            if (SendLogin(userInfo))
            {
                this.Hide();
                new MainForm().Show();
            }
        }

        private bool SendLogin(byte[] userInfo, int port = 2005)
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
                    user = response;
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

        private void registrationBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RegistrationForm().Show();
        }

        private void restorationBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RestorationOfPasswordForm().Show();
        }
    }
}
