using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Drawing;

namespace Client
{
    public class Player
    {
        string name;
        [XmlIgnore]
        public Color color; 

        [XmlElement("name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [XmlElement("color")]
        public int SetColor
        {
            get { return color.ToArgb(); }
            set { color = Color.FromArgb(value); }
        }  
    }

    [XmlRoot("player_list")]
    public class CommandPlayerList : BaseCommand
    {
        
        List<Player> players;
        
        public CommandPlayerList() : base()
        {
            ID = 3;
        }

        [XmlArray("players")]
        [XmlArrayItem("player")]
        public List<Player> Players
        {
            get { return players; }
            set { players = value; }
        }

        
    }
}
