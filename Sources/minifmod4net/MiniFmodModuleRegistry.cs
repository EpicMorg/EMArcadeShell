using System;
using System.Collections.Generic;

namespace minifmod4net
{
    public sealed class MiniFmodModuleRegistry
    {
        private sealed class MiniFmodModuleImpl : MiniFmodModule
        {
            private readonly MiniFmodModuleRegistry registry;

            public MiniFmodModuleImpl(int id, MiniFmodModuleRegistry registry) : base(id)
            {
                this.registry = registry;
            }

            protected override void Dispose(bool isDisposing)
            {
                try {
                    registry.freeModule(base.ID);
                } finally {
                    base.Dispose(isDisposing);
                }
            }
        }

        private readonly Dictionary<int, MiniFmodModuleImpl> modules = new Dictionary<int, MiniFmodModuleImpl>();

        private void freeModule(int id)
        {
            if (!modules.ContainsKey(id)) {
                throw new InvalidOperationException("No module registered with this id.");
            }
            MiniFmodFacadeInterop.FreeModule(id);
            modules.Remove(id);
        }

        private void registerModule(int id, MiniFmodModuleImpl moduleImpl)
        {
            if (modules.ContainsKey(id)) {
                throw new ArgumentException("Module with specified id is registered already.", "id");
            }
            modules.Add(id, moduleImpl);
        }

        public MiniFmodModule LoadFromFile(int id, string fileName)
        {
            if (null == fileName) {
                throw new ArgumentNullException("fileName");
            }
            if (fileName.Length == 0) {
                throw new ArgumentException("String is empty.", "fileName");
            }
            if (!MiniFmodFacadeInterop.LoadModuleFromFile(id, fileName)) {
                throw new MiniFmodException(string.Format("Cannot load module from file {0}", fileName));
            }
            MiniFmodModuleImpl moduleImpl = new MiniFmodModuleImpl(id, this);
            registerModule(id, moduleImpl);
            return moduleImpl;
        }

        public MiniFmodModule LoadFromMemory(int id, byte[] data)
        {
            if (null == data) {
                throw new ArgumentNullException("data");
            }
            if (!MiniFmodFacadeInterop.LoadModuleFromMemory(id, data)) {
                throw new MiniFmodException(string.Format("Cannot load module from memory."));
            }
            MiniFmodModuleImpl moduleImpl = new MiniFmodModuleImpl(id, this);
            registerModule(id, moduleImpl);
            return moduleImpl;
        }
    }
}
