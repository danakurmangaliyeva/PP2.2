
using System;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());// строку переделываем в число

            for (int i=0; i < n ; i++)// создаем двумерный массив 
            {
                for (int j=0; j<=i; j++)
                {
                    Console.Write("[*]");//заполняем
                }
             Console.WriteLine( );// чтобы переходить на следующую строку
            }
            
        }
    }
}
