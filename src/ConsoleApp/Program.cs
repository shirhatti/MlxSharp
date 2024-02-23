using ConsoleApp.NativeInterop;

namespace ConsoleApp;

public class Program
{
    private static void Main(string[] args)
    {
        var s = new MlxString("Hello, World!");
        var device = MLXDevice.GetDefaultDevice();
        Console.WriteLine($"Default device type: {device.GetDeviceType()}");
    }
}
