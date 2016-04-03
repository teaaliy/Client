using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Xml.Serialization;


namespace Client
{
    public partial class Form1 : Form
    {
        GameData gameData = new GameData();
        ClientMessages cl = new ClientMessages();
        CommandChat chat = new CommandChat();
        TimeSpan timeLeft;
        CommandPlayerMove playerMoov = new CommandPlayerMove();
        CommandResponse response = new CommandResponse();
        CommandPlayerList playersList = new CommandPlayerList();
        private CommandTimeLeft commandTimeLeft = null;

        public Form1()
        {
            InitializeComponent();

            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        private void GetCommand()
        {
            BaseCommand[] commands = cl.ReciveCommand();

            foreach (BaseCommand command in commands)
            {
                switch (command.ID)
                {
                    case 1:
                        ResponseFromServer((CommandResponse)command);
                        break;
                    case 2:
                        Introduction((CommandIntro)command);
                        break;
                    case 3:
                        SendPlayerList((CommandPlayerList)command);
                        break;
                    case 4:
                        ChatRead((CommandChat)command);
                        break;
                    case 5:
                        commandTimeLeft = (CommandTimeLeft)command;
                        timeLeft = TimeSpan.FromMilliseconds(commandTimeLeft.Time);
                        break;
                    case 6:
                        GetPlayerCoords((CommandPlayerCoords)command);
                        break;
                    case 7:
                        ShowMapSize((CommandMapSize)command);
                        break;
                    case 8:
                        ShowVisibleObjects((CommandVisibleObjects)command);
                        break;
                    case 9:
                        ShowVisiblePlayers((CommandVisiblePlayers)command);
                        break;
                    case 10:
                        SendDirection((CommandPlayerMove)command);
                        break;
                    case 11:
                        ShowGameResult((CommandGameOver)command);
                        break;
                    case 12:
                        Disconnection((CommandPlayerDisconnect)command);
                        break;
                }
            }
        }


        private void connectButton_Click(object sender, EventArgs e)
        {
            cl.AddNotification(new NetworkConnectingDel(GetCommand));
            cl.Login = tbLogin.Text;
            cl.Port = Convert.ToInt32(tbPortAdress.Text);
            cl.ServerIP = tbIPadress.Text;
            if (!cl.ConnectToServer())
                tbChatRead.AppendText("ERROR");

            CommandIntro intro = new CommandIntro();
            intro.Name = cl.Login;
            cl.SendCommand(intro);

            if (timerForTimer.Enabled == false)
                timerForTimer.Enabled = true;
            timerForTimer.Start();
        }


        void ResponseFromServer(CommandResponse commandResponse)
        {
            tbChatRead.BeginInvoke(new MethodInvoker(delegate
            {
                if (commandResponse.Result != "ok")
                    tbChatRead.AppendText(commandResponse.Result);
                tbChatRead.AppendText(commandResponse.Text + "\r\n");
            }));
        }


        void Introduction(CommandIntro commandIntro)
        {
            commandIntro.Name = cl.Login;
        }

        void SendPlayerList(CommandPlayerList commandPlayerList)
        {
            gameData.PlayerWithColors = commandPlayerList;
            listOfClients.BeginInvoke(new MethodInvoker(delegate
            {
                AddToListbox(commandPlayerList);
            }));
        }

        void AddToListbox(CommandPlayerList commandPlayerList)
        {
            foreach (Player item in commandPlayerList.Players)
            {
                if (!listOfClients.Items.Contains(item.Name))
                    listOfClients.Items.Add(item.Name);
            }
        }


        void ChatRead(CommandChat commandChat)
        {
            if (commandChat.Text != null && commandChat.Text != "")
            {
                tbChatRead.BeginInvoke(new MethodInvoker(delegate
                {
                    tbChatRead.AppendText(commandChat.Sender + ": " + commandChat.Text + "\r\n");
                    ;
                }));
            }
            else
            {
                GameExceptions.SaveExceptions(new NullReferenceException().Message);
            }
        }


        void ShowTimeLeft(TimeSpan TimeLeft)
        {
            timer.BeginInvoke(new MethodInvoker(delegate
            {
                timer.Text = timeLeft.ToString();
            }));
        }

        private void timerForTimer_Tick(object sender, EventArgs e)
        {
            timeLeft -= TimeSpan.FromMilliseconds(1000);
            ShowTimeLeft(timeLeft);
        }


        void GetPlayerCoords(CommandPlayerCoords commandPlayerCoords)
        {
            gameData.PlayerCoords = commandPlayerCoords;
            controlMap.SetPlayerCoords(commandPlayerCoords);
        }


        void ShowMapSize(CommandMapSize commandMapSize)
        {
            gameData.MapSize = commandMapSize;

            sizeOfMap.BeginInvoke(new MethodInvoker(delegate
            {
                sizeOfMap.Text = gameData.MapSize.Height.ToString() + " x" + gameData.MapSize.Width.ToString();
            }));
        }


        void ShowVisibleObjects(CommandVisibleObjects commandvisibleObjects)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate { ShowVisibleObjects(commandvisibleObjects); }));
                return;
            }
            gameData.VisibleObjects = commandvisibleObjects;

            controlMap.ClearObjects();
            controlMap.SetObjects(commandvisibleObjects.MapObjects);
            controlMap.Invalidate();
        }


        void ShowVisiblePlayers(CommandVisiblePlayers commandVisiblePlayers)
        {
            gameData.VisiblePlayers = commandVisiblePlayers;

            controlMap.ClearPlayers();
            foreach (VisiblePlayer visiblePlayer in commandVisiblePlayers.Players)
                controlMap.AddPlayer(gameData.GetPlayerColor(), visiblePlayer.Row, visiblePlayer.Col);
            controlMap.Invalidate();

            listOfVisiblePlayers.BeginInvoke(new MethodInvoker(delegate
            {
                AddToListOfVisiblePlayers(gameData.VisiblePlayers);
            }));
        }

        void AddToListOfVisiblePlayers(CommandVisiblePlayers commandVisiblePlayers)
        {
            listOfVisiblePlayers.Items.Clear();
            foreach (VisiblePlayer item in commandVisiblePlayers.Players)
            {
                if (!listOfVisiblePlayers.Items.Contains(item.Name))
                    listOfVisiblePlayers.Items.Add(item.Name + "  " + item.Col + ":" + item.Row);
            }
        }

        void ShowGameResult(CommandGameOver commandGameOver)
        {
            if (commandGameOver.Result == 0)
            {
                controlMap.ClearObjects();
                controlMap.ClearPlayers();
                controlMap.Invalidate();
                
                chat.Text = "You LOSE the game! :( ";
                ChatRead(chat);
                controlMap.DrawResult(commandGameOver);
            }
            else if (commandGameOver.Result > 0)
            {
                controlMap.ClearObjects();
                controlMap.ClearPlayers();
                controlMap.Invalidate();
                chat.Text = "WINNER!!!";
                ChatRead(chat);
                controlMap.DrawResult(commandGameOver);
            }
        }

        void SendDirection(CommandPlayerMove commandPlayerMove)
        {
            cl.SendCommand(commandPlayerMove);
        }
        

        void Disconnection(CommandPlayerDisconnect commandPlayerDisconnect)
        {
            cl.SendCommand(commandPlayerDisconnect);
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            cl.SendCommand(new CommandPlayerDisconnect());
            if (cl.DisconnectServer())
            {
                chat.Text = "\r\nПока-пока!";
                ChatRead(chat);
                timerForTimer.Stop();
            }
        }

        private void SendMessageButton_Click(object sender, EventArgs e)
        {
            chat.Text = tbChatWrite.Text;
            cl.SendCommand(chat);
            tbChatWrite.Clear();
        }

        //---------------------рисование объектов и карты---------------------------


        public void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control) return;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    playerMoov.Direction = PlayerDirection.W;
                    cl.SendCommand(playerMoov);
                    //controlMap.Moving(-10, 0);
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Right:
                    playerMoov.Direction = PlayerDirection.E;
                    cl.SendCommand(playerMoov);
                    //controlMap.Moving(10, 0);
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Up:
                    playerMoov.Direction = PlayerDirection.N;
                    cl.SendCommand(playerMoov);
                    //controlMap.Moving(0, -10);
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Down:
                    playerMoov.Direction = PlayerDirection.S;
                    cl.SendCommand(playerMoov);
                    //controlMap.Moving(0, 10);
                    e.SuppressKeyPress = true;
                    break;
                default:
                    break;
            }
        }

        private void onPaint(object sender, PaintEventArgs e) { }

        private void northButton_Click(object sender, EventArgs e)
        {
            playerMoov.Direction = PlayerDirection.N;
            cl.SendCommand(playerMoov);

            //controlMap.Moving(0, -10);
        }

        private void eastButton_Click(object sender, EventArgs e)
        {
            playerMoov.Direction = PlayerDirection.E;
            cl.SendCommand(playerMoov);

            //controlMap.Moving(10, 0);
        }

        private void westButton_Click(object sender, EventArgs e)
        {
            playerMoov.Direction = PlayerDirection.W;
            cl.SendCommand(playerMoov);

            //controlMap.Moving(-10, 0);
        }

        private void southButton_Click(object sender, EventArgs e)
        {
            playerMoov.Direction = PlayerDirection.S;
            cl.SendCommand(playerMoov);

            //controlMap.Moving(0, 10);
        }


        private void tbChatRead_TextChanged(object sender, EventArgs e) { }
        private void tbPortAdress_TextChanged(object sender, EventArgs e) { }
        private void tbLogin_TextChanged(object sender, EventArgs e) { }
        private void tbIPadress_TextChanged(object sender, EventArgs e) { }
        private void listOfClients_SelectedIndexChanged(object sender, EventArgs e) { }

        
     
    }
}
