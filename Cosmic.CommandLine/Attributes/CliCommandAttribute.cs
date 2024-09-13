namespace Cosmic.CommandLine.Attributes;

public class CliCommandAttribute : Attribute
{
    public string Path { get; }
    public string Description { get; }
    public Type Parent { get; }

    public CliCommandAttribute(string path, string description, Type parent = null)
    {
        Path = path;
        Description = description;
        Parent = parent;
    }
}
   