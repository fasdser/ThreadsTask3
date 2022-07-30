using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadsTask3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Matrix matrix;
            for (int i = 0; i < 26; i++)
            {
                matrix = new Matrix(i * 3, true);
                new Thread(matrix.Move).Start();
            }
        }
    }
}
