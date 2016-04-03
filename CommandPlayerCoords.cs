using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Client
{
    [XmlRoot("player_coords")]
    public class CommandPlayerCoords : BaseCommand
    {
        int row, col;

        public CommandPlayerCoords() : base()
        {
            ID = 6;
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
}
