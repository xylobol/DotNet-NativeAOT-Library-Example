using System.Runtime.InteropServices;

namespace CallingProgram;

public static partial class Program
{
    private const string ProjectRoot = @"C:\src\DotNet-NativeAOT-Library-Example";
    
    // this function just builds the library
    private static void BuildLibrary()
    {
        Console.WriteLine("Building ExampleLibrary...");
        
        Console.WriteLine($"Running `dotnet publish /p:NativeLib=Shared -r win-x64 -c Release` in {ProjectRoot}/ExampleLibrary/");
        
        var process = new System.Diagnostics.Process();
        process.StartInfo = new System.Diagnostics.ProcessStartInfo
        {
            WorkingDirectory = $"{ProjectRoot}/ExampleLibrary/",
            WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
            FileName = "dotnet",
            Arguments = @"publish /p:NativeLib=Shared -r win-x64 -c Release"
        };
        process.Start();
        process.WaitForExit();
        
        Console.WriteLine("Build completed");
    }
    
    // this imports the DLL built by BuildLibrary
    [LibraryImport($"{ProjectRoot}/ExampleLibrary/bin/Release/net7.0/win-x64/native/ExampleLibrary.dll", EntryPoint = "native_add")]
    private static partial int Add(int a, int b);

    public static void Main()
    {
        BuildLibrary();

        // run the imported DLL
        var num = Add(500, 36);
        
        Console.WriteLine(num);
    }
}