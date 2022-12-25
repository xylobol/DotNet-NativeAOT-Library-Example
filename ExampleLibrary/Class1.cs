using System.Runtime.InteropServices;

namespace ExampleLibrary;

public class Class1
{
    [UnmanagedCallersOnly(EntryPoint = "native_add")]
    public static int Add(int a, int b) => a + b;
}