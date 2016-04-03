using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    delegate void NetworkConnectingDel();

    class ClientMessages : NetworkConnecting
    {
       
        StringBuilder commandBuffer = new StringBuilder();
        StringBuilder streamingData = new StringBuilder();
        int countOfRecived = 0;
        int countOfSend = 0;
        List<BaseCommand> listOfCommands = new List<BaseCommand>();
        NetworkConnectingDel netConnectingDel;

        public ClientMessages()
        {
            NewNotifications(new VoidDel(DataHandler));
        }


        public bool SendCommand(BaseCommand command)
        {
            try 
            {
                string stringToSend = command.SerializeCommand();
                int id = command.ID;
                int size = stringToSend.Length;

                commandBuffer.Append((char) id);
                commandBuffer.Append((char) size);
                commandBuffer.Append(stringToSend);

                bool result = WriteToServer(commandBuffer.ToString());
                countOfSend++;
                commandBuffer.Clear();
                return result;
            }

            catch(Exception ex) 
            {
                GameExceptions.SaveExceptions(ex.Message);
                return false;
            }
        }

        public void DataHandler()
        {
            streamingData.Append(ReadServer());
            BaseCommand cmd;

            int id;
            int size;
            string command;
            
            do {
                if (streamingData.Length < 0)
                    break;

                id = streamingData[0];
                size = streamingData[1];

                if (streamingData.Length < size + 2)
                    break;

                command = streamingData.ToString(2, size);
                cmd = BaseCommand.DeserializeCommand(id, command);
                lock (listOfCommands)
                {
                    listOfCommands.Add(cmd);
                }
                countOfRecived++;
                streamingData.Remove(0, size + 2);

                netConnectingDel(); 

            } while(size + 2 < streamingData.Length);
        }

        public BaseCommand[] ReciveCommand()
        {
            BaseCommand[] recivedCommandQueue;
            lock(listOfCommands)
            {
                recivedCommandQueue = new BaseCommand[listOfCommands.Count];
                listOfCommands.CopyTo(recivedCommandQueue);
                listOfCommands.Clear();
            }
            return recivedCommandQueue;                     
        }

        int GetCountOfCommands()
        {
            return countOfRecived;
        }

        public void AddNotification(NetworkConnectingDel nd)
        {
            netConnectingDel += nd;
        }

    }
}
