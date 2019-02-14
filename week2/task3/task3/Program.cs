using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace task3
{
    class Program
    {


        public static void space(int level){
            for (int i = 0; i < level*4; i++)
            {
                Console.Write(' ');
            }

        }

        static void output(string path, int level)
        {
            DirectoryInfo di = new DirectoryInfo(path);


            FileInfo[] fi = di.GetFiles();

            DirectoryInfo[] di1 = di.GetDirectories();
            foreach (FileInfo f in fi)
            {
                space(level);
                Console.WriteLine(f.Name);
                
            }
            foreach (DirectoryInfo d in di1)
            {
                space(level);
                Console.WriteLine(d.Name);

            output(d.FullName, level++);
            }
            
        }


        static void Main(string[] args)
        {
            output(@"C:\Users\Public\Desktop", 0);
        }
    }
}
