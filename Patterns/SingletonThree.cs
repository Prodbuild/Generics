using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Patterns.SingletonThree
{
    public sealed class Customer
    {
        private static volatile Customer customerInstance = null;
        private static object lockingObject = new object();

        private Customer()
        { }

        public static Customer GetCustomerInstance
        {
            get
            {
                if (customerInstance == null)
                {
                    lock (lockingObject)
                    {
                        if (customerInstance == null)
                        {
                            customerInstance = new Customer();
                        }
                    }
                }

                return customerInstance;
            }
        }

    }
}
