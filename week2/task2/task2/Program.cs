using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp1
{
    class Program
    {

        public static bool isPrime(int q) // пишем функцию чтобы проверить простое число или нет
        {
            if (q == 1) return false;
            for (int i = 2; i < q; i++)
            {
                if (q % i == 0) return false;
            }
            return true;
        }



        public static void Main(string[] args)
        {
                StreamReader sv = new StreamReader(@"C:\Users\Мартышка\Desktop\input.txt");//открываем поток для считывания

                string[] w = sv.ReadToEnd().Split(' ');// создаем массив в который будем заносить строку из потока,прочитав ее до конца и делим его по пробелу
       
                sv.Close();// закрываем поток

            StreamWriter sv1 = new StreamWriter(@"C:\Users\Мартышка\Desktop\output.txt");//открываем поток для записи
            string output = "";// создаем какой-то стринг для занесения туда конечного результата


            for (int i = 0; i < w.Length; i++)// создаем цикл в котором каждый элемент строки пееводим в интегер и проверяем по функции 
            {
                if (isPrime(int.Parse(w[i])) == true) output += w[i] + ' ';// если функция приимает значение true, то добавляем его в строку c конечным результатом 
            }
            sv1.Write(output);// на консоль и в файл записываем конечный стринг
            sv1.Close();// закрываем поток
        }
    }
}
