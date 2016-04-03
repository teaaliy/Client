using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Client
{
    public class BaseCommand
    {
        public static Type[] typeOfCommands;

        static BaseCommand()
        {
            typeOfCommands = new Type[13];
            typeOfCommands[1] = typeof(CommandResponse);
            typeOfCommands[2] = typeof(CommandIntro);
            typeOfCommands[3] = typeof(CommandPlayerList);
            typeOfCommands[4] = typeof(CommandChat);
            typeOfCommands[5] = typeof(CommandTimeLeft);
            typeOfCommands[6] = typeof(CommandPlayerCoords);
            typeOfCommands[7] = typeof(CommandMapSize);
            typeOfCommands[8] = typeof(CommandVisibleObjects);
            typeOfCommands[9] = typeof(CommandVisiblePlayers);
            typeOfCommands[10] = typeof(CommandPlayerMove);
            typeOfCommands[11] = typeof(CommandGameOver);
            typeOfCommands[12] = typeof(CommandPlayerDisconnect);
        }

        [XmlAttribute ("id")]
        public int ID;

        public string SerializeCommand()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(GetType());
                StringWriter writer = new StringWriter();
                ser.Serialize(writer, this);
                return writer.ToString();
            }
            catch (Exception ex)
            {
                GameExceptions.SaveExceptions(ex.Message);
                throw;
            }
          
        }

        public static BaseCommand DeserializeCommand(int id, string str) //try catch 
        {
            try
            {
                StringReader reader = new StringReader(str);
                XmlSerializer ser = new XmlSerializer(typeOfCommands[id]);
                object obj = ser.Deserialize(reader);
                return (BaseCommand)obj;
            }
            catch (Exception ex)
            {
                GameExceptions.SaveExceptions(ex.Message);
                throw;
            }
        }
    }
}
