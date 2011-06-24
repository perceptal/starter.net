using System;
using System.Web;
using NHibernate;

namespace Core.Persistence.Implementation
{
    public class TransactionTracker : Disposable
    {
        public ITransaction ActiveTransaction { get; set; }

        public TransactionTracker(HttpContextBase context)
        {
            this.HttpContext = context;
        }

        private HttpContextBase HttpContext { get; set; }

        protected override void DisposeManagedResources()
        {
            if (this.ActiveTransaction == null)
            {
                return;
            }

            if (this.HttpContext.Error == null)
            {
                this.ActiveTransaction.Commit();
            }
            else
            {
                this.ActiveTransaction.Rollback();
            }
        }

        protected override void DisposeUnmanagedResources()
        {
            this.ActiveTransaction = null;
        }
    }
}
