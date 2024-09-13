using Autofac;

namespace Cosmic;

public abstract class CosmicApp
{
    public static CosmicApp Current { get; private set; } = null!;
    
    
    public List<Action<ContainerBuilder>> Registrars { get; } = new();
    public List<Action<CosmicApp>> Configurators { get; } = new();
    
    private readonly ContainerBuilder _builder = new();
    private IContainer _container = null!;
    private Action<IContainer> _initiator = null!;

    public IContainer Container => _container;


    public CosmicApp RegisterDependencies(Action<ContainerBuilder> configurator)
    {
        configurator(_builder);
        return this;
    }

    public CosmicApp AddConfigStep(Action<CosmicApp> startAction)
    {
        Configurators.Add(startAction);
        return this;
    }
    
    public CosmicApp SetInitiator(Action<IContainer> initiator)
    {
        _initiator = initiator;
        return this;
    }

    
    public void Start()
    {
        foreach (Action<CosmicApp> configurator in Configurators)
        {
            configurator(this);
        }
        _initiator(_container);
    }

    /// <summary>
    /// Build the application's DI container and set the current static instance.
    /// </summary>
    /// <returns></returns>
    public CosmicApp Build()
    {
        _container = _builder.Build();
        Current = this;
        return this;
    }
}