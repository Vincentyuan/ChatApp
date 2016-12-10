using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace ChatServer.Chat
{
    public interface Chatter
    {
        void receiveMessage(string msg, Chatter chatter);
        void getNickName(string id);

    }
    public interface ChatRoom
    {
         void poster(string msg, Chatter chatter); //send the message
         void quitter(Chatter chatter); //delete one chatter from the chat room 

         void addChatter(Chatter chatter); // add a new chatter to chat room 
         string getTopic();//get the topic of the chat room 

    }
    public interface topicManage
    {
         List<string> listTopics(); //get all topics
         void createTopic(string topic); //add a new topic  should throws exception:topicExist and not enough authorization.
         ChatRoom getCharRoomByTopic(string topic); //return the chat room according to the topic
    }

   

}
