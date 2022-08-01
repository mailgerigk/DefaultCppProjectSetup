using Sharpmake;

using System;
using System.IO;

public abstract class BaseProject : Project
{
    protected BaseProject()
    {
        AddTargets(BaseConfiguration.Target);
    }

    [Configure]
    public virtual void Configure(Configuration conf, Target target)
    {
        conf.ProjectFileName = Name;
        conf.ProjectPath = BaseConfiguration.SharpmakeOutputDirectory;

        conf.Options.Add(Options.Vc.Compiler.Exceptions.Enable);

        if (target.Optimization == Optimization.Debug)
        {
            conf.Options.Add(Options.Vc.Compiler.Inline.Disable);
        }

        conf.Options.Add(Options.Vc.Compiler.CppLanguageStandard.Latest);
        conf.Options.Add(Options.Vc.General.WindowsTargetPlatformVersion.Latest);

        conf.Options.Add(Options.Vc.General.WarningLevel.EnableAllWarnings);
        conf.Options.Add(Options.Vc.General.TreatWarningsAsErrors.Enable);

        conf.TargetPath = BaseConfiguration.ProjectTargetDirectory;
        conf.IntermediatePath = BaseConfiguration.ProjectIntermidiateDirectory;
        conf.BaseIntermediateOutputPath = BaseConfiguration.ProjectIntermidiateDirectory;

        conf.PrecompHeader = $"{Name}_stdafx.hpp";
        conf.PrecompSource = $"{Name}_stdafx.cpp";

        var absoluteSourceRootPath = Path.GetFullPath(SourceRootPath);
        if (!Directory.Exists(absoluteSourceRootPath))
        {
            Directory.CreateDirectory(absoluteSourceRootPath);
        }

        var precompHeaderPath = Path.Combine(absoluteSourceRootPath, conf.PrecompHeader);
        if (!File.Exists(precompHeaderPath))
        {
            File.WriteAllText(precompHeaderPath, $"#pragma once{Environment.NewLine}");
        }

        var precompSourcePath = Path.Combine(absoluteSourceRootPath, conf.PrecompSource);
        if (!File.Exists(precompSourcePath))
        {
            File.WriteAllText(precompSourcePath, $"#include \"{conf.PrecompHeader}\"{Environment.NewLine}");
        }
    }

    public virtual string SolutionFolder => string.Empty;

    public static string GetSolutionFolder(Type projectType)
    {
        var projectObject = Activator.CreateInstance(projectType);
        if (projectObject is BaseProject project)
        {
            return project.SolutionFolder;
        }
        return string.Empty;
    }
}