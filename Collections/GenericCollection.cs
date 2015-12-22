using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.GenericCollection
{

    class Program
    {
        static void Main(string[] args)
        {

            #region Using List

            List<Customer> customerList = new List<Customer>();

            customerList.Add(new Customer
            {
                CustomerId = 456,
                CustomerName = "Shakti",
                Orders = new List<string>
                {
                    "Order_01",
                    "Order_02",
                    "Order_03"
                }

            });

            customerList.Add(new Customer
            {
                CustomerId = 678,
                CustomerName = "Shanti",
                Orders = new List<string>
                {
                    "Order_11",
                    "Order_12",
                    "Order_13"
                }
            });

            customerList.Add(new Customer
            {
                CustomerId = 456,
                CustomerName = "Anish",
                Orders = new List<string>
                {
                    "Order_21",
                    "Order_22",
                    "Order_23"
                }
            });

            customerList.Add(new Customer
            {
                CustomerId = 456,
                CustomerName = "Aravind",
                Orders = new List<string>
                {
                    "Order_31",
                    "Order_32",
                    "Order_33"
                }
            });


            //var searchedCustomer = customerList.Where(x => x.CustomerName.StartsWith("A"));

            var searchedCustomer = from cust in customerList
                                   where cust.CustomerName.StartsWith("A")
                                   select cust;

            foreach (var customer in searchedCustomer)
            {
                Console.WriteLine("{0} : {1}", customer.CustomerId, customer.CustomerName);
            }

            Console.WriteLine("===============================================================");

            var refinedCustomer = customerList.Where((x, i) => (i % 2 == 0 && x.CustomerName.StartsWith("A")));
            foreach (var customer in refinedCustomer)
            {
                Console.WriteLine("{0} : {1}", customer.CustomerId, customer.CustomerName);
            }

            Console.WriteLine("===============================================================");

            var orderCollections = customerList.Select(c => c.Orders);

            foreach (var item in orderCollections)
            {
                for (int i = 0; i < item.Count; i++)
                {
                    Console.WriteLine("{0}", item[i]);
                }
            }


            Console.WriteLine("===============================================================");

            var orderColl = customerList.SelectMany(c => c.Orders);

            foreach (var item in orderColl)
            {
                Console.WriteLine("{0}", item);
            }



            #endregion

            #region Using Dictionary



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

            public List<string> Orders { get; set; }
        }




    }
}
