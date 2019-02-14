using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fl = new FileStream(@"C:\git\PP2\week2\input.txt", FileMode.Open, FileAccess.Read);//FileStream аркылы папканы окуга және жазуға  мүмкіндік аламыз
            StreamReader sr = new StreamReader(fl);// StreamReader ол ақпаратты санайтын ағын
            string a = sr.ReadLine(); //"ababa", файлдағы элементті баған(строка) түрінде жазамыз
            int cnt = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != a[a.Length - 1 - i])//сөз полиндром ба,емес пе, тексереміз
                {
                    cnt++;
                }
            }
            if (cnt == 0)
            {
                Console.WriteLine("Yes");
            }
            else
                Console.WriteLine("No");

            fl.Close();//басқа операцияларға қолжетімді болуы мүмкін болғасын жабамыз
            sr.Close();//
            Console.ReadKey();
        }
    }
}