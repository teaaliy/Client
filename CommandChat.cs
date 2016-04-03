using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Client
{
    [XmlRoot("message")]
    public class CommandChat : BaseCommand
    {
        string text;
        string sender;

        public CommandChat() : base()
        {
            ID = 4;
        }
        
        [XmlElement("text")]
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        [XmlElement("sender")]
        public string Sender
        {
            get { return sender; }
            set { sender = value; }
        }
    }
}
