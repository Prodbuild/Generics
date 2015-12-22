using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.One
{

    class Program
    {
        static void Main_one(string[] args)
        {
            #region With Custom Type

            Container objContainer = new Container();

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
                Student std = (Student)item;
                Console.WriteLine("The name of the Student is {0}", std.StudentName);
            }
            #endregion

            #region With Primitive Type

            Container objCont = new Container();

            for (var i = 0; i < 50; i++)
            {
                objCont.Add(i + 1);
            }

            foreach (var item in objCont.GetAll())
            {
                int i = Convert.ToInt32(item);
                Console.WriteLine("The item is {0}", i);
            }
            #endregion


            Console.ReadLine();

        }

    }

    public class Container
    {
        private object[] _itemCollection = new object[50];
        public bool Add(object itemToBeInserted)
        {
            bool isItemInserted = false;

            for (int i = 0; i < this._itemCollection.Length; i++)
            {
                if (this._itemCollection[i] == null)
                {
                    this._itemCollection[i] = itemToBeInserted;
                    isItemInserted = true;

                    break;
                }
            }

            return isItemInserted;
        }
        public object Get(int indexOfItemToRetrieve)
        {
            object itemToBeRetrived = null;

            if (this._itemCollection != null &&
                (indexOfItemToRetrieve > 0 && (indexOfItemToRetrieve < this._itemCollection.Length - 1)))
            {
                itemToBeRetrived = this._itemCollection[indexOfItemToRetrieve];
            }

            return itemToBeRetrived;
        }
        public object[] GetAll()
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
