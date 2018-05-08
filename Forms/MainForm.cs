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

namespace Graduation_Work
{
    public partial class MainForm : MetroForm
    {
        class Inf
        {
            private string _nameFile;
            private DateTime _lastWriteTime;
            private long _sizeFile;
            private string _typeFile;
            private byte[] _icoFile;

            public Inf(string nameFile, DateTime lastWriteTime, long sizeFile, string typeFile, byte[] icoFile)
            {
                this._nameFile = nameFile;
                this._lastWriteTime = lastWriteTime;
                this._sizeFile = sizeFile;
                this._typeFile = typeFile;
                this._icoFile = icoFile;
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
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string dataFromServerTree = GetInfoFiles(port: 1999);
            if (dataFromServerTree == null)
                return;
            List<string> dataLocalTree = JsonConvert.DeserializeObject<List<string>>(dataFromServerTree);
            PopulateTreeView(treeView, dataLocalTree, '\\');


            string dataFromServerList = GetInfoFiles(port: 2000);
            if (dataFromServerList == null)
                return;
            List<Inf> dataLocalList = JsonConvert.DeserializeObject<List<Inf>>(dataFromServerList);
            PopulateListView(listView, dataLocalList);
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listView.Items.Clear();
            //for(int i =0; i < imageList.Images.Count; i++)
            
            {
                Image tmpImage = imageList.Images[0];
                imageList.Images.Clear();
                imageList.Images.Add(tmpImage);
            }
            //MessageBox.Show(String.Format("E:\\MyOneDrive\\{0}",e.Node.FullPath));

            string dataFromServer = GetInfoFiles(String.Format("E:\\MyOneDrive\\{0}", e.Node.FullPath), 2000);
            if (dataFromServer == null)
                return;

            //MessageBox.Show(dataFromServer);
            List<Inf> dataLocal = JsonConvert.DeserializeObject<List<Inf>>(dataFromServer);

            PopulateListView(listView, dataLocal);
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
            listView.View = View.List;
        }

        private void rdoTile_CheckedChanged(object sender, EventArgs e)
        {
            listView.View = View.Tile;
        }

        private void скачатиФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private async void завантажитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            byte[] result;

            if (openFileWindow.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileWindow.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            result = new byte[myStream.Length];
                            await myStream.ReadAsync(result, 0, (int)myStream.Length);

                            MessageBox.Show(result.GetValue(0).ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);

                }
            }
        }

        //Function Get Info Files or directories
        static string GetInfoFiles(int port)
        {
            return GetInfoFiles(null, port);
        }
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
        //Function Get Info Files or directories
        static void SendFileToServer(byte[] data, int port)
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

                int byteSend = sender.Send(data);

                // Освобождаем сокет
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Не має підключення до сервера!\n{ex.Message}", "Попередження!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
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
        private void PopulateListView(ListView listView, IEnumerable<Inf> dataLocalList)
        {
            int tag = 1;
            foreach (Inf item in dataLocalList)
            {
                ListViewItem viewItem = new ListViewItem(item.NameFile);
                // MessageBox.Show(item.LastWriteTime.ToString());
                Icon icon = null;
                using (MemoryStream ms = new MemoryStream(item.IcoFile))
                {
                    try
                    {
                        icon = new Icon(ms);
                    } catch (Exception ex)
                    {
                        Bitmap bitmap = new Bitmap(imageList.Images[0]);
                        bitmap.SetResolution(72, 72);
                        icon = System.Drawing.Icon.FromHandle(bitmap.GetHicon());
                        //icon = (Icon)imageList.Images[0];
                    }
                }
                imageList.Images.Add(icon);
                viewItem.ImageIndex = tag;
                viewItem.SubItems.Add(item.LastWriteTime.ToString());
                viewItem.SubItems.Add(item.TypeFile.ToString());
                viewItem.SubItems.Add(item.SizeFile.ToString() + " Kb");

                listView.Items.Add(viewItem);
                tag++;
            }
        }
        
    }
}
