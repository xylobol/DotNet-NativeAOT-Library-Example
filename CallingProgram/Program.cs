using System.Runtime.InteropServices;

namespace CallingProgram;

public static partial class Program
{
    private const string ProjectRoot = @"C:\src\DotNet-NativeAOT-Library-Example";
    
    [LibraryImport($"{ProjectRoot}/ExampleLibrary/bin/Release/net7.0/win-x64/native/ExampleLibrary.dll", EntryPoint = "native_add")]
    private static partial int Add(int a, int b);

    public static void Main()
    {
        Console.WriteLine(Add(500, 36));
    }
}