using System;
using System.Web;
using NHibernate;

namespace Core.Persistence.Implementation
{
    public class TransactionTracker : Disposable
    {
        private ITransaction ActiveTransaction { get; set; }

        private HttpContextBase HttpContext { get; set; }

        public TransactionTracker(HttpContextBase context)
        {
            this.HttpContext = context;
        }

        public void SetActive(ITransaction transaction)
        {
            this.ActiveTransaction = transaction;
        }

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
