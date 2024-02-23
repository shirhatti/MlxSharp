using System.Runtime.InteropServices;

namespace ConsoleApp.NativeInterop;

public static class MlxObject
{
    [DllImport("libmlxc",
        EntryPoint = "mlx_tostring",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr MlxToString(IntPtr obj);

    [DllImport("libmlxc",
        EntryPoint = "mlx_retain",
        CallingConvention = CallingConvention.Cdecl)]
    public static extern void MlxRetain(IntPtr obj);

    [DllImport("libmlxc",
        EntryPoint = "mlx_free",
        CallingConvention = CallingConvention.Cdecl)]
    public static extern void MlxFree(IntPtr obj);
}
