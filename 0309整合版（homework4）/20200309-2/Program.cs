using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    public delegate void TickHandler(ClockFaction sender);
    public delegate void AlarmHandler(ClockFaction sender);
    public class ClockFaction
    {
        public event TickHandler Ticking;
        public int TimeHour, TimeMinute, TimeSecond;
        public int AlarmHour, AlarmMinute, AlarmSecond;
        public ClockFaction() 
        {
            TimeHour = 0;
            TimeMinute = 0;
            TimeSecond = 0;
            AlarmHour = 0;
            AlarmMinute = 0;
            AlarmSecond = 0;
        }
        public void alarm(int hour, int minute,int second) 
        {
            AlarmSecond = second;
            AlarmMinute = minute;
            AlarmHour = hour;
        }

        public bool isAlarm() 
        {
            return TimeHour == AlarmHour &&
                TimeMinute == AlarmMinute &&
                TimeSecond == AlarmSecond;
        }
        public void Tick() 
        {
            for (; ; TimeSecond ++)
            {
                System.Threading.Thread.Sleep(1000);
                Ticking(this);
            }

        }
    }

    public class ClockSimulator 
    {
        public ClockFaction clock1 = new ClockFaction();

        public ClockSimulator() 
        {
            clock1.Ticking += Clock_Ticking;
            clock1.Ticking += Clock_Alarming;
            clock1.alarm(0,0,5);
            clock1.Tick();
        }

        void Clock_Ticking(ClockFaction sender) 
        {
            Console.WriteLine($"{sender.TimeHour}-{sender.TimeMinute}-{sender.TimeSecond}");
        }

        void Clock_Alarming(object sender) 
        {
            if (clock1.isAlarm())
            {
                Console.WriteLine("Alarming");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ClockSimulator cls = new ClockSimulator();
            
            Console.ReadLine();
        }
    }
}
