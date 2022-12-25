# DotNet-NativeAOT-Library-Example
An example of how to NativeAOT-compile a shared library written on the .NET platform

## How to run this

This assumes you're running Windows, but could be ported over to macOS/Linux with minimal effort. Update the solution root in CallingProgram/Program.cs, and run the CallingProgram project. It'll run the commands to compile ExampleLibrary automatically at runtime. 

## What it's doing

ExampleLibrary exports two methods with the UnmanagedCallersOnly attribute. For your own libraries, you'll need to put `<PublishAot>true</PublishAot>` in the csproj. CallingProgram also happens to be written in C#, but I could've done it in any language that can call C functions. CallingProgram helps by automatically compiling ExampleLibrary with `dotnet publish /p:NativeLib=Shared -r win-x64 -c Release`, then calling into the functions with LibraryImport. 