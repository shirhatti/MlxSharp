using System.Runtime.InteropServices;
using ConsoleApp.NativeInterop.Types;

namespace ConsoleApp.NativeInterop;

public class MLXDevice
{
    private readonly IntPtr _ptr;

    [DllImport("libmlxc",
        EntryPoint = "mlx_device_new",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr MlxDeviceNew(MLXDeviceType deviceType, int index);

    public MLXDevice(MLXDeviceType deviceType, int index)
    => _ptr = MlxDeviceNew(deviceType, index);

    private MLXDevice(IntPtr ptr)
    => _ptr = ptr;

    [DllImport("libmlxc",
        EntryPoint = "mlx_device_get_type",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern MLXDeviceType MlxDeviceGetType(IntPtr dev);

    public MLXDeviceType GetDeviceType()
    => MlxDeviceGetType(_ptr);

    [DllImport("libmlxc",
        EntryPoint = "mlx_default_device",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr MlxDefaultDevice();

    public static MLXDevice GetDefaultDevice()
    => new(MlxDefaultDevice());

    [DllImport("libmlxc",
        EntryPoint = "mlx_set_default_device",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr MlxSetDefaultDevice(IntPtr device);

    public static void SetDefaultDevice(MLXDevice device)
    => MlxSetDefaultDevice(device._ptr);
}
