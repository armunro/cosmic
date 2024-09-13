using System.CommandLine;
using System.CommandLine.Invocation;
using System.Reflection;
using Cosmic.CommandLine.Attributes;

// ReSharper disable VirtualMemberNeverOverridden.Global

namespace Cosmic.CommandLine;

public abstract class CliCommand : Command, ICommandHandler
{
   

  
    protected abstract Task<int> ExecuteCommand(CliCommandContext context);

    
    protected CliCommand() : base("unset")
    {
        Handler = this;
        LoadPropsFromAttributes();
        LoadArgumentsFromAttributes();
        LoadOptionsFromAttributes();
    }

    private void LoadOptionsFromAttributes()
    {
        //Get any public static fields of type Option that are defined in this class that have a CliOptionAttribute attribute
        IEnumerable<FieldInfo> optionFields = GetType().GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(f => f.FieldType.BaseType == typeof(Option) && f.GetCustomAttribute<CliOptionAttribute>() != null);
        foreach (FieldInfo optionField in optionFields)
        {
            CliOptionAttribute? cliOptionAttribute = optionField.GetCustomAttribute<CliOptionAttribute>();
            //get the static option instance and add it to this command
            Option option = (Option)optionField.GetValue(null);
            if (cliOptionAttribute != null)
            {
                option.Name = cliOptionAttribute.Name;
                option.Description = cliOptionAttribute.Description;
                AddOption(option);
            }
        }
    }

    private void LoadArgumentsFromAttributes()
    {
        //Get any public static fields of type Option that are defined in this class that have a CliOptionAttribute attribute
        IEnumerable<FieldInfo> argFields = GetType().GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(f => f.FieldType.BaseType == typeof(Argument) && f.GetCustomAttribute<CliArgumentAttribute>() != null);
        foreach (FieldInfo optionField in argFields)
        {
            CliArgumentAttribute? cliOptionAttribute = optionField.GetCustomAttribute<CliArgumentAttribute>();
            //get the static option instance and add it to this command
            Argument argument = (Argument)optionField.GetValue(null);
            if (cliOptionAttribute != null)
            {
                argument.Description = cliOptionAttribute.Description;
                argument.Name = cliOptionAttribute.Name;
                AddArgument(argument);
            }
        }
    }

    private void LoadPropsFromAttributes()
    {
        //get the CliCommandAttribute attribute from this class
        CliCommandAttribute? commandAttribute = GetType().GetCustomAttribute<CliCommandAttribute>();
        if(commandAttribute != null)
        {
            //set the name and description from the attribute
            this.Name = commandAttribute.Path;
            this.Description = commandAttribute.Description;
        }
    }

    //Wire up the command to the handler
    public int Invoke(InvocationContext context) => ExecuteCommand(new CliCommandContext(){InvocationContext = context}).Result;
    public Task<int> InvokeAsync(InvocationContext context) => ExecuteCommand(new CliCommandContext(){InvocationContext = context});
}