using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows;
using System.IO;

namespace Client
{
    class CtrlMap : Control
    {
        Point ulCorner, oldUlCorner;
        Graphics g;
        Rectangle rc;
        const int size = 15;
        Image winner;
        Point playerCoords;

        public class PlayerOnMap
        {
            public int row, col;
            public Color color;
        }

        public List<MapObject> walls, exits;
        List<PlayerOnMap> playersOnMap;

        public CtrlMap() : base()
        {
            playersOnMap = new List<PlayerOnMap>();
            walls = new List<MapObject>();
            exits = new List<MapObject>();
            ulCorner = new Point(playerCoords.X, playerCoords.Y);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            g = e.Graphics;
            Console.WriteLine("Drawing");
            //if(gameData.VisibleObjects.MapObjects != null)
            //    SetObjects(gameData.VisibleObjects.MapObjects);
            DrawMap(); 
        }

        //void CtrlMap_Paint(object sender, PaintEventArgs e)
        //{

        //    g = e.Graphics;
        //    Console.WriteLine("Drawing");
        //    //if(gameData.VisibleObjects.MapObjects != null)
        //    //    SetObjects(gameData.VisibleObjects.MapObjects);
        //    DrawMap(); 
        //}

        void DrawMap()
        {
            Pen p1 = new Pen(Color.Black, 2);
            Pen p2 = new Pen(Color.Red, 3);
            Pen p4 = new Pen(Color.Aqua, 3);
            Console.WriteLine("Begin");
            if (walls.Count == 0) { }
            else
            {
                g.DrawEllipse(p4, playerCoords.X * 15, playerCoords.Y * 15, 15, 15);
                foreach (MapObject wall in walls)
                    g.DrawRectangle(p1, wall.Col * size, wall.Row * size, size, size);
            }

            if (exits.Count == 0) { }
            else
            {
                foreach (MapObject exit in exits)
                    g.DrawRectangle(p2, exit.Col * size, exit.Row * size, 15, 15);
            }

            

            if (playersOnMap.Count == 0) { }
            else
            {
                foreach (PlayerOnMap pl in playersOnMap)
                {
                    Pen p3 = new Pen(pl.color, 2);
                    g.DrawEllipse(p3, pl.col * 15, pl.row * 15, 15, 15);
                }
            }
            Console.WriteLine("End");
        }

        public void SetPlayerCoords(CommandPlayerCoords commandPlayerCoords)
        {
            playerCoords.X = commandPlayerCoords.Col;
            playerCoords.Y = commandPlayerCoords.Row;
        }

        public void SetObjects(List<MapObject> objects)
        {
            if (objects.Count == 0) { }
            else
            {
                foreach (MapObject obj in objects)
                {
                    if (obj.Type == TypeOfobject.WALL)
                        walls.Add(obj);
                    else if (obj.Type == TypeOfobject.EXIT)
                        exits.Add(obj);
                }
            }
        }

        public void ClearObjects()
        {
            walls.Clear();
            exits.Clear();
        }

        public void AddPlayer(Color color, int row, int col)
        {
            PlayerOnMap player = new PlayerOnMap();
            player.color = color;
            player.row = row;
            player.col = col;
            playersOnMap.Add(player);
        }

        public void ClearPlayers()
        {
            playersOnMap.Clear();
        }

        public void Moving(int dx, int dy)
        {
            oldUlCorner = ulCorner;
            ulCorner.Y += dy;
            ulCorner.X += dx;
            Size sizeOfImg = new Size(25, 25);

            if (dx == 0 && dy == -10 || dy == 0 && dx == -10)
            {
                rc = new Rectangle(ulCorner, sizeOfImg);
                Invalidate(rc);
            }
            else if (dx == 0 && dy == 10 || dy == 0 && dx == 10)
            {
                rc = new Rectangle(oldUlCorner, sizeOfImg);
                Invalidate(rc);
            }
        }

        public void DrawResult(CommandGameOver commandGameOver)
        {
            if (commandGameOver.Result > 0)
            {
                Image winner = Image.FromFile("winner.jpg");
                g.DrawImage(winner, 10, 10);
                Invalidate();
            }
            else if (commandGameOver.Result == 0)
            {
                Image loser = Image.FromFile("loser.jpg");
                    g.DrawImage(loser, 10, 10);
                    Invalidate();
            }
        }
    }
}
   