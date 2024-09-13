// See https://aka.ms/new-console-template for more information

using System.CommandLine;
using Autofac;
using Cosmic;
using Cosmic.Aspects.Logs;
using Cosmic.CommandLine;
using Cosmic.CommandLine.BuiltIn.Commands;
using Cosmic.CommandLine.Extensions;
using Cosmic.TestConsole;

CosmicApp app = new CliApp().RegisterDependencies(builder =>
    {
        builder.RegisterCosmicCommands("A sample commandline app.");
        builder.RegisterCosmicLogging();
        builder.RegisterType<DebugCommand>().As<CliCommand>().AsSelf().SingleInstance();
    })
    .AddConfigStep(app =>
    {
        RootCommand root = app.Container.Resolve<RootCommand>();
        root.AddCommand(app.Container.Resolve<DebugCommand>());
        root.AddCommand(app.Container.Resolve<TestCliCommand>());
    }).SetInitiator(container => container.Resolve<RootCommand>().InvokeAsync(args))
    .Build();

app.Start();