using System;
using System.Diagnostics;

namespace minifmod4net
{
    /// <summary>
    /// Base class for types requires necessary Dispose() call after using instance of type.
    /// </summary>
    public class DisposingRequiredObjectBase : IDisposable
    {
        private bool isDisposed;
        /// <summary>
        /// Is object already disposed.
        /// </summary>
        public bool IsDisposed
        {
            get
            {
                return (isDisposed);
            }
        }

        /// <summary>
        /// Verifies that object was not disposed.
        /// If disposed, <see cref="ObjectDisposedException"/> will be thrown.
        /// </summary>
        protected void VerifyObjectIsNotDisposed()
        {
            if (isDisposed) {
                throw new ObjectDisposedException(ToString(), String.Format("This instance of {0} has been already disposed.", GetType()));
            }
        }

        /// <summary>
        /// Overridable method for release allocated resources from the derived types.
        /// </summary>
        /// <param name="isDisposing">isDisposing is True if using a determined destruction, False if called from finalizer.</param>
        protected virtual void Dispose(bool isDisposing)
        {
        }

        /// <summary>
        /// Cleanup all.
        /// </summary>
        public void Dispose()
        {
            if (!isDisposed) {
                isDisposed = true;
                //
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }


        /// <summary>
        /// Debug-style finalizer.
        /// </summary>
        ~DisposingRequiredObjectBase()
        {
#if DEBUG
            Debugger.Log(0, Debugger.DefaultCategory, String.Format("Finalizer of {0} has been called. The object has not been disposed correctly.\n", GetType()));
#endif
            //
            if (!isDisposed) {
                Dispose(false);
            }
        }
    }
}