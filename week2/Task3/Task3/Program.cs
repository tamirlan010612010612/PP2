using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        public static void Probel(int a)//папкалардың саны артқан сайын біз пробел қойып отыратын функция құрамыз
        {
            for (int i = 0; i < a; i++)
            {
                Console.Write("    ");
            }
        }
        public static void Real(DirectoryInfo Dir, int a)//папкадағы мәлімет туралы білу үшін функция құрамыз
        {

            foreach (FileInfo fl in Dir.GetFiles())//әр папка үшін файлдарды шығару
            {
                Probel(a);//папкадағы файлдарды пробел қойып жазамыз
                Console.WriteLine(fl.Name);//файл аттарын шығарамыз
            }
            foreach (DirectoryInfo dr in Dir.GetDirectories())//әр папка үшін ішіндегі папканы шығару,мәлімет алу
            {
                Probel(a);
                Console.WriteLine(dr.Name);//папканын атың шығарамыз
                Real(dr, a + 1);//папканың ішінен папка немесе файл шыға бергенше функцияны қайта шақыра береміз және пробел қоямыз 
            }

        }
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\git\PP2\week2");//папка немесе файлға операциялар орындау үшін керек 
            Real(dir, 0);//функцияны бірінші 0 беріп шақырамыз
            Console.ReadKey();
        }
    }
}