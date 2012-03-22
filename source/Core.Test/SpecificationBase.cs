using System;
using Rhino.Mocks;

namespace Xunit
{
    /// <summary>
    /// Base class for test fixtures
    /// </summary>
    public abstract class SpecificationBase : ISpecification, IDisposable
    {
        public MockRepository Mocks { get; set; }

        protected abstract void EstablishContext();
        
        protected virtual void Act()
        { }

        protected virtual void AfterEach()
        { }

        /// <summary>
        /// Is called to execute the test.
        /// </summary>
        void ISpecification.Act()
        {
            Act();
        }

        /// <summary>
        /// Is called to setup the context for the test.
        /// </summary>
        void ISpecification.EstablishContext()
        {
            this.Mocks = new MockRepository();

            EstablishContext();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            AfterEach();
        }

        protected IDisposable Record
        {
            get { return this.Mocks.Record(); }
        }

        protected IDisposable Playback
        {
            get { return this.Mocks.Playback(); }
        }

        protected T Mock<T>() where T : class
        {
            return this.Mocks.DynamicMock<T>();
        }

        protected T Partial<T>() where T : class
        {
            return this.Mocks.PartialMock<T>();
        }

        protected T Stub<T>()
        {
            return this.Mocks.Stub<T>();
        }

        protected void Verify(object mock)
        {
            this.Mocks.Verify(mock);
        }

        protected void VerifyAll()
        {
            this.Mocks.VerifyAll();
        }

        protected void ReplayAll()
        {
            this.Mocks.ReplayAll();
        }
    }
}