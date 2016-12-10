using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatServer.Chat;
using ChatServer.util;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using ChatServer.Net;
using System.Text;

using System.IO;

namespace ChatServer
{
    public partial class MainServerForm : Form
    {

        private string ServerIPAddress;

        private int ServerPort;
        public static  List<User> userlist = new List<User>();

        public static Topic topics = new Topic();
        private TcpListener serverListener;

        bool isNormalExit = false;
        public MainServerForm()
        {
            InitializeComponent();
            stopServer.Enabled = false;
            consoleListBox.HorizontalScrollbar = true;
            SetServerIPAndPort();
        }
        private void SetServerIPAndPort()
        {
            FileStream fs = new FileStream("ServerIPAndPort.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string IPAndPort = sr.ReadLine();
            ServerIPAddress = IPAndPort.Split(':')[0]; //设定IP
            ServerPort = int.Parse(IPAndPort.Split(':')[1]); //设定端口
            sr.Close();
            fs.Close();

           
        }
        private void StartServer_Click(object sender, EventArgs e)
        {
            //this.startServer.Enabled = false;
            //this.stopServer.Enabled = true;

            //if (utilClass.checkIPAddress(IPAddressText.Text))
            //    this.ServerIPAddress = IPAddressText.Text;
            //else
            //{
            //    MessageBox.Show("wrong ip address");
            //}
            //if (utilClass.checkPort(PortNumber.Text))
            //{
            //    this.ServerPort = Convert.ToInt32(PortNumber.Text);
            //}
            //else
            //{
            //    MessageBox.Show("wrong ip address");
            //}
           // MessageBox.Show(this.IPAddressText.Text + this.PortNumber.Text);

            serverListener = new TcpListener(IPAddress.Parse(ServerIPAddress), ServerPort);
            serverListener.Start();
            AddItemToConsole(string.Format("开始在{0}:{1}监听客户连接", ServerIPAddress, ServerPort));
            Thread mythread = new Thread(ListernClientConnection);
            mythread.Start();

          
        }
        private void ListernClientConnection()
        {

            TcpClient newClient = null;

            while (true)
            {
                try
                {
                    newClient = this.serverListener.AcceptTcpClient();

                }
                catch
                {
                    //当单击‘停止监听’或者退出此窗体时 AcceptTcpClient() 会产生异常
                    //因此可以利用此异常退出循环
                    break;
                }
                //每接收一个客户端连接，就创建一个对应的线程循环接收该客户端发来的信息；

                User user = new User(newClient);
                Thread threadReceive = new Thread(ReceiveData);
                threadReceive.Start(user);
                userlist.Add(user);
                //AddItemToListBox(string.Format("[{0}]进入", newClient.Client.RemoteEndPoint));
                //AddItemToListBox(string.Format("当前连接用户数：{0}", userList.Count));
            }


        }

        private void ReceiveData(object userState)
        {
            User user = (User)userState;
          
            TcpClient client = user.userClient;
            while (isNormalExit == false)
            {
                string receiveString = null;
                try
                {
                    //从网络流中读出字符串，此方法会自动判断字符串长度前缀
                    receiveString = user.Reader.ReadString();
                }
                catch (Exception)
                {
                    if (isNormalExit == false)
                    {
                    //    AddItemToListBox(string.Format("与[{0}]失去联系，已终止接收该用户信息", client.Client.RemoteEndPoint));
                   //user need to be removed  beside the chatroom ,
                        //    RemoveUser(user);
                        
                    }
                    break;
                }
                AddItemToListBox(string.Format("来自[{0}]：{1}", user.userClient.Client.RemoteEndPoint, receiveString));
                string[] splitString = receiveString.Split(';');
                
                switch (splitString[0])
                {
                    case "Login":
                                        
                        loginHandle handle = new loginHandle(splitString[1], user);
                        handle.response();
                       
                        break;
                  
                    case "Talk"://check whether type of talk
                   //     string talkString = receiveString.Substring(splitString[0].Length + splitString[1].Length + 2);
                   //     AddItemToListBox(string.Format("{0}对{1}说：{2}", user.userName, splitString[1], talkString));
                   ////     SendToClient(user, "talk," + user.userName + "," + talkString);
                        talkHandle talk = new talkHandle();
                        string[] talktype = splitString[1].Split(',');
                        if (talktype[0] == "person")
                        {


                        }
                        foreach (User target in userlist)
                        {
                            if (target.userName == splitString[1] && user.userName != splitString[1])
                            {
                    //            SendToClient(target, "talk," + user.userName + "," + talkString);
                                break;
                            }
                        }
                        break;
                    case "Topic":

                        break;
                    case "Logout":

                        break;
                    default:
                        AddItemToListBox("什么意思啊：" + receiveString);
                        break;
                }
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void MainServerForm_Load(object sender, EventArgs e)
        {

        }

        private delegate void AddItemToConsoleDelegate(string str);
        public void AddItemToConsole(string str)
        {
            if (this.consoleListBox.InvokeRequired)
            {
                AddItemToConsoleDelegate d = AddItemToConsole;
                consoleListBox.Invoke(d, str);
            }
            else
            {
                consoleListBox.Items.Add(str);
                consoleListBox.SelectedIndex = consoleListBox.Items.Count - 1;
                consoleListBox.ClearSelected();
            }
        }
        private delegate void AddItemToListBoxDelegate(string str);
        /// <summary>
        /// 在ListBox中追加状态信息
        /// </summary>
        /// <param name="str">要追加的信息</param>
        private void AddItemToListBox(string str)
        {
            if (this.consoleListBox.InvokeRequired)
            {
                AddItemToListBoxDelegate d = AddItemToListBox;
                this.consoleListBox.Invoke(d, str);
            }
            else
            {
                this.consoleListBox.Items.Add(str);
                this.consoleListBox.SelectedIndex = this.consoleListBox.Items.Count - 1;
                this.consoleListBox.ClearSelected();
            }
        }

        private void stopServer_Click(object sender, EventArgs e)
        {
            AddItemToListBox("开始停止服务，并依次使用户退出！");
            isNormalExit = true;
            for (int i = MainServerForm.userlist.Count - 1; i >= 0; i--)
            {
                //    RemoveUser(userList[i]);
            }
            //通过停止监听让 myListener.AcceptTcpClient() 产生异常退出监听线程
            this.serverListener.Stop();
            this.startServer.Enabled = true;
            this.stopServer.Enabled = false;
        }

    }
}
