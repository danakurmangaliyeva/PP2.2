using System;
using System.Collections.Generic;

namespace task1
{
    class Program
    {
        static bool isPrime(int n)
        {    // создаем функцию,которая будет проверять число, прайм оно или нет,задаем параметры тру ии фолс
            if (n == 1) return false;
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }



        static void Main(string[] args)
        {
            string a = Console.ReadLine();//считываем первую строку
            int b = int.Parse(a); // переводим первую строку в число через парс
            
    
            string a1 = Console.ReadLine();// считываем вторую строку
            string[] b1 = a1.Split(' ');// разделяем по признаку ,здесь это пробел, и заносим в массив,каждая подстрока хранится отдельно

            List <int>  num = new List <int> (); //создаем лист в который будем заносить числа прошедшие через функцию
            for (int i = 0; i < b1.Length; i++) // создаем цикл, пробегаемся по всем подстрокам до последнего элемента в массиве
            {
                int c = int.Parse( b1[i] ); // каждый элемент массива переводим из строки в число

                if (isPrime(c)==true) // проверяем число по функции и если оно верно,заносим число в лист
                {
                    num.Add(c);
                }
            }
            Console.WriteLine(num.Count);//выводим число после подсчета всех элементов в листе num
               for (int i=0; i < num.Count; i++)// вводим цикл чтобы вывести все итые значения в листе
            {
                Console.WriteLine(num[i]);
                
            }
        
        }
    }
}
