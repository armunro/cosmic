using System.CommandLine;

namespace Cosmic.CommandLine;

public class CliArgument
{
    public static Argument<T> NewArgument<T>()
    {
        return new Argument<T>("unset", "unset");
    }
    
}