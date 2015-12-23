using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Patterns.SingletonTwo
{
    public sealed class Customer
    {
        private static readonly Customer customerInstance = new Customer();

        private Customer()
        {

        }

        public static Customer GetCustomerInstance
        {
            get
            {
                return customerInstance;
            }
        }

    }
}
