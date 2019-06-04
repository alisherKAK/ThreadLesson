using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrinNumbers();

            //var threads = new Thread[20];
            //for(int i = 0; i < threads.Length; i++)
            //{
            //    threads[i] = new Thread(PrinNumbers);
            //}

            //foreach(var thread in threads)
            //{
            //    thread.Start();
            //}

            var thread = new Thread(Sum);
            thread.IsBackground = false;
            thread.Start(new SumArguments() { X = 5, Y = 10 });

            Console.WriteLine("главный поток закончил работу");
        }

        static void PrinNumbers()
        {
            var currentThread = Thread.CurrentThread;
            Console.WriteLine($"Поток с ИД {currentThread.ManagedThreadId} начал работу");
            
            for(int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                Console.Write(i + " ");
            }

            Console.WriteLine($"\nПоток с ИД { currentThread.ManagedThreadId} закончи работу");
        }

        static void Sum(object arguments)
        {
            Console.WriteLine((arguments as SumArguments).X + (arguments as SumArguments).Y);
            Console.WriteLine("вторичный поток закончил работу");
            Thread.Sleep(5000);
        }
    }
}
