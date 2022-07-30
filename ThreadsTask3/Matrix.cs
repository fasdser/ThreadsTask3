using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadsTask3
{
    class Matrix
    {
        static object locker = new object();
        Random random;
        const string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public int Colunm { get; set; }
        public bool NeedSecond { get; set; }

        public Matrix(int col,bool needSecond)
        {
            Colunm = col;
            NeedSecond = needSecond;
            random = new Random((int)DateTime.Now.Ticks);
        }

        private char GetChar()
        {
            return str.ToCharArray()[random.Next(0, 35)];
        }

        public void Move()
        {
            int lenght;
            int count;

            while (true)
            {
                count = random.Next(3, 6);
                lenght = 0;
                Thread.Sleep(random.Next(100, 5000));
                for (int i = 0; i < 40; i++)
                {
                    lock (locker)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.CursorTop = i - lenght;
                        for (int j = i-lenght-1; j < i; j++)
                        {
                            Console.CursorLeft = Colunm;
                            Console.WriteLine("  ");
                        }

                        if (lenght < count)
                            lenght++;
                        else
                            if (lenght == count)
                            count = 0;
                        if (NeedSecond && i < 20 && i > lenght + 2 && (random.Next(1, 5) == 3))
                        {
                            new Thread((new Matrix(Colunm, false)).Move).Start();
                            NeedSecond = false;
                        }

                        if (39 - i < lenght)
                            lenght--;
                        Console.CursorTop = i - lenght + 1;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        for (int j = 0; j < lenght - 2; j++)
                        {
                            Console.CursorLeft = Colunm;
                            Console.WriteLine(GetChar());
                        }
                        if (lenght >= 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.CursorLeft = Colunm;
                            Console.WriteLine(GetChar());
                        }
                        if (lenght >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.CursorLeft = Colunm;
                            Console.WriteLine(GetChar());
                        }
                        Thread.Sleep(10);
                    }
                }
            }
        }
    }
}
