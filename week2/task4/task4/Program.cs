using System;
using System.IO;

namespace task4
{
    class Program
    {
        static void CopDel(string path,string path1)//функция 
        {
            string comb = Path.Combine(path, "text.txt");//строка комбинирущая путь и название файла
            string comb1 = Path.Combine(path1, "test.txt"); //строка комбинирущая путь и название файла
            StreamWriter sv = new StreamWriter(comb);//открываем поток для первого файла
            sv.Write("fnfn");//пишем туда и закрываем
            sv.Close();
            File.Copy(comb, comb1);//копируем из одного в другой
            File.Delete(comb);//удаляем исходник
        }
   
        static void Main(string[] args)
        {
            CopDel(@"null", @"nulll");//указываем два пути
        }
    }
}
