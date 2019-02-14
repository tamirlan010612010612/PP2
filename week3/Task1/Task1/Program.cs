using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp2
{
    enum FSIMode//ақпаратты бөлек жазып алып,аңықтамалық(справочник) ретінде қолдана аламыз
    {
        DirectoryInfo = 1,
        File = 2
    }
    class Lawer
    {
        public DirectoryInfo[] DirCon//папкалар үшін жаңа массив енгіземіз
        {
            get; //осы операция арқылы айнымалыларды оқи аламыз
            set;//осы операция арқылы айнымалыларға мән бере аламыз

        }
        public FileInfo[] FileCon
        {
            get;
            set;

        }
        public int selectedIndex
        {
            get;
            set;
        }
        public void Draw()//ақпаратты көрсету үшін және ақпарттармен операция орындау үшін функция құрамыз
        {
            Console.BackgroundColor = ConsoleColor.Black;//бәрін кетіргенде экранды қара түске боя
            Console.Clear();//Барлық ақпаратты тазартып отырамыз
            for (int i = 0; i < DirCon.Length; i++)
            {
                if (i == selectedIndex)//егерде таңдалған индексті көрсетсек
                {
                    Console.BackgroundColor = ConsoleColor.Red;//сол индексті қызыл түске боя
                }
                else
                    Console.BackgroundColor = ConsoleColor.Black;//басқа папкаларды қара түске бояймыз
                Console.WriteLine(i + 1 + ". " + DirCon[i].Name);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;// файлдарды сары түске бояймыз 
            for (int j = 0; j < FileCon.Length; j++)
            {
                if (j + DirCon.Length == selectedIndex)//егерде таңдалған индексті көрсетсек
                {
                    Console.BackgroundColor = ConsoleColor.Red;//таңдалған файлды қызыл түске бояймыз
                }
                else
                    Console.BackgroundColor = ConsoleColor.Black;//қалғандарын қара түске бояймыз
                Console.WriteLine(j + 1 + DirCon.Length + ". " + FileCon[j].Name);
            }
            Console.ForegroundColor = ConsoleColor.White;

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo Dir = new DirectoryInfo(@"C:\Users\Admin\Desktop\Tamirlan");
            Lawer l = new Lawer// папкаларды,файлдарды,индексті көрсететін класс құрамыз
            {
                DirCon = Dir.GetDirectories(),//DirCon массиві үшін  Dir директорясында папканың адресін көрсетеміз
                FileCon = Dir.GetFiles(),
                selectedIndex = 0
            };
            l.Draw();
            FSIMode Mod = FSIMode.DirectoryInfo;//папкалар үшін жаңа FSI(enum) құрамыз
            Stack<Lawer> contral = new Stack<Lawer>();//жаңа стэк құрамыз
            contral.Push(l);// стэкке class(l) ді енгіземіз
            bool work = false;
            while (!work)
            {
                if (Mod == FSIMode.DirectoryInfo)//егер FSI(enum) папка болса   
                {
                    contral.Peek().Draw();//стэкка Draw функциясын көрсетеміз
                }
                ConsoleKeyInfo key = Console.ReadKey();// басылған консолдың клавиштерін сипаттайды
                switch (key.Key)//
                {
                    case ConsoleKey.UpArrow://егер стрелка жоғарыны бассақ

                        if (contral.Peek().selectedIndex > 0)
                        {
                            contral.Peek().selectedIndex--;// қызыл курсор бірінші элементтен жоғары бармайды 
                        }
                        break;
                    case ConsoleKey.DownArrow://егер стрелка төменді бассақ
                        if (contral.Peek().selectedIndex < contral.Peek().DirCon.Length + contral.Peek().FileCon.Length - 1)
                        {
                            contral.Peek().selectedIndex++;//қызыл курсор соңғы элементтен төмен түспейді
                        }
                        break;
                    case ConsoleKey.Enter:// егер Enter-ді бассақ 
                        int ind = contral.Peek().selectedIndex;//
                        if (contral.Peek().selectedIndex < contral.Peek().DirCon.Length)//егер ол папканың индексі болса 
                        {
                            DirectoryInfo di = contral.Peek().DirCon[contral.Peek().selectedIndex];//жаңа папка ашамыз сол индекстегі
                            Lawer nl = new Lawer// жаңа класс Lawer-ны құрастырамыз
                            {
                                DirCon = di.GetDirectories(),//Диркон массивіне ди папкысын адресін көрсетеміз
                                FileCon = di.GetFiles(),//Файлкон массивіне ди файлдарының адресін көрсетеміз
                                selectedIndex = 0
                            };
                            contral.Push(nl);//стэкка nl класын енгіземіз 
                        }
                        else
                        {
                            Mod = FSIMode.File;// Егер FSI(enum) файл болса
                            FileStream fl = new FileStream(contral.Peek().FileCon[contral.Peek().selectedIndex - contral.Peek().DirCon.Length].FullName, FileMode.Open, FileAccess.Read);
                            // файлдың индекстерін аламыз
                            StreamReader sr = new StreamReader(fl);
                            Console.BackgroundColor = ConsoleColor.Black;//файлды қара фонға бояйды
                            Console.ForegroundColor = ConsoleColor.White;//файлдағы ақпаратты ақ түске бояйды
                            Console.Clear();//барлығын кетіреміз
                            Console.WriteLine(sr.ReadToEnd());//файлдағы ақпаратты оқимыз сонына дейін
                            fl.Close();
                            sr.Close();
                        }
                        break;
                    case ConsoleKey.Backspace://егер Backspace-ты бассақ
                        if (Mod == FSIMode.DirectoryInfo)//егер FSI(enum) папка болса  
                        {
                            contral.Pop();//бетіндегі консолды толығымен кетіреді 
                        }
                        else //егер FSI(enum) файл болса 
                        {
                            Mod = FSIMode.DirectoryInfo;//онда файлдың бастапқы папкасын қайтарады
                        }
                        break;

                    case ConsoleKey.Escape://егер Escape-ты бассақ
                        work = true;//онда консол жұмысын тоқтатады
                        break;
                }

            }
        }
    }
}