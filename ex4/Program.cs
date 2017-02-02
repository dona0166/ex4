using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ex4
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            TemperatureRep temprepo = new TemperatureRep();
            Thread mythread = new Thread(temprepo.printtemp);
            mythread.Start();
            mythread.Join();
            mythread.Abort();
            Thread.Sleep(5000);
            

            if(mythread.IsAlive == false)
            {
                Console.WriteLine("Alarm-wire terminated");
                
            }

            

            
            
        }

        public class TemperatureRep
        {
            Random random = new Random();
            public TemperatureRep()
            {
                alarmcount = 0;
            }

            public int alarmcount { get; set; }
            public bool abort { get; set; }
            public int temp { get; set; }
            public void printtemp()
            {
                
                while (alarmcount < 3)
                {
                    temp = random.Next(-20, 200);
                    Console.WriteLine("The temperature is " + temp.ToString() + " C° \n");
     
                    if(temp < 0 || temp > 100)
                    {
                        alarmcount++;
                        Console.WriteLine("Temperature is outside the legal range \n");
                        //Console.WriteLine("Alarm count = " + alarmcount + "\n");

                    }
                    
                    Thread.Sleep(1000);
                    
                }
                
                
                
            }
            
            

        }
    }
}
