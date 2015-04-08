using System;
using System.Runtime.InteropServices;
using System.Security;

namespace minifmod4net
{
    public static class MiniFmodFacadeInterop
    {
        [DllImport("MiniFmodFacade.dll", CallingConvention = CallingConvention.StdCall,
            EntryPoint = "XM_LoadModuleFromFile", ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern bool LoadModuleFromFile(int id, [MarshalAs(UnmanagedType.LPStr)] string fileName);

        [DllImport("MiniFmodFacade.dll", CallingConvention = CallingConvention.StdCall,
            EntryPoint = "XM_LoadModuleFromMemory", ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        private static extern bool LoadModuleFromMemoryCore(int id, IntPtr data, int bytesCount, bool copyMemory);

        public static bool LoadModuleFromMemory(int id, byte[] data)
        {
            if (null == data) {
                throw new ArgumentNullException("data");
            }
            //
            IntPtr ptr = IntPtr.Zero;
            try {
                ptr = Marshal.AllocHGlobal(data.Length);
                Marshal.Copy(data, 0, ptr, data.Length);

                return LoadModuleFromMemoryCore(id, ptr, data.Length, true);
            } finally {
                Marshal.FreeHGlobal(ptr);
            }
        }

        [DllImport("MiniFmodFacade.dll", CallingConvention = CallingConvention.StdCall,
            EntryPoint = "XM_FreeModule", ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void FreeModule(int id);

        [DllImport("MiniFmodFacade.dll", CallingConvention = CallingConvention.StdCall,
            EntryPoint = "XM_PlayModule", ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void PlayModule(int id);

        [DllImport("MiniFmodFacade.dll", CallingConvention = CallingConvention.StdCall,
            EntryPoint = "XM_StopModule", ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void StopModule(int id);


        [DllImport("MiniFmodFacade.dll", CallingConvention = CallingConvention.StdCall,
            EntryPoint = "XM_GetCurrentOrder", ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int GetCurrentOrder(int id);

        [DllImport("MiniFmodFacade.dll", CallingConvention = CallingConvention.StdCall,
            EntryPoint = "XM_GetCurrentRow", ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int GetCurrentRow(int id);

        [DllImport("MiniFmodFacade.dll", CallingConvention = CallingConvention.StdCall,
            EntryPoint = "XM_GetCurrentTime", ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int GetCurrentTime(int id);

    }
}
