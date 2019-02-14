using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            a = Convert.ToInt32(Console.ReadLine());//I 
            string[] arr = Console.ReadLine().Split(' ');//I create a string that the elements of the string are read through a single space
            List<int> ARR = new List<int>();// List it is a kind of array
            for (int i = 0; i < a; i++)
            {
                int y = int.Parse(arr[i]);//convert elements string in integer
                ARR.Add(y);//  add to list elements of array                                                                                         
            }
            for (int k = 0; k < ARR.Count; k++)// we count elements of List with ARR.Count
            {
                for (int j = 0; j < 2; j++)//each element of the array will be written twice
                {
                    Console.Write(ARR[k] + " ");
                }
            }
        }
    }
}