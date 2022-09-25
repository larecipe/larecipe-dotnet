using System.CommandLine;
using System.CommandLine.NamingConventionBinder;

namespace LaRecipe.Cli;

public static class InstallCommand
{
    public static Command Create() =>
        new ("install", "Create initial documentation files.")
        {
            Handler = CommandHandler.Create<InitCommandArguments>(_ =>
            {
                Console.WriteLine("Created documentation files.");
            })
        };

    private class InitCommandArguments
    {
    }
}