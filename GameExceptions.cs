using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Client
{
    static class GameExceptions
    {
        //статическое поле, log
        static public void SaveExceptions(string errorMessage)
        {
            List<string> listOfExeptions = new List<string>();
            listOfExeptions.Add(errorMessage);
            using (StreamWriter sw = new StreamWriter("Data.txt"))
            {
                sw.Write(listOfExeptions);
            }

        }
    }
}
