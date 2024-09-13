using System.ComponentModel;
using Autofac;

namespace Cosmic.CommandLine;

public  class CliApp : CosmicApp
{
    public virtual void WireCommands(Action<ContainerBuilder> builder) { }


}