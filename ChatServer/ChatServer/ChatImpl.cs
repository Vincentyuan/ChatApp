using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Net.Sockets;
using System.IO;

namespace ChatServer.Chat
{
    public class User : Chatter
    {
        string _userName;
        string _nickName;
        string _password;
        TcpClient _userClient;
        BinaryReader _reader;
        BinaryWriter _writer;

        public User(TcpClient client)
        {
            userClient = client;
        }
        public string userName
        {
            get
            {
                return this._userName;
            }
            set
            {
                this._userName = value;
            }

        }
        public string nickName
        {
            get { return _nickName; }
            set { this._nickName = value; }
        }
        public string password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
            }
        }
        public TcpClient userClient
        {
            get
            {
                return this._userClient;
            }
            set
            {
                this._userClient = value;
                NetworkStream networkstream = value.GetStream();
                this._reader = new BinaryReader(networkstream);
                this._writer = new BinaryWriter(networkstream);

            }
        }
        public BinaryReader Reader
        {
            get { return this._reader; }
        }
        public BinaryWriter Writer
        {
            get { return this._writer; }
        }

        //send message to exactly chatter.
        public void receiveMessage(string msg, Chatter chatter)
        {

            throw new NotImplementedException();
        }

         public  void getNickName(string id)
        {
            throw new NotImplementedException();
        }
    }


    public class Topic : topicManage
    {
        List<string> _topicName;
        List<ServerChatRoom> _chatRoom;

        public List<string> topicName
        {
            get { return this._topicName; }
            set { this._topicName = value; }
        }
        

        public List<string> listTopics()
        {
            return this._topicName;
            throw new NotImplementedException();
        }

        public void createTopic(string topic)
        {
            this._topicName.Add(topic);
            this._chatRoom.Add(new ServerChatRoom());
            throw new NotImplementedException();
        }

        public ServerChatRoom getCharRoomByTopic(string topic)
        {
            if (_topicName.Contains(topic))
            {
                for(int i=0;i<_topicName.Count;i++)
                {
                    if (_topicName[i] == topic)
                        return _chatRoom[i];
                }
            }
            else
                return null;
            throw new NotImplementedException();
        }


        ChatRoom topicManage.getCharRoomByTopic(string topic)
        {
            throw new NotImplementedException();
        }
    }

    public class ServerChatRoom : ChatRoom
    {
        TcpClient _serverClient;
        BinaryReader _reader;
        BinaryWriter _writer;
        string _topic;
        List<User> _userlist;

        public TcpClient serverClient
        {
            get { return this._serverClient; }
            set
            {
                NetworkStream networkstream = value.GetStream();
                this._reader = new BinaryReader(networkstream);
                this._writer = new BinaryWriter(networkstream);

            }
        }
        public BinaryReader Reader
        {
            get { return this._reader; }
        }
        public BinaryWriter Writer
        {
            get { return this._writer; }
        }
        public string topic
        {
            get { return _topic; }
            set { this._topic = topic; }
        }
        public List<User> userlist
        {
            get { return _userlist; }
            set { this._userlist = value; } 
        }
        
        public void poster(string msg, Chatter chatter)
        {
            foreach(User user in _userlist)
            {
                try
                {
                    user.Writer.Write(msg);
                    user.Writer.Flush();
                }
                catch
                {

                }
                
            }
            throw new NotImplementedException();
        }

        public void quitter(User chatter)
        {
            if(_userlist.Contains(chatter))
            {
                _userlist.Remove(chatter);
            }
            
            throw new NotImplementedException();
        }

        public void addChatter(User chatter)
        {
            this._userlist.Add(chatter);
            throw new NotImplementedException();
        }

        public string getTopic()
        {
            return this._topic;
            throw new NotImplementedException();
        }


        public void quitter(Chatter chatter)
        {
            throw new NotImplementedException();
        }

        public void addChatter(Chatter chatter)
        {
            throw new NotImplementedException();
        }
    }

}
