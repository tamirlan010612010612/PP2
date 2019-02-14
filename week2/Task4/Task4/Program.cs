using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "2019pp.txt";//көшетін файлды енгіземіз
            string sourcePath = @"C:\path";//файлдың орналасқан жерін көрсетеміз
            string targetPath = @"C:\path1";//файлдың баратын жерін көрсетеміз
            // Path класын файлдарға,папкаларға баратын жолдарды басқару үшін қолданамыз
            string sourceFile = Path.Combine(sourcePath, fileName);//файлдың орналасқан жері
            string destFile = Path.Combine(targetPath, fileName);//файлдың баратын жері

            File.Copy(sourceFile, destFile);//файлды көшіру операциясы және жолды көрсетеміз
            Console.WriteLine("The file copied");


            if (File.Exists(@"C:\path\2019pp.txt"))//Егер файл бастапқы жерінде болса
            {
                try
                {
                    File.Delete(@"C:\path\2019pp.txt");//оны кетір
                    Console.WriteLine("Original file deleted");
                }
                catch (IOException e)//Егер болмаса ошибка шығарады
                {
                    Console.WriteLine(e.Message);
                    return;
                }

            }
        }
    }
}
