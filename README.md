# cosmic


## Cosmic

## Cosmic.CommandLine

### CLI Setup
```csharp
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
```

### Defining Commands
Commands arguments and attributes are automatically registered using the `RegisterCosmicCommands` method in the CLI setup.
```csharp
[CliCommand("test", "A test command")]
public class TestCliCommand : CliCommand
{
    [CliArgument("operation", "description")]
    public static Argument<string> DescriptionArgument = CliArgument.NewArgument<string>();

    [CliOption("--opt", "The option")] 
    public static Option<string> OperationOption = CliOption.NewOption<string>();


    protected override Task<int> ExecuteCommand(CliCommandContext context)
    {
        //Do stuff...
        return Task.FromResult(0);
    }
}
```
