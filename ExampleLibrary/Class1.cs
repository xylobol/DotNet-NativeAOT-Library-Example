using System.Runtime.InteropServices;

namespace ExampleLibrary;

public class Class1
{
    // the name of the exported function is "native_add"
    [UnmanagedCallersOnly(EntryPoint = "native_add")]
    public static int Add(int a, int b) => a + b;

    [UnmanagedCallersOnly(EntryPoint = "hello")]
    public static void Hello() => Console.WriteLine("Hello, world!  -- from the NativeAOT compiled shared library");
}