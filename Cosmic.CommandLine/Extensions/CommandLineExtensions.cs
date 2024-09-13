using System.CommandLine;
using System.Reflection;
using Autofac;

namespace Cosmic.CommandLine.Extensions;

public static class CommandLineExtensions
{
    public static void RegisterCosmicCommands(this ContainerBuilder builder, string description)
    {
        builder.RegisterInstance(new RootCommand(description));
        builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly()!)
            .Where(t => t.IsAssignableTo<CliCommand>())
            .AsSelf();
    }
}