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

        public static bool isPolin(string a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != a[a.Length - i - 1]) return false;
            }
        return true;
        }

        
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"C:\Users\Мартышка\Desktop\input.txt");


            string s = sr.ReadToEnd();
            if (isPolin(s) == true)
                Console.WriteLine("YES");
            else Console.WriteLine("NO");
        }
    }
}
