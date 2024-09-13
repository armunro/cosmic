namespace Cosmic.CommandLine.Attributes;

public class CliArgumentAttribute : Attribute
{
    public string Name { get; }
    public string Description { get; }

    public CliArgumentAttribute(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
   