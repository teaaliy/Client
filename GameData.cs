//хранятся все игровые данные
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Client
{
    class GameData
    {
        CommandPlayerCoords playerCoords = new CommandPlayerCoords();
        CommandMapSize mapSize = new CommandMapSize();
        CommandVisibleObjects visibleObjects = new CommandVisibleObjects();
        CommandVisiblePlayers visiblePlayers = new CommandVisiblePlayers();
        CommandPlayerList playersWithColors = new CommandPlayerList();

        public CommandPlayerCoords PlayerCoords
        {
            get { return playerCoords; }
            set { playerCoords = value; }
        }

        public CommandMapSize MapSize
        {
            get { return mapSize; }
            set { mapSize = value; }
        }

        public CommandVisibleObjects VisibleObjects
        {
            get { return visibleObjects;}
            set { visibleObjects = value; }
        }

        public CommandVisiblePlayers VisiblePlayers
        {
            get { return visiblePlayers; }
            set { visiblePlayers = value; }
        }
        public CommandPlayerList PlayerWithColors
        {
            get { return playersWithColors; }
            set { playersWithColors = value; }
        }

        public Color GetPlayerColor()
        {
            foreach (VisiblePlayer visPl in visiblePlayers.Players)
                foreach (Player pl in playersWithColors.Players)
                {
                    if (visPl.Name == pl.Name)
                        return pl.color;
                }
            return Color.White;
        }
    }
}
