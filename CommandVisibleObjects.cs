using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Client
{
    public enum TypeOfobject {WALL, EXIT}

    public class MapObject
    {
        TypeOfobject type;
        int row, col;

        [XmlElement("type")]
        public TypeOfobject Type
        {
            get { return type; }
            set { type = value; }
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

    [XmlRoot("visible_objects")]
    public class CommandVisibleObjects : BaseCommand
    {
        List<MapObject> mapObjects;

        public CommandVisibleObjects() : base()
        {
            ID = 8;
        }

        [XmlArray("map_objects")]
        [XmlArrayItem("map_object")]
        public List<MapObject> MapObjects
        {
            get { return mapObjects; }
            set { mapObjects = value; }
        }
    }
}
