using System;
using System.Collections.Generic;
using System.Text;

namespace task2
{
    class Student
    {

        private string name;// создаем филды
        private string id;
        public int year;

        public Student(string name, string id)// создаем конструктор с двумя параметрами
        {
            this.name = name;
            this.id = id;
            year = 0; // указываем что по умолчанию год обучения 0,чтобы при инкременте увеличить его

        }
         
        public string getN()
        {
            return this.name;
        }
            public string getID()
        {
            return this.id;
        }

        private int incr()
        {
            return this.year + 1;
        }

    }
}
