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
    public partial class RestorationOfPasswordForm : MetroForm
    {
        public RestorationOfPasswordForm()
        {
            InitializeComponent();
            nextBtn.Tag = 0;
        }

        private void backToFormLoginBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void RestorationOfPasswordForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (nextBtn.Tag != null && (int)nextBtn.Tag == 0)
            {
                if (!RegexUtilities.IsValidEmail(emailField.Text))
                {
                    return;
                }
                UserInformation userInfo = new UserInformation();
                userInfo.Email = emailField.Text;
                bool respons = SendRestorationPassword(userInfo);
                if (!respons)
                {
                    MessageBox.Show(
                        $"Користувача з таким email: {emailField.Text} не знайдено!",
                        "Попередження!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show(
                       $"Повідомленння було відправлено на email: {emailField.Text}",
                       "Інформація!",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information);

                    nextBtn.Tag = 1;
                    nextBtn.Text = "Відновити";
                    metroLabel2.Visible = true;
                    codeField.Visible = true;
                    metroLabel3.Visible = true;
                    passwordField1.Visible = true;
                    metroLabel4.Visible = true;
                    passwordField2.Visible = true;
                    emailField.Enabled = false;
                }
            }
            else if (nextBtn.Tag != null && (int)nextBtn.Tag == 1)
            {
                if (string.IsNullOrEmpty(codeField.Text) || codeField.Text.Length != 16)
                {
                    MessageBox.Show(
                      $"Довжина коду повинна складати 16 символів!",
                      "Попередження!",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(passwordField1.Text) || string.IsNullOrEmpty(passwordField2.Text))
                {
                    MessageBox.Show(
                      $"Поля повинні бути заповненими!",
                      "Попередження!",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Warning);
                    return;
                }
                if (passwordField1.Text.Length < 7)
                {
                    MessageBox.Show(
                      $"Довжина паролю повинна бути більше ніж 7 символів!",
                      "Попередження!",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Warning);
                    return;
                }
                if (passwordField1.Text != passwordField2.Text)
                {
                    MessageBox.Show(
                       $"Паролі не співпадають!",
                       "Попередження!",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Warning);
                    return;
                }
                UserInformation userInfo = new UserInformation();
                userInfo.Email = emailField.Text;
                userInfo.Password = passwordField1.Text;
                bool respons = SendRestorationPassword(userInfo, 2008);

                if (respons)
                {
                    this.Hide();
                    new MainForm().Show();
                }
                else
                {
                    MessageBox.Show(
                       $"Пароль не змінено!",
                       "Попередження!",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Warning);
                }

            }
        }

        private bool SendRestorationPassword(UserInformation userInfo, int port = 2007)
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


                sender.Send(userInfo.PackToXml());

                byte[] receiveBytes = new byte[5000];
                int bytesRec = sender.Receive(receiveBytes);

                UserInformation response = receiveBytes.UnpackFromXml<UserInformation>();

                // Освобождаем сокет
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();


                if (response != null)
                {
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
