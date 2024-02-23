using System.Runtime.InteropServices;

namespace ConsoleApp.NativeInterop;

/// <summary>
/// Represents a managed wrapper for an unmanaged string in the Mlx library.
/// </summary>
public class MlxString
{
    private readonly IntPtr _ptr;
    public MlxString(string str) => _ptr = MlxStringNew(str);
    public MlxString(IntPtr ptr) => _ptr = ptr;

    [DllImport("libmlxc",
        EntryPoint = "mlx_string_new",
        CallingConvention = CallingConvention.Cdecl,
        CharSet = CharSet.Ansi)]
    private static extern IntPtr MlxStringNew(string str);

    [DllImport("libmlxc",
        EntryPoint = "mlx_string_data",
        CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr MlxStringData(IntPtr str);

    /// <summary>
    /// Converts the unmanaged string to a managed string.
    /// </summary>
    /// <returns>The managed string representation of the unmanaged string.</returns>
    public override string ToString()
    {
        return Marshal.PtrToStringAnsi(MlxStringData(_ptr))!;
    }
}
