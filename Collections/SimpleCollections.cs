using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.SimpleCollection
{

    class Program
    {
        static void Main_One(string[] args)
        {

            #region Using ArrayList

            //ArrayList list = new ArrayList();

            //list.Add(new Customer
            //{
            //    CustomerId = 1234,
            //    CustomerName = "abc"
            //});

            //list.Add(new Customer
            //{
            //    CustomerId = 456
            //    ,
            //    CustomerName = "abc"
            //});

            //list.Add(new Customer
            //{
            //    CustomerId = 789
            //    ,
            //    CustomerName = "hkh"
            //});

            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine("Customer Name : {0}", ((Customer)list[i]).CustomerName);
            //    Console.WriteLine("Customer Id : {0}", ((Customer)list[i]).CustomerId);

            //}

            //list.Sort(new Customer());

            //Console.WriteLine("With Sorting =====================================");

            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine("Customer Name : {0}", ((Customer)list[i]).CustomerName);
            //    Console.WriteLine("Customer Id : {0}", ((Customer)list[i]).CustomerId);
            //}

            //Console.WriteLine("With Searching =====================================");

            //var index = list.BinarySearch(new Customer { CustomerId = 789 }, new Customer());

            //Console.WriteLine("The index of the searched item is {0}", index);
            //Console.WriteLine("The CustomerId of the searched Customer {0}", ((Customer)list[index]).CustomerId);
            //Console.WriteLine("The name of the searched Customer {0}", ((Customer)list[index]).CustomerName);

            #endregion

            #region Using Hashtable

            Hashtable hashCollection = new Hashtable();

            hashCollection.Add(123, new Customer
            {
                CustomerId = 321,
                CustomerName = "Ashis"
            });

            hashCollection.Add(562, new Customer
            {
                CustomerId = 456,
                CustomerName = "Avhishek"
            });

            hashCollection.Add(545, new Customer
            {
                CustomerId = 687,
                CustomerName = "Anish"
            });

            Console.WriteLine("Item retrieval with keys ==================");

            foreach (var item in hashCollection.Keys)
            {
                var customer = (Customer)hashCollection[item];
                Console.WriteLine("{0} : {1}", new object[] { customer.CustomerId, customer.CustomerName });
            }

            Console.WriteLine("Item retrieval with values ==================");

            foreach (var item in hashCollection.Values)
            {
                var customer = (Customer)item;
                Console.WriteLine("{0} : {1}", new object[] { customer.CustomerId, customer.CustomerName });
            }

            //// use type's Equals method to determine if they are same ==
            //Console.WriteLine("{0}", hashCollection.ContainsValue(new Customer
            //{
            //    CustomerId = 687,
            //    CustomerName = "Anish"
            //}));

            #endregion

            Console.ReadLine();

        }

        public class Customer : IComparer
        {
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }

            // used for searching 
            public int Compare(object x, object y)
            {
                return Comparer<int>.Default.Compare(((Customer)x).CustomerId, ((Customer)y).CustomerId);
            }

            public override bool Equals(object obj)
            {
                Customer cust = (Customer)obj;
                return (cust.CustomerId == this.CustomerId && cust.CustomerName == this.CustomerName) ? true : false;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }


        }




    }
}
