using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Patterns.SingletonOne
{
    public sealed class Customer
    {
        private static Customer customerInstance;

        private Customer()
        {

        }


        public static Customer GetCustomerInstance
        {
            get
            {
                if (customerInstance == null)
                {
                    customerInstance = new Customer();
                }

                return customerInstance;
            }
        }

    }
}
