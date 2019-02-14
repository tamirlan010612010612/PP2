using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4

{
    class Program
    {
        static void Main(string[] args)
        {
            /*int a;
            a = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < a; i++) {
                for (int j = 0 ;  j <= i ; j++ )
                {
                    Console.Write("[*]");
                }
                Console.WriteLine();
                     }*/
            string s = Console.ReadLine();//so I create a string,and I can write string in the compiler
            int n = int.Parse(s);// I convert string in integer with the function Parse
            string[,] arr = new string[n, n];// I create two-dimensional array with the same number row and column
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)//I create elements array which the each number of column equal or less than number of row
                {
                    arr[i, j] = "[*]";//I equal the elements of array to [*]
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }

        }
    }
}