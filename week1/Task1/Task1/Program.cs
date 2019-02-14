using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, cnt = 0;
            n = Convert.ToInt32(Console.ReadLine());// so I  write the number ourselves on the compiler
            string[] arr = Console.ReadLine().Split(' ');// I create a string that the elements of the string are read through a single space 
            for (int i = 0; i < n; i++)
            {
                int y = int.Parse(arr[i]);// I convert the string in integer


                bool m = true;// I create a function boolean to find prime numbers in integer
                for (int j = 2; j < y; j++)
                {
                    if (y % j == 0)
                    {
                        m = false;
                    }
                }
                if (y == 1)
                {
                    m = false;
                }
                if (m == true)
                {
                    cnt++;// if the number is prime I count it

                    Console.Write(y + " ");

                }

            }
            Console.WriteLine();
            Console.Write(cnt);

        }
    }
}
