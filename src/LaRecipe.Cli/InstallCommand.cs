using System.Text;
using System.Reflection;
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
                var targetPath =  $@"{Directory.GetCurrentDirectory()}/Documentation";
                Directory.CreateDirectory(targetPath);
                
                foreach (var fileName in new [] {"index", "overview"})
                {
                    var reader = new StreamReader(GetFileStream(fileName));
                    
                    var fileStringContent = new StringBuilder(reader.ReadToEnd()).ToString();
                    
                    File.WriteAllText( Path.Combine(targetPath, $"{fileName}.md"), fileStringContent);
                }

                Console.WriteLine("Created documentation files.");
            })
        };
    
    private static Stream GetFileStream(string fileName) => Assembly.GetExecutingAssembly()
        .GetManifestResourceStream($"LaRecipe.Cli.Stubs.{fileName}.md")!;

    private class InitCommandArguments
    {
    }
}