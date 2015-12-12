using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace UpdateStatusTest
{
    class Program
    {
        static void Main(string[] args)
        {
            inboundserv.InboundService ser = new inboundserv.InboundService();
            ser.Timeout = 5000;

            //TESTs
            while (true)
            {
                Stopwatch sWatch = new Stopwatch();
                sWatch.Start();

                Console.WriteLine("Ready_START|" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));

                try
                {
                    ser.UpdateCrmStatus("123", "Ready");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("EX_READY:" + ex.Message + " " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
                }

                sWatch.Stop();
                Console.WriteLine("Ready_END  |" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + " | " + sWatch.Elapsed.TotalMilliseconds.ToString());

                Thread.Sleep(1000);

                sWatch.Restart();

                Console.WriteLine("--------------------------------------------");

                Console.WriteLine("NotReady_START|" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));

                try
                {
                    ser.UpdateCrmStatus("123", "NotReady");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("EX_NOT_READY:" + ex.Message + " " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
                }

                sWatch.Stop();
                Console.WriteLine("NotReady_END  |" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + " | " + sWatch.Elapsed.TotalMilliseconds.ToString());
            }
        }
    }
}
