using System.CommandLine;
using System.CommandLine.Invocation;

using System.Dynamic;
using Autofac;

namespace Cosmic.CommandLine;

public class CliCommandContext
{
    public InvocationContext InvocationContext { get; set; }
    public IContainer Container { get; set; }
    
    public T Argument<T>(Argument arg)
    {
        return (T)InvocationContext.ParseResult.CommandResult.GetValueForArgument(arg)!;
    }
    
    public T Option<T>(Option opt)
    {
        return (T)InvocationContext.ParseResult.CommandResult.GetValueForOption(opt)!;
    }
}