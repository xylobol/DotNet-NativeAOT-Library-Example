using System.Runtime.InteropServices;

public static partial class Program
{
    [LibraryImport(@"C:\src\DotNet-NativeAOT-Library-Example", EntryPoint = "native_add")]
    private static partial int Add(int a, int b);

    public static void Main()
    {
        Console.WriteLine(Add(500, 36));
    }
}