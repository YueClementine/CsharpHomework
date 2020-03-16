

using System;
using System.Timers;

namespace 第四周c
{
    class Program
    {

        int hh = DateTime.Now.Hour;
        int mm = DateTime.Now.Minute;
        int ss = DateTime.Now.Second;

        static void Main(string[] args)
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(TimeEvent);
            
            aTimer.Interval = 1000;
            aTimer.Enabled = true;
            string strLine;
            do
            {
                strLine = Console.ReadLine();
            } while (strLine != null && strLine != "exit");
        }

        private static void TimeEvent(object source, ElapsedEventArgs e)
        {
            System.DateTime dateNow = System.DateTime.Now;

        }
       
    }
}
