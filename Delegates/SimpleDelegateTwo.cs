using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate.Two
{
    public delegate string GetValueDelegate(int count);

    class Program
    {
        static string[] studentNamesArray = null;

        static void Main_1(string[] args)
        {
            Student objStud = new Student();
            studentNamesArray = objStud.GetStudentNames();

            GetValueDelegate valDelegate = GetSpecificName;

            string name = objStud.GetName(valDelegate, 4);
            Console.WriteLine("The name of the student is {0}", name);

            Console.ReadLine();

        }

        static string GetSpecificName(int counter)
        {
            var name = string.Empty;

            if (studentNamesArray != null && (counter > 0 && counter <= studentNamesArray.Length))
            {
                name = studentNamesArray[counter - 1];
            }

            return name;
        }

    }

    public class Student
    {
        private string[] _studentNames = { "AShish", "Bob", "Christine", "David" };

        public string GetName(GetValueDelegate valDelgate, int counter)
        {
            return valDelgate(counter);
        }

        public string[] GetStudentNames()
        {
            return this._studentNames;
        }
    }


}
