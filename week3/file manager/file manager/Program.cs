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
       static void Print(DirectoryInfo d, int cursor)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            FileInfo[] fi = d.GetFiles();//  создаем массив который будет хранить в себе файлы
            DirectoryInfo[] di = d.GetDirectories();//  создаем массив который будет хранить в себе директории
            FileSystemInfo[] fsi = new FileSystemInfo[di.Length + fi.Length]; //создаем массив который будет хранить в себе директории+файлы

            di.CopyTo(fsi, 0);//копируем все диерктории в массив хранящий оба формата начиная с нулевого элемента
            fi.CopyTo(fsi, di.Length);//копируем все диерктории в массив хранящий оба формата начиная с элемента находящегося после последней директории


            for (int i = 0; i < fsi.Length; i++)//вводим форик для курсора
            {
                if (i == cursor)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;//меняю задний цвет
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                if (fsi[i].GetType() == typeof(DirectoryInfo))//если итый жлемент массива где сохранены и файлы и директории имеет тип директория тогда писать его будем желты
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;//иначе белым
                }

                Console.WriteLine(i + 1+ " . " + fsi[i].Name);//выводим на консоль номер элемента начиная с 1. и сам элемент
            }
        }





        public static void Main(string[] args)
        {
            string path = @"C:\Users\Public\Desktop";//вводим путь папки
            DirectoryInfo d = new DirectoryInfo(path);//указываем что директория принимает путь папки
            int cursor = 0;//курсор на 0
            int size = d.GetFileSystemInfos().Length;//количество строк=длине массива с обоими форматами 

            Print(d, cursor);//вызываем функцию

            while (true)//ставим условие пока утверждения истинны
            {
                FileInfo[] fi = d.GetFiles();//то же самое что и наверху
                DirectoryInfo[] di = d.GetDirectories();
                FileSystemInfo[] fsi = new FileSystemInfo[fi.Length + di.Length];
                di.CopyTo(fsi, 0);
                fi.CopyTo(fsi, di.Length);

                ConsoleKeyInfo ki = Console.ReadKey();//определяем что будут ситываться кнопки с консоли


                if (ki.Key == ConsoleKey.UpArrow)//вверх
                {
                    cursor--;
                    if (cursor == -1)
                    {
                        cursor = size-1;//возвращает последний элемент если достигнут самый первый 
                    }
                }

                if (ki.Key == ConsoleKey.DownArrow)//возвращает первый элемент если элементы закончились
                {
                    cursor++;
                    if (cursor == size)
                    {
                        cursor = 0;
                    }
                }



                if (ki.Key == ConsoleKey.Enter)
                {
                    if (fsi[cursor].GetType() == typeof(DirectoryInfo))//если элемент на котором стоит курсор типа директории то
                    {
                        d = new DirectoryInfo(fsi[cursor].FullName);//директория принимает новое значение
                        cursor = 0;//курсор обратно возвращается в 0
                        size = d.GetFileSystemInfos().Length;//размер принимает новое знаение равное количеству элементов в новой директории
                    }
                }
                else
                {
                    StreamReader sr = new StreamReader(fsi[cursor].FullName);//открываем поток который принимает курсорный элемент
                    Console.Clear();//очищаем консоль
                    Console.WriteLine(sr.ReadToEnd());//выводиам на консоль все что находится в файле

                    sr.Close();//закрываем поток
                    Console.ReadKey();//консоль ожидает нажатия кнопки
                }

                if (ki.Key == ConsoleKey.Backspace)
                {
                    if (d.Parent != null)//если парнет не равен нулл
                    {
                        d = d.Parent;//директория принимает новое значение равное своему паренту
                        cursor = 0;//курсор обратно возвращается в 0
                        size = d.GetFileSystemInfos().Length;//размер принимает новое знаение равное количеству элементов в новой директории
                    }
                    else
                    {
                        break;//иначе останавливается
                    }
                }


                if (ki.Key == ConsoleKey.Delete)
                {
                    if (fsi[cursor].GetType() == typeof(DirectoryInfo))//если курсорный жлемент директория
                    {
                        if (new DirectoryInfo(fsi[cursor].FullName).GetFileSystemInfos().Length == 0)//если длина директории принимающей значение курсорного жлемента равна 0
                        {
                            Directory.Delete(fsi[cursor].FullName,true);//удаляем путь к этому элементу
                        }
                        else
                        {
                            Console.Clear();//иначе чситим консоль
                            Console.WriteLine("Are you sure?If yes,press A");

                            if (ki.Key == ConsoleKey.A)//если нажать кнопку А
                            {
                                Directory.Delete(fsi[cursor].FullName,true);//удалится весь путь к директории
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

                        string name = fsi[cursor].Name;//принимает только название папки
                        string fname = fsi[cursor].FullName;//принимает полный путь
                        string newpath = "";

                        for (int i = 0; i < fname.Length - name.Length; i++)//доходит до момента ггде полный путь-название папки
                        {
                            newpath += fname[i];//добавляет в пустую строку часть где полный путь папки без ее названия
                        }
                        newpath = newpath + s;//добвляем к этой строке наше название которое введем с консоли
                        Directory.Move(fname, path);//меняем местами
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
                    break;//выход из программы
                }    
            }
            Print(d, cursor);
        }
    }
}
