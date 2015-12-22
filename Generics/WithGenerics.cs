using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Two
{

    class Program
    {
        static void Main_One(string[] args)
        {
            #region With Custom Type

            Container<Student> objContainer = new Container<Student>();

            for (var i = 0; i < 50; i++)
            {
                Student objStudent = new Student
                {
                    StudentName = "A" + Convert.ToString(i + 1),
                    RollNumber = (i + 1)
                };

                objContainer.Add(objStudent);
            }

            foreach (var item in objContainer.GetAll())
            {
                Console.WriteLine("The name of the Student is {0}", item.StudentName);
            }

            #endregion

            #region With Primitive Type

            Container<int> objCont = new Container<int>();

            for (var i = 0; i < 50; i++)
            {
                objCont.Add(i + 1);
            }

            foreach (var item in objCont.GetAll())
            {
                Console.WriteLine("The item is {0}", item);
            }
            #endregion


            Console.ReadLine();

        }

    }

    public class Container<T>
    {
        private T[] _itemCollection = new T[50];

        public bool Add(T itemToBeInserted)
        {
            bool isItemInserted = false;

            for (int i = 0; i < this._itemCollection.Length; i++)
            {
                if (EqualityComparer<T>.Default.Equals(this._itemCollection[i], default(T)))
                {
                    this._itemCollection[i] = itemToBeInserted;
                    isItemInserted = true;

                    break;
                }
            }

            return isItemInserted;
        }


        public T Get(int indexOfItemToRetrieve)
        {
            T itemToBeRetrived = default(T);

            if (this._itemCollection != null &&
                (indexOfItemToRetrieve > 0 && (indexOfItemToRetrieve < this._itemCollection.Length - 1)))
            {
                itemToBeRetrived = this._itemCollection[indexOfItemToRetrieve];
            }

            return itemToBeRetrived;
        }

        public T[] GetAll()
        {
            return this._itemCollection;
        }
    }

    public class Student
    {
        public int RollNumber { get; set; }

        public string StudentName { get; set; }
    }

}
