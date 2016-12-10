using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Threading;


namespace ChatClient
{
    public partial class login : Form
    {

        private string ServerIP; //IP
        private int port;   //端口
        private bool isExit = false;
        private TcpClient client;
        private BinaryReader br;
        private BinaryWriter bw;

        public login()
        {
            InitializeComponent();
            this.SetServerIPAndPort();
        }

       
        private void SetServerIPAndPort()
        {
            try
            {
                FileStream fs = new FileStream("ServerIPAndPort.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string IPAndPort = sr.ReadLine();
                ServerIP = IPAndPort.Split(':')[0]; //设定IP
                port = int.Parse(IPAndPort.Split(':')[1]); //设定端口
                sr.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("配置IP与端口失败，错误原因：" + ex.Message);
                Application.Exit();
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string userName = this.userName.Text;
            string password = this.passwd.Text;
          

            try
            {
                //此处为方便演示，实际使用时要将Dns.GetHostName()改为服务器域名
                //IPAddress ipAd = IPAddress.Parse("182.150.193.7");
                client = new TcpClient();
                client.Connect(IPAddress.Parse(ServerIP), port);
           //     AddTalkMessage("连接成功");
            }
            catch (Exception ex)
            {
           //     AddTalkMessage("连接失败，原因：" + ex.Message);
                this.loginButton.Enabled = true;
                return;
            }
            //获取网络流
            NetworkStream networkStream = client.GetStream();
            //将网络流作为二进制读写对象
            br = new BinaryReader(networkStream);
            bw = new BinaryWriter(networkStream);
            string loginInfo = "Login;check," + this.userName.Text + "/" + this.passwd.Text;
          
            bw.Write(loginInfo);
            bw.Flush();
          
        //    SendMessage("Login," + txt_UserName.Text);
           Thread threadReceive = new Thread(new ThreadStart(ReceiveData));
             threadReceive.IsBackground = true;
             threadReceive.Start();

        }




        private void ReceiveData()
        {
            string receiveString = null;
            while (isExit == false)
            {
                try
                {
                    //从网络流中读出字符串
                    //此方法会自动判断字符串长度前缀，并根据长度前缀读出字符串
                    receiveString = br.ReadString();
                }
                catch
                {
                    if (isExit == false)
                    {
                        MessageBox.Show("与服务器失去连接");
                    }
                    break;
                }
               
                string[] splitString = receiveString.Split(';');
                string command = splitString[0];
                switch (command)
                {
                    case "Login":   //格式： login,用户名
                 //       AddOnline(splitString[1]);
                        string status = receiveString.Split(',')[1];
                        if(status=="ok")
                        {
                            var chatFrame = new ChatForm();
                            Application.Exit();
                           //  chatFrame.Show();
                             this.Close();
                       
                        }
                        break;
                    case "logout":  //格式： logout,用户名
                  //      RemoveUserName(splitString[1]);
                        break;
                    case "talk":    //格式： talk,用户名,对话信息
                 //       AddTalkMessage(splitString[1] + "：\r\n");
                  //      AddTalkMessage(receiveString.Substring(splitString[0].Length + splitString[1].Length + 2));
                        break;
                    default:
                   //     AddTalkMessage("什么意思啊：" + receiveString);
                        break;
                }
            }
            Application.Exit();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            var registerForm = new register();
            registerForm.Show();
        }
    }
}
