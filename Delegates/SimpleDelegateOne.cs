using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate.One
{
    public delegate string GetValueDelegate(int count);

    class Program
    {
        static void Main_One(string[] args)
        {

            Student stud = new Student();

            GetValueDelegate getValDel = new GetValueDelegate(stud.GetStudentName);
            string name = getValDel(3);

            Console.WriteLine("The name of the student is {0}", name);
            Console.ReadLine();

        }
    }

    public class Student
    {
        private string[] _studentNames = { "AShish", "Bob", "Christine", "David" };

        public string GetStudentName(int index)
        {
            var name = string.Empty;
            if (this._studentNames != null && (index > 0 && index <= this._studentNames.Length))
            {
                name = this._studentNames[index - 1];
            }
            return name;
        }
    }
}
