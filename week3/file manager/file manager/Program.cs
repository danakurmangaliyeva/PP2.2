using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace file_manager
{
    class Program
    {
       static void print(DirectoryInfo d, int cursor)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            FileInfo[] fi = d.GetFiles();//  создаем массив который будет хранить в себе файлы
            DirectoryInfo[] di = d.GetDirectories();//  создаем массив который будет хранить в себе директории
            FileSystemInfo[] fsi = new FileSystemInfo[fi.Length + di.Length]; //создаем массив который будет хранить в себе директории+файлы

            di.CopyTo(fsi, 0);//копируем все диерктории в массив хранящий оба формата начиная с нулевого элемента
            fi.CopyTo(fsi, di.Length);//копируем все диерктории в массив хранящий оба формата начиная с элемента находящегося после последней директории


            for (int i = 0; i < fsi.Length; i++)
            {
                if (i == cursor)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                if (fsi[i].GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(i + 1+ " . " + fsi[i].Name);
            }
        }





        public static void Main(string[] args)
        {
            string path = @"C:\Users\Public\Desktop";
            DirectoryInfo d = new DirectoryInfo(path);
            int cursor = 0;
            int size = d.GetFileSystemInfos().Length;

            print(d, cursor);

            while (true)
            {
                FileInfo[] fi = d.GetFiles();
                DirectoryInfo[] di = d.GetDirectories();
                FileSystemInfo[] fsi = new FileSystemInfo[fi.Length + di.Length];
                di.CopyTo(fsi, 0);
                fi.CopyTo(fsi, di.Length);

                ConsoleKeyInfo ki = Console.ReadKey();


                if (ki.Key == ConsoleKey.UpArrow)
                {
                    cursor--;
                    if (cursor == -1)
                    {
                        cursor = size-1;
                    }
                }

                if (ki.Key == ConsoleKey.DownArrow)
                {
                    cursor++;
                    if (cursor == size)
                    {
                        cursor = 0;
                    }
                }



                if (ki.Key == ConsoleKey.Enter)
                {
                    if (fsi[cursor].GetType() == typeof(DirectoryInfo))
                    {
                        d = new DirectoryInfo(fsi[cursor].FullName);
                        cursor = 0;
                        size = d.GetFileSystemInfos().Length;
                    }
                }
                else
                {
                    StreamReader sr = new StreamReader(fsi[cursor].FullName);
                    Console.Clear();
                    Console.WriteLine(sr.ReadToEnd());

                    sr.Close();
                    Console.ReadKey();
                }

                if (ki.Key == ConsoleKey.Backspace)
                {
                    if (d.Parent != null)
                    {
                        d = d.Parent;
                        cursor = 0;
                        size = d.GetFileSystemInfos().Length;
                    }
                    else
                    {
                        break;
                    }
                }


                if (ki.Key == ConsoleKey.Delete)
                {
                    if (fsi[cursor].GetType() == typeof(DirectoryInfo))
                    {
                        if (new DirectoryInfo(fsi[cursor].FullName).GetFileSystemInfos().Length == 0)
                        {
                            Directory.Delete(fsi[cursor].FullName);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Are you sure?If yes,press A");

                            if (ki.Key == ConsoleKey.A)
                            {
                                Directory.Delete(fsi[cursor].FullName);
                            }
                        }
                    }
                }


                if (ki.Key == ConsoleKey.K)
                {
                    if (fsi[cursor].GetType() == typeof(DirectoryInfo))
                    {
                        Console.Clear();
                        string s = Console.ReadLine();

                        string name = fsi[cursor].Name;
                        string fname = fsi[cursor].FullName;
                        string newpath = "";

                        for (int i = 0; i < fname.Length - name.Length; i++)
                        {
                            newpath += fname[i];
                        }
                        newpath = newpath + s;
                        Directory.Move(fname, path);
                    }

                    else
                    {
                        Console.Clear();
                        string f = Console.ReadLine();

                        string name = fsi[cursor].Name;
                        string fname = fsi[cursor].FullName;
                        string newpath = "";

                        for (int i = 0; i < fname.Length - name.Length; i++)
                        {
                            newpath += fname[i];
                        }
                        newpath = newpath + f;
                        File.Move(fname, newpath);
                    }
                }
                if (ki.Key == ConsoleKey.Escape)
                {
                    break;
                }
                print(d, cursor);
            }
        }
    }
}
