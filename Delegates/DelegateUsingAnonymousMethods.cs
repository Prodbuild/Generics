using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate.Three
{
    public delegate string GetValueDelegate(int count);
    class Program
    {
        static string[] studentNamesArray = null;
        static void Main(string[] args)
        {
            Student objStud = new Student();
            studentNamesArray = objStud.GetStudentNames();

            GetValueDelegate valDel = delegate(int counter)
            {
                var studentName = string.Empty;
                if (studentNamesArray != null && (counter > 0 && counter <= studentNamesArray.Length))
                { studentName = studentNamesArray[counter - 1]; }

                return studentName;
            };
            string name = objStud.GetName(valDel);

            Console.WriteLine("The name of the student is {0}", name);
            Console.ReadLine();
        }
    }
    public class Student
    {
        private string[] _studentNames = { "AShish", "Bob", "Christine", "David" };
        public string GetName(GetValueDelegate valDelgate)
        {
            return valDelgate(4);
        }
        public string[] GetStudentNames()
        {
            return this._studentNames;
        }
    }


}
