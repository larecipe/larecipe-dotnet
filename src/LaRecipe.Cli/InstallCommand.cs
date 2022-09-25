using System.CommandLine;
using System.CommandLine.NamingConventionBinder;
using System.Reflection;
using Microsoft.Extensions.FileProviders;

namespace LaRecipe.Cli;

public static class InstallCommand
{
    private const string EmbeddedFileNamespace = "LaRecipe.Cli";
    
    public static Command Create() =>
        new ("install", "Create initial documentation files.")
        {
            Handler = CommandHandler.Create<InitCommandArguments>(_ =>
            {
                var fileProvider = new EmbeddedFileProvider(typeof(InstallCommand).GetTypeInfo().Assembly, "LaRecipe.Cli.Stubs");
                var stubs = fileProvider.GetDirectoryContents(@"");
                
                foreach (var stub in stubs)
                {
                    File.Create($"Documentation/{stub.Name}");
                }
                
                Console.WriteLine("Created documentation files.");
            })
        };

    private class InitCommandArguments
    {
    }
}