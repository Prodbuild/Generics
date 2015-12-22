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

        static void Main_Three(string[] args)
        {
            Student objStud = new Student();
            studentNamesArray = objStud.GetStudentNames();

            string name = objStud.GetName(
                delegate(int counter)
                {
                    var studentName = string.Empty;

                    if (studentNamesArray != null && (counter > 0 && counter <= studentNamesArray.Length))
                    {
                        studentName = studentNamesArray[counter - 1];
                    }

                    return studentName;
                }, 4);

            Console.WriteLine("The name of the student is {0}", name);

            Console.ReadLine();

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
