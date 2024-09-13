using System.ComponentModel;
using System.Text;
using Autofac.Core;
using Cosmic.CommandLine.Attributes;

namespace Cosmic.CommandLine.BuiltIn.Commands;

[CliCommand("debug", "Debugs the application")]
public class DebugCommand : CliCommand
{
    protected override Task<int> ExecuteCommand(CliCommandContext context)
    {
        var sb = new StringBuilder();
        foreach (var registration in context.Container.ComponentRegistry.Registrations)
        {
            sb.AppendLine($"Service: {registration.Activator.LimitType.FullName}");
            sb.AppendLine($"Lifetime: {registration.Lifetime.GetType().Name}");
            sb.AppendLine($"Sharing: {registration.Sharing}");
            sb.AppendLine($"Ownership: {registration.Ownership}");
            sb.AppendLine(new string('-', 50));
        }

        Console.WriteLine(sb.ToString());
        return Task.FromResult(0);
    }
}