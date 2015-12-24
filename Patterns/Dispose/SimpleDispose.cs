using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Patterns.Dispose
{
    public class Customer : IDisposable
    {
        private bool isDisposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    // free resources (managed objects) if any 
                }
                this.isDisposed = true;
            }
        }

        public virtual void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Customer()
        {
            Dispose(false);
        }
    }


    public class GoldCustomer : Customer
    {

        private bool isDisposed = false;


        protected override void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    // free unmanaged resources

                }

                this.isDisposed = true;
            }

            base.Dispose(disposing);
        }

        // The derived class does not have a Finalize method
        // or a Dispose method without parameters because it inherits
        // them from the base class.
    }

}
