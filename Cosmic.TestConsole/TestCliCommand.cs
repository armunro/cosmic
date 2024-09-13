using System.CommandLine;
using System.CommandLine.Invocation;
using Cosmic.CommandLine;
using Cosmic.CommandLine.Attributes;


namespace Cosmic.TestConsole;

[CliCommand("test", "A test command")]
public class TestCliCommand : CliCommand
{
    [CliArgument("operation", "description")]
    public static Argument<string> OperationArgument = CliArgument.NewArgument<string>();

    [CliOption("--opt", "The option")] 
    public static Option<string> OperationOption = CliOption.NewOption<string>();


    protected override Task<int> ExecuteCommand(CliCommandContext context)
    {
        foreach (Argument argument in Arguments) Console.WriteLine(argument.Name);
        foreach (Option option in Options) Console.WriteLine(option.Name);

        return Task.FromResult(0);
    }
}