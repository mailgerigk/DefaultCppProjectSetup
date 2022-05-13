using Sharpmake;

using System;
using System.IO;
using System.Linq;

[module: Include("../*/*.cs")]
[module: Include("../*/*/*.cs")]
[module: Include("../*/*/*/*.cs")]
[module: Include("../*/*/*/*/*.cs")]
[module: Include("../*/*/*/*/*/*.cs")]
[module: Include("../*/*/*/*/*/*/*.cs")]
[module: Include("../*/*/*/*/*/*/*/*.cs")]

[Generate]
public sealed class DefaultSolution : Solution
{
    public DefaultSolution()
    {
        Name = BaseConfiguration.SolutionName;
        AddTargets(BaseConfiguration.Target);
    }

    [Configure]
    public void Configure(Configuration conf, Target target)
    {
        conf.SolutionFileName = Name;
        conf.SolutionPath = BaseConfiguration.SharpmakeOutputDirectory;

        var projectTypes = AppDomain
            .CurrentDomain
            .GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => typeof(BaseProject).IsAssignableFrom(type) && !type.IsAbstract);
        foreach (var projectType in projectTypes)
        {
            conf.AddProject(projectType, target);
        }

        conf.SetStartupProject<MainProject>();
    }

    [Main]
    public static void SharpmakeMain(Arguments arguments)
    {
        arguments.Generate<DefaultSolution>();
    }
}