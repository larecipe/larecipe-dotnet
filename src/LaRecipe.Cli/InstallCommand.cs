using System.CommandLine;
using System.CommandLine.NamingConventionBinder;

namespace LaRecipe.Cli;

public static class InstallCommand
{
    public static Command Create()
    {
        var command = new Command("install", "Create initial documentation files.");
        
        command.Handler = CommandHandler.Create<InitCommandArguments>(args =>
        {
            Console.WriteLine("Created documentation files.");
        });

        return command;
    }
    
    private class InitCommandArguments
    {
    }
}