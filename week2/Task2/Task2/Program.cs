using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fl = new FileStream(@"C:\git\PP2\week2\input.txt", FileMode.Open, FileAccess.Read);//файлды ашуға және оқуға мүмкіндік береді
            StreamReader sr = new StreamReader(fl);//файл ішіндегі мәліметті оқуға мүмкіндік береді
            FileStream gl = new FileStream(@"C:\git\PP2\week2\output.txt", FileMode.Create, FileAccess.Write);//жаңа файлды ашуға және оқуға мүмкіндік аламыз
            StreamWriter sw = new StreamWriter(gl); //файлға жазуға мүмкіндік береді,шыққан нәтижені осы файлға жаза аламыз
            string ar = sr.ReadLine();//1 2 3 4 5, файлдағы сөзді баған(строка) түріне келтіреміз
            string[] ad = ar.Split(' ');//бағанды массив түрінде бөліп жазамыз,алайда ' ' осындай белгі кездескен жағдайда ғана бөлеміз
            for (int i = 0; i < ad.Length; i++)
            {
                int b = int.Parse(ad[i]);//Parse функциясы арқылы массивтағы әр бағанды сан реінде аламыз
                bool m = true;
                for (int j = 2; j < b; j++)//санды жай сан ба,емес па тексереміз
                {
                    if (b % j == 0)//жай сан тек өзіне және 1 бөліну керек,ол екіден бастап өзіне дейінгі басқа санға бөлінсе жай сен емес
                    {
                        m = false;
                        break;
                    }
                }
                if (b > 1 && m == true)
                {
                    sw.Write(b + " ");//жай сандарды жаңа файлға жазып сақтайды
                    Console.Write(b + " ");
                }
            }
            fl.Close();
            sr.Close();
            sw.Close();
            gl.Close();//ағымдарға басқа операциялар орындалмас үшін жабамыз
            Console.ReadKey();
        }
    }
}