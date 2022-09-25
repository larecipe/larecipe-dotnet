using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using LaRecipe.Cli;

var command = new RootCommand
{
    Description = "LaRecipe Commands",
};

command.AddCommand(InstallCommand.Create());

var builder = new CommandLineBuilder(command);
builder.UseHelp();
builder.UseParseErrorReporting();

builder.CancelOnProcessTermination();

var parser = builder.Build();
parser.InvokeAsync(args);

