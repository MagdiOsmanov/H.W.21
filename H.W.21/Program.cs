using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace H.W._21
{
    class Program
    {
        private static int[,] field;
        private static int m;
        private static int n;

        static void Main()
        {
            n = Convert.ToInt32(Console.ReadLine());
            m = Convert.ToInt32(Console.ReadLine());

            field = new int[n, m];

            Thread firstSad = new Thread(sad1);
            Thread secondSad = new Thread(sad2);

            firstSad.Start();
            secondSad.Start();

            firstSad.Join();
            secondSad.Join();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(field[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private static void sad1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (field[i, j] == 0)
                        field[i, j] = 1;
                    Thread.Sleep(1);
                }
            }
        }

        private static void sad2()
        {
            for (int i = m - 1; i > 0; i--)
            {
                for (int j = n - 1; j > 0; j--)
                {
                    if (field[j, i] == 0)
                        field[j, i] = 2;
                    Thread.Sleep(1);
                }
            }
        }
    }
}
