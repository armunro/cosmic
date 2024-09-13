using System.CommandLine;

namespace Cosmic.CommandLine;

public class CliOption
{
    public static Option<T> NewOption<T>()
    {
        return new Option<T>("unset", "unset");
    }
    
}