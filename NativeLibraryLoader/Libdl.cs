using System;
using System.Runtime.InteropServices;

namespace NativeLibraryLoader
{
    internal static class Libdl
    {
#if IOS || MACCATALYST
        //change according to:
        //https://github.com/xamarin/xamarin-macios/blob/main/src/ObjCRuntime/Dlfcn.cs
        //https://github.com/xamarin/xamarin-macios/blob/main/src/ObjCRuntime/Constants.cs
        private const string LibName = "/usr/lib/libSystem.dylib";
#else
        private const string LibName = "libdl";
#endif

        public const int RTLD_NOW = 0x002;

        [DllImport(LibName)]
        public static extern IntPtr dlopen(string fileName, int flags);

        [DllImport(LibName)]
        public static extern IntPtr dlsym(IntPtr handle, string name);

        [DllImport(LibName)]
        public static extern int dlclose(IntPtr handle);

        [DllImport(LibName)]
        public static extern string dlerror();
    }
}
