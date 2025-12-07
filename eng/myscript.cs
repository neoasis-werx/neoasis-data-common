#!/usr/bin/env dotnet
#:package Humanizer@3.0.1

using Humanizer;

Console.WriteLine($"Hello from C# script!  Humanized: {12345.ToWords()}");
Console.WriteLine($"BaseDirectory: {AppContext.BaseDirectory}");
Console.WriteLine($"CurrentDirectory: {Environment.CurrentDirectory}");
Console.WriteLine($"EntryPointFilePath: {AppContext.GetData("EntryPointFilePath")}");