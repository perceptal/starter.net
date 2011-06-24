using System;

namespace Core
{
    public abstract class Disposable : IDisposable
    {
        private bool Disposed { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                if (disposing)
                {
                    DisposeManagedResources();
                }

                DisposeUnmanagedResources();
                this.Disposed = true;
            }
        }

        protected void ThrowExceptionIfDisposed()
        {
            if (this.Disposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }

        protected abstract void DisposeManagedResources();
        protected virtual void DisposeUnmanagedResources() { }
    }
}
