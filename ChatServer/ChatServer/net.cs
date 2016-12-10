using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using ChatServer;
using ChatServer.Chat;
using System.Windows.Forms;

namespace ChatServer.Net
{
    class Header
    {
        MsgType sourcetype;
    }

    class Data
    {
        List<string> data;
    }
    enum MsgType
    {
        ACK_OK, ACK_ERROR, CONNECT, QUIT_SESSION, GET_TPOICS, LISTER_TOPICS, CREATE_TPOIC, JOIN_TOPIC, QUIT_TOPIC, POST_MEG, RECV_POST
    }
    abstract class TCPServer
    {
        Socket commSocket;
        public void startServer(int port) { }
        public void stopServer() { }

    }

    public class loginHandle
    {
        string msg;
        User user;
        public loginHandle(string msg, User user)
        {
            this.msg = msg;
            this.user = user;
        }
        public void response()
        {
            parserMessage();

            //MessageSend sendback = new MessageSend();
            //string feedback = "";
            //sendback.sendToClient(user, feedback);
        }
        public void parserMessage()
        {
            string[] msgString = msg.Split(',');
            string[] userInfo = msgString[1].Split('/');
            if (msgString[0] == "create")
            {
                createHandle(userInfo);
            }
            else
            {
                checkHandle(userInfo);
            }

        }
        public void createHandle(string[] userinfo)
        {
            MainServerForm.userlist.Add(this.user);
            string feedback = "Login;create,ok";
            user.Writer.Write(feedback);
            user.Writer.Flush();
        }
        public void checkHandle(string[] userinfo)
        {
            string feedback = "Login;check,ok";
            MessageBox.Show(feedback);
            user.Writer.Write(feedback);
            user.Writer.Flush();
          //  return MainServerForm.userlist.Contains(this.user);
        }


    }

    public class MessageSend
    {

        public MessageSend()
        {

        }
        public void sendToClient(User user, string msg)
        {
            try
            {
                user.Writer.Write(msg);
                user.Writer.Flush();
            }
            catch
            {
                //message send failed 
            }
        }
        public void sendToAllClient(User user, string msg)
        {

        }
    }
    public class topicHandle
    {
        public topicHandle()
        {

        }

        public void parserMessage()
        {

        }
        public void createTopic(string topic)
        {
            MainServerForm.topics.createTopic(topic);
        }
        public string getTopic()
        {
            string topics = "Topic;get,";

            List<string> topicslist = MainServerForm.topics.topicName;
            foreach (string topic in topicslist)
                topics += "/topic";

            return topics;
        }
    }
    public class talkHandle
    {
        public void talkToAllPeopleInChatRoom(User user, string msg)
        {
            //find all should be send 

            //call method send to all
        }
        public void parserTalkMessage(User targetUser, string msg)
        {
            string[] operation = msg.Split(',');
            string[] topicMsg = operation[1].Split('/');
            if (operation[0] == "groups")
            {
                //topic string 
                if (MainServerForm.topics.topicName.Contains(topicMsg[0]))
                {
                    talkToGroup(operation[1]);
                }
                else
                {
                    //can't find the topic
                }
                //find the chatroom by the topicMsg[0]
                

                //send message to all the users in the list 

            }
            else
            {
               //user name 
                foreach (User u in MainServerForm.userlist)
                {
                    if (u.userName == topicMsg[0])
                        talkToOne(u, topicMsg[1]);
                }
            }
        }
        public void talkToOne(User targetUser, string msg)
        {
            MessageSend send = new MessageSend();
            send.sendToClient(targetUser, msg);
        }
        public void talkToGroup(string msg)
        {
            string[] topicMsg = msg.Split('/');
            //topicmsge[0] means the topic name;
            ServerChatRoom chatroom = MainServerForm.topics.getCharRoomByTopic(topicMsg[0]);

            foreach (User groupUser in chatroom.userlist)
            {
                talkToOne(groupUser, topicMsg[1]);
            }
        }
    }

    public class logoutHandle
    {
        public void logout(User user)
        {
            //delete all users in the client and send message to all users 
        }
    }
}
