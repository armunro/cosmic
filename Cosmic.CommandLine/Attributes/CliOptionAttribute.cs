namespace Cosmic.CommandLine.Attributes;

public class CliOptionAttribute : Attribute
{
    public string Name { get; }
    public string Description { get; }

    public CliOptionAttribute(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
   