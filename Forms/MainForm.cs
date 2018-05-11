using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Forms;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.IO;
using Graduation_Work.Classes;
using System.Threading;
using Graduation_Work.Forms;

namespace Graduation_Work.Forms
{
    public partial class MainForm : MetroForm
    {
        private class Inf
        {
            private string _nameFile;
            private DateTime _lastWriteTime;
            private long _sizeFile;
            private string _typeFile;
            private byte[] _icoFile;
            private string _fullPath;
            public Inf(string nameFile, DateTime lastWriteTime, long sizeFile, string typeFile, byte[] icoFile, string fullPath)
            {
                this._nameFile = nameFile;
                this._lastWriteTime = lastWriteTime;
                this._sizeFile = sizeFile;
                this._typeFile = typeFile;
                this._icoFile = icoFile;
                this._fullPath = fullPath;
            }
            public string NameFile
            {
                get { return this._nameFile; }
                set { this._nameFile = value; }
            }
            public DateTime LastWriteTime
            {
                get { return this._lastWriteTime; }
                set { this._lastWriteTime = value; }
            }
            public long SizeFile
            {
                get { return this._sizeFile; }
                set { this._sizeFile = value; }
            }
            public string TypeFile
            {
                get { return this._typeFile; }
                set { this._typeFile = value; }
            }
            public byte[] IcoFile
            {
                get { return this._icoFile; }
                set { this._icoFile = value; }
            }
            public string FullPath
            {
                get { return this._fullPath; }
                set { this._fullPath = value; }
            }
        }
        public const int sizeBuffer = 20971520;
        private int currentPositionInList;
        private List<string> listSteps;
        private string currentDirectory;
        private List<string> currentElementForDelete;
        private string fileForDownload = null;
        public MainForm()
        {
            this.listSteps = new List<string>();
            this.currentPositionInList = -1;
            this.currentDirectory = default(string);
            this.currentElementForDelete = new List<string>();

            //Створення елементів на формі
            InitializeComponent();

            //Кругла форма елемента
            System.Drawing.Drawing2D.GraphicsPath gPath = new System.Drawing.Drawing2D.GraphicsPath();
            gPath.AddEllipse(0, 0, this.backBtn.Width, this.backBtn.Height);
            this.backBtn.Region = new Region(gPath);

            //Трикутна форма елемента
            //System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            //Point[] p = new Point[3];
            //p[0] = new Point(this.backBtn.Width >> 1, 0);
            //p[1] = new Point(0, this.backBtn.Height);
            //p[2] = new Point(this.backBtn.Width, this.backBtn.Height);
            //path.AddPolygon(p);
            //Region region = new Region(path);
            //this.backBtn.Region = region;

            nameUser.Text = LoginForm.user.Name;
        }
        //Loading form
        private void MainForm_Load(object sender, EventArgs e)
        {
            GetInfoDirectories();


            string dataFromServerList = GetInfoFiles(port: 2000);
            if (dataFromServerList == null)
                return;
            List<Inf> dataLocalList = JsonConvert.DeserializeObject<List<Inf>>(dataFromServerList);
            PopulateListView(listView, dataLocalList);
        }
        private void GetInfoDirectories()
        {
            treeView.Nodes.Clear();
            string dataFromServerTree = GetInfoFiles(port: 1999);
            if (dataFromServerTree == null)
                return;
            List<string> dataLocalTree = JsonConvert.DeserializeObject<List<string>>(dataFromServerTree);
            PopulateTreeView(treeView, dataLocalTree, '\\');
        }
        // On Click TreeView
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            GetListItemsFromServer(e.Node.FullPath);
            listSteps.Add(e.Node.FullPath);
            currentPositionInList++;
            currentDirectory = e.Node.FullPath;
        }
        private void rdoLarge_CheckedChanged(object sender, EventArgs e)
        {
            listView.View = View.LargeIcon;
        }
        private void rdoSmall_CheckedChanged(object sender, EventArgs e)
        {
            listView.View = View.SmallIcon;
        }
        private void rdoDetails_CheckedChanged(object sender, EventArgs e)
        {
            listView.View = View.Details;
        }
        private void rdoList_CheckedChanged(object sender, EventArgs e)
        {
            //imageList.ImageSize = new Size(16, 16);
            listView.View = View.List;
        }
        private void rdoTile_CheckedChanged(object sender, EventArgs e)
        {
            listView.View = View.Tile;
        }
        private void скачатиФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileWindow.FileName = this.GetFileName(fileForDownload);

            DialogResult result = saveFileWindow.ShowDialog();
            if (result == DialogResult.Cancel)
                return;

            InfoFileNew infoFile = new InfoFileNew();
            infoFile._path = fileForDownload;
            //else get and save file from server 
            new Task(() =>
            {
                Task setTextStatus = new Task(() =>
                {
                    for (; ; )
                    {
                        statusLable.Text = "Отримання файлу";
                        for (int i = 0; i < 3; i++)
                        {
                            statusLable.Text += ".";
                            Thread.Sleep(500);
                        }
                    }
                });
                setTextStatus.Start();
                byte[] file = GetInfoAboutFileFromServer(infoFile, 2004);
                File.WriteAllBytes(saveFileWindow.FileName, file);
                setTextStatus.Dispose();

            }).Start();

        }
        private async void завантажитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            InfoFileNew infoFile = new InfoFileNew();
            byte[] result;
            if (this.openFileWindow.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileWindow.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            result = new byte[myStream.Length];
                            await myStream.ReadAsync(result, 0, (int)myStream.Length);
                            infoFile._fileName = Path.GetFileName(this.openFileWindow.FileName); 
                            infoFile._path = currentDirectory;
                            infoFile._sizeFile = myStream.Length;
                            if (myStream != null)
                                myStream.Close();

                            //MessageBox.Show(sendData.ToList().Count.ToString());
                            SendInfoAboutFileToServer(infoFile, result, 2003);
                            //string tmpPath = Encoding.UTF8.GetString(itemsSelected[i].Tag as byte[]);
                            Thread.Sleep(40);

                            GetListItemsFromServer(currentDirectory);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. \nOriginal error: " + ex.Message);
                    if (myStream != null)
                        myStream.Close();
                }
            }
        }
        //Method Get Info Files or directories
        static string GetInfoFiles(int port)
        {
            return GetInfoFiles(null, port);
        }
        //Method Get Info Files or directories
        static string GetInfoFiles(string path, int port)
        {
            // Буфер для входящих данных
            byte[] bytes = new byte[20971520];

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
                if (!string.IsNullOrEmpty(path))
                    sender.Send(Encoding.UTF8.GetBytes(path));

                // Получаем ответ от сервера
                int bytesRec = sender.Receive(bytes);

                string receiveData = String.Format("{0}", Encoding.UTF8.GetString(bytes, 0, bytesRec));


                // Используем рекурсию для неоднократного вызова SendMessageFromSocket()
                //if (message.IndexOf("<TheEnd>") == -1)
                //  SendMessageFromSocket(port);

                // Освобождаем сокет
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
                return receiveData;
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Не має підключення до сервера!\n{ex.Message}", "Попередження!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        //Method Send Files to Server
        static void SendInfoAboutFileToServer(InfoFileNew infoAboutFile, byte[] result, int port = 2003)
        {
            // Соединяемся с удаленным устройством

            // Устанавливаем удаленную точку для сокета
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

            ////UdpClient sender = new UdpClient();
            //// Поля, связанные с UdpClient
            //IPAddress remoteIPAddress = IPAddress.Parse("127.0.0.1");
            //UdpClient sender = new UdpClient();
            //IPEndPoint ipEndPoint = new IPEndPoint(remoteIPAddress, port);

            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Соединяем сокет с удаленной точкой
            try
            {
                sender.Connect(ipEndPoint);

                Byte[] bytes = infoAboutFile.PackToXml();

                //Console.WriteLine("Отправка деталей файла...");

                // Отправляем информацию о файле
                sender.Send(bytes);

                Thread.Sleep(2000);

                sender.Send(result);
                // Освобождаем сокет
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Не має підключення до сервера!\n{ex.Message}", "Попередження!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //Method Send Files to Server
        static byte[] GetInfoAboutFileFromServer(InfoFileNew path, int port)
        {
            // Соединяемся с удаленным устройством

            // Устанавливаем удаленную точку для сокета
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

            ////UdpClient sender = new UdpClient();
            //// Поля, связанные с UdpClient
            //IPAddress remoteIPAddress = IPAddress.Parse("127.0.0.1");
            //UdpClient sender = new UdpClient();
            //IPEndPoint ipEndPoint = new IPEndPoint(remoteIPAddress, port);

            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Соединяем сокет с удаленной точкой
            try
            {
                sender.Connect(ipEndPoint);

                sender.Send(path.PackToXml());
                byte[] receiveBytes = new byte[5000];

                int bytesRec = sender.Receive(receiveBytes);

                InfoFileNew infoFile = receiveBytes.UnpackFromXml<InfoFileNew>();


                byte[] receiveBytes1 = new byte[infoFile._sizeFile];

                int bytesRec1 = sender.Receive(receiveBytes1);

                // Освобождаем сокет
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();

                return receiveBytes1;
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Не має підключення до сервера!\n{ex.Message}", "Попередження!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        //Set TreeView elements
        private static void PopulateTreeView(TreeView treeView, IEnumerable<string> paths, char pathSeparator)
        {
            TreeNode lastNode = null;
            string subPathAgg;
            foreach (string path in paths)
            {
                //MessageBox.Show(path);
                subPathAgg = string.Empty;
                foreach (string subPath in path.Split(pathSeparator))
                {
                    subPathAgg += subPath + pathSeparator;

                    TreeNode[] nodes = treeView.Nodes.Find(subPathAgg, true);
                    if (nodes.Length == 0)
                        if (lastNode == null)
                            lastNode = treeView.Nodes.Add(subPathAgg, subPath);
                        else
                            lastNode = lastNode.Nodes.Add(subPathAgg, subPath);
                    else
                        lastNode = nodes[0];
                }
            }
        }
        //Set ListView elements
        private void PopulateListView(ListView listView, IEnumerable<Inf> dataLocalList)
        {
            int tag = 1;
            foreach (Inf item in dataLocalList)
            {
                ListViewItem viewItem = new ListViewItem(item.NameFile);
                Icon icon = null;
                using (MemoryStream ms = new MemoryStream(item.IcoFile))
                {
                    try
                    {
                        icon = new Icon(ms);
                    }
                    catch (Exception ex)
                    {
                        Bitmap bitmap = new Bitmap(imageList.Images[0]);
                        bitmap.SetResolution(72, 72);
                        icon = System.Drawing.Icon.FromHandle(bitmap.GetHicon());
                    }
                }
                imageList.Images.Add(icon);
                viewItem.ImageIndex = tag;
                item.FullPath = item.FullPath.Remove(0, "E:\\MyOneDrive\\".Length);
                viewItem.Tag = Encoding.UTF8.GetBytes(item.FullPath);
                viewItem.SubItems.Add(item.LastWriteTime.ToString());
                viewItem.SubItems.Add(item.TypeFile.ToString());
                viewItem.SubItems.Add(item.SizeFile.ToString() + " Kb");

                listView.Items.Add(viewItem);
                tag++;
            }
        }
        private void listView_DoubleClick(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection itemsSelected = listView.SelectedItems;
            for (int i = 0; i < itemsSelected.Count; i++)
            {
                string tmpPath = Encoding.UTF8.GetString(itemsSelected[i].Tag as byte[]);
                GetListItemsFromServer(tmpPath);
                listSteps.Add(tmpPath.Substring(0, tmpPath.LastIndexOf('\\')));
                currentPositionInList++;
                currentDirectory = tmpPath;
            }
        }
        private void GetListItemsFromServer(string endPath)
        {
            listView.Items.Clear();
            {
                Image tmpImage = imageList.Images[0];
                imageList.Images.Clear();
                imageList.Images.Add(tmpImage);
            }

            string dataFromServer = GetInfoFiles(String.Format("E:\\MyOneDrive\\{0}", endPath), 2000);
            if (dataFromServer == null)
                return;

            List<Inf> dataLocal = JsonConvert.DeserializeObject<List<Inf>>(dataFromServer);
            PopulateListView(listView, dataLocal);
        }
        private void backBtn_Click(object sender, EventArgs e)
        {
            if (currentPositionInList >= 0)
            {
                GetListItemsFromServer(listSteps[currentPositionInList]);
                currentPositionInList--;
            }
        }
        private void backBtn_MouseHover(object sender, EventArgs e)
        {
            this.backBtn.BackColor = Color.FromArgb(230, 230, 230);
        }
        private void backBtn_MouseLeave(object sender, EventArgs e)
        {
            this.backBtn.BackColor = Color.FromArgb(240, 240, 240);
        }
        private void створитиПапкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(currentDirectory);
            bool result = CreateOrDeleteTheDirectoryAtTheServer(currentDirectory, 2001);
            if (result)
            {
                //MessageBox.Show("Папку створено!", "Результат створення:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetListItemsFromServer(currentDirectory);
                GetInfoDirectories();
            }
            else
            {
                MessageBox.Show("Папку не створено!", "Результат створення:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Create The Directory Or Delete
        static bool CreateOrDeleteTheDirectoryAtTheServer(string path, int port = 2001)
        {
            // Буфер для входящих данных
            byte[] bytes = new byte[1024];

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

                if (!string.IsNullOrEmpty(path))
                    sender.Send(Encoding.UTF8.GetBytes(path));

                // Получаем ответ от сервера
                int bytesRec = sender.Receive(bytes);

                bool receiveData = BitConverter.ToBoolean(bytes, 0);

                // Освобождаем сокет
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
                return receiveData;
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Не має підключення до сервера!\n{ex.Message}", "Попередження!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private void видалитиПапкуАбоФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете видалити вибраний вами елемент?",
                "Попередження!",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                foreach (string currElementForDelete in this.currentElementForDelete)
                {
                    CreateOrDeleteTheDirectoryAtTheServer(currElementForDelete, port: 2002);
                }
                GetListItemsFromServer(currentDirectory);
                GetInfoDirectories();
            }
        }
        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            ListView.SelectedListViewItemCollection itemsSelected = listView.SelectedItems;
            for (int i = 0; i < itemsSelected.Count; i++)
            {
                string tmpPath = Encoding.UTF8.GetString(itemsSelected[i].Tag as byte[]);
                fileForDownload = tmpPath;
                this.currentElementForDelete.Add(tmpPath);
            }
            //MessageBox.Show(this.currentElementForDelete.ToString());
        }
        private void оновитиСписокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetListItemsFromServer(currentDirectory);
        }
        private string GetFileName(string fullName)
        {
            int lastSplit = fullName.LastIndexOf('\\') + 1;
            return fullName.Substring(lastSplit);
        }
        private void вийтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void вийтиЗАкаунтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
