using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Client
{
    public class VisiblePlayer
    {
        string pl_name;
        int row, col;

        [XmlElement("name")]
        public string Name
        {
            get { return pl_name; }
            set { pl_name = value; }
        }

        [XmlElement("row")]
        public int Row
        {
            get { return row; }
            set { row = value; }
        }

        [XmlElement("col")]
        public int Col
        {
            get { return col; }
            set { col = value; }
        }
    }

    [XmlRoot("visible_players")]
    public class CommandVisiblePlayers : BaseCommand
    {
        List<VisiblePlayer> players;

        public CommandVisiblePlayers() : base()
        {
            ID = 9;
        }

        [XmlArray("players")]
        [XmlArrayItem("player")]
        public List<VisiblePlayer> Players
        {
            get { return players; }
            set { players = value; }
        }
    }
}
