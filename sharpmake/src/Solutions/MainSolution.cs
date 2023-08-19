using Sharpmake;

[module: Include("../*/*.cs")]

[Generate]
public class MainSolution : DefaultSolution
{
    [Main]
    public static void SharpmakeMain(Arguments arguments)
    {
        arguments.Generate<MainSolution>();
    }
}