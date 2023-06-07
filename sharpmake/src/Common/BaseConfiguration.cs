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

    public const bool IsCPP = true;

    public const string TranslationUnitExtension = IsCPP ? ".cpp" : ".c";
    public const string HeaderExtension = IsCPP ? ".hpp" : ".h";

    public static string SolutionName => new DirectoryInfo(BaseRepositoryDirectory).Name;
    public static string MainProjectName => new DirectoryInfo(BaseRepositoryDirectory).Name;

    public static string DefaultSolutionSharpmakeCsPath = $"{nameof(DefaultSolutionSharpmakeCsPath)} is uninitialized";
    public static string BaseRepositoryDirectory => Path.Combine(DefaultSolutionSharpmakeCsPath, "..", "..", "..");
    public static string SrcDirectory => Path.Combine(BaseRepositoryDirectory, "src");
    public static string BinDirectory => Path.Combine(BaseRepositoryDirectory, "bin");
    public static string VendorDirectory => Path.Combine(BaseRepositoryDirectory, "vendor");
    public static string SharpmakeOutputDirectory => Path.Combine(BinDirectory, "sharpmake");

    public static string ProjectTargetDirectory => Path.Combine(BinDirectory, "[conf.Platform]", "[target.ProjectConfigurationName]");
    public static string ProjectIntermidiateDirectory => Path.Combine(ProjectTargetDirectory, "[project.Name]");
}
