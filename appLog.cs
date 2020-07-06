using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace zk
{
    class appLog
    {
        public static void sysInfoRecord(string excInfo)
        {
            string text = System.DateTime.Now.ToString() + " " + excInfo;
            StreamWriter file = new System.IO.StreamWriter(@".\appLog.txt", true);
            file.WriteLine(text);
            file.Close();
        }

        public static void exceptionRecord(string excInfo)
        {
            string text = System.DateTime.Now.ToString() + " " + excInfo;
            StreamWriter file = new System.IO.StreamWriter(@".\appLog.txt", true);
            file.WriteLine(text);
            file.Close();
        }
    }
}
