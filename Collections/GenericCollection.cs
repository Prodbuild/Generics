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
        static void Main_xyz(string[] args)
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

            var searchedCustomer1 = customerList.Select((x) => new { Name = x.CustomerName, Id = x.CustomerId });



            var searchedCustomer = customerList.Where(x => x.CustomerName.StartsWith("A"));

            //var searchedCustomer = from cust in customerList
            //                        where cust.CustomerName.StartsWith("A")
            //                        select cust;

            foreach (var customer in searchedCustomer1)
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

            Dictionary<string, Customer> dictCollection = new Dictionary<string, Customer>();

            dictCollection.Add("A", new Customer
            {
                CustomerId = 321,
                CustomerName = "Ashish",
                Orders = new List<string> { "order_1", "order_2", "order_3" }
            });

            dictCollection.Add("C", new Customer
            {
                CustomerId = 988,
                CustomerName = "Ashish",
                Orders = new List<string> { "order_1", "order_2", "order_3" }
            });

            dictCollection.Add("D", new Customer
            {
                CustomerId = 1234,
                CustomerName = "Ashish",
                Orders = new List<string> { "order_1", "order_2", "order_3" }
            });


            foreach (KeyValuePair<string, Customer> keyVal in dictCollection)
            {
                Console.WriteLine("key : {0}", keyVal.Key);
                Console.WriteLine("value : {0} class :  CustomerId : {1}", keyVal.Value.GetType().Name, keyVal.Value.CustomerId);
                Console.WriteLine("                     CustomerName : {0}", keyVal.Value.CustomerName);

                Console.WriteLine("==========================================");

            }

            Console.WriteLine("Please enter any keys ");
            string strKey = Console.ReadLine();

            dictCollection.Add("B", new Customer
            {
                CustomerId = 456,
                CustomerName = "Ashish",
                Orders = new List<string> { "order_1", "order_2", "order_3" }
            });

            //try
            //{
            //    var customer = dictCollection[strKey.ToUpper()];
            //    Console.WriteLine("{0}", customer.CustomerId);
            //    Console.WriteLine(customer.CustomerName);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}


            if (dictCollection.ContainsKey(strKey.ToUpper()))
            {
                var customer = dictCollection[strKey.ToUpper()];
                Console.WriteLine("{0}", customer.CustomerId);
                Console.WriteLine(customer.CustomerName);
            }

            Console.WriteLine("==========================================");

            Customer cust = new Customer { CustomerId = 988, CustomerName = "Ashish" };

            Console.WriteLine("{0}", dictCollection.ContainsValue(cust));

            Console.WriteLine("==========================================");

            string key = "D";
            Customer customerToBeRetrieved;
            if (dictCollection.TryGetValue(key, out customerToBeRetrieved))
            {
                Console.WriteLine("{0}", customerToBeRetrieved.CustomerId);
                Console.WriteLine("{0}", customerToBeRetrieved.CustomerName);

            }

            foreach (var item in dictCollection.SelectMany(kvp => kvp.Value.Orders))
            {
                Console.WriteLine("{0}", item);
            }

            dictCollection.Any(kvp => kvp.Value.CustomerId == 989);


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
