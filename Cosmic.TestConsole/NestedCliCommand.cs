using System.CommandLine;
using System.CommandLine.Invocation;
using Cosmic.CommandLine;
using Cosmic.CommandLine.Attributes;


namespace Cosmic.TestConsole;

[CliCommand(parent: typeof(TestCliCommand), path: "nested", description: "A nested command" )]
public class NestedCliCommand : CliCommand
{
    [CliArgument("operation", "description")]
    public static readonly Argument<string> OperationArgument = new("operation", "The operation to perform");
    
    [CliOption("option", "description")]
    public static Option<string> OperationOption = new("operation", "The operation to perform");
    
    protected override Task<int> ExecuteCommand(CliCommandContext context)
    {
        string arg1 = context.Argument<string>(OperationArgument);
        foreach (Argument argument in Arguments)
        {
            Console.WriteLine(argument.Name);
        }
        return Task.FromResult(0);
    }
}