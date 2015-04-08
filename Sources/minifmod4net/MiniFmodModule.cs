namespace minifmod4net
{
    public class MiniFmodModule : DisposingRequiredObjectBase
    {
        internal MiniFmodModule()
        {
        }

        public int ID
        {
            get;
            private set;
        }

        public MiniFmodModule(int id)
        {
            ID = id;
        }

        public void Play()
        {
            VerifyObjectIsNotDisposed();
            
            MiniFmodFacadeInterop.PlayModule(ID);
        }

        public void Stop()
        {
            VerifyObjectIsNotDisposed();

            MiniFmodFacadeInterop.StopModule(ID);
        }

        public int GetCurrentOrder()
        {
            VerifyObjectIsNotDisposed();

            return MiniFmodFacadeInterop.GetCurrentOrder(ID);
        }

        public int GetCurrentRow()
        {
            VerifyObjectIsNotDisposed();

            return MiniFmodFacadeInterop.GetCurrentRow(ID);
        }

        public int GetCurrentTime()
        {
            VerifyObjectIsNotDisposed();

            return MiniFmodFacadeInterop.GetCurrentTime(ID);
        }
    }
}
