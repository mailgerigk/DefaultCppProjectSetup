using Sharpmake;

using System.IO;

public static class BaseConfiguration
{
    public static readonly Target Target = new Target
    {
        Platform = Platform.win64,
        DevEnv = DevEnv.vs2022,
        Optimization = Optimization.Debug | Optimization.Release,
    };

    public const string SolutionName = "DefaultSolutionName";
    public const string MainProjectName = "DefaultMainProjectName";

    public static readonly string BaseRepositoryDirectory = Path.Combine("..", "..", "..");
    public static readonly string SrcDirectory = Path.Combine(BaseRepositoryDirectory, "src");
    public static readonly string BinDirectory = Path.Combine(BaseRepositoryDirectory, "bin");
    public static readonly string SharpmakeOutputDirectory = Path.Combine(BinDirectory, "sharpmake");

    public static readonly string ProjectTargetDirectory = Path.Combine(BinDirectory, "[conf.Platform]", "[target.ProjectConfigurationName]");
    public static readonly string ProjectIntermidiateDirectory = Path.Combine(ProjectTargetDirectory, "[project.Name]");
}
