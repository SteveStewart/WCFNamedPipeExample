using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                LogMessage1();
                LogMessage2();
            }
        }

        static void LogMessage1()
        {
            Logger.Logger.Log("LogMessage1", null);
        }

        static void LogMessage2()
        {
            Logger.Logger.Log("LogMessage2", null);
        }
    }
}
