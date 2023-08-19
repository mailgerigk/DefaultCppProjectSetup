using Sharpmake;

using System;
using System.IO;

public abstract class BaseProject : Project
{
    public string TypeNameWithoutPostfix => GetType().Name.Replace("Project", "").ToLowerInvariant();
    public bool UsePrecompiledHeaders = true;

    protected BaseProject()
    {
        AddTargets(BaseConfiguration.Target);
    }

    [Configure]
    public virtual void Configure(Configuration conf, Target target)
    {
        conf.ProjectFileName = Name;
        conf.ProjectPath = BaseConfiguration.SharpmakeOutputDirectory;

        conf.IncludePaths.Add(SourceRootPath);

        if (target.Optimization == Optimization.Debug)
        {
            conf.Options.Add(Options.Vc.Compiler.Inline.Disable);
        }

        if (BaseConfiguration.IsCPP)
        {
            conf.Options.Add(Options.Vc.Compiler.Exceptions.Enable);
            conf.Options.Add(Options.Vc.Compiler.CppLanguageStandard.Latest);
        }
        else
        {
            conf.Options.Add(Options.Vc.Compiler.CLanguageStandard.C11);
            conf.SourceFilesCompileAsCRegex.Add("\\.c$");
        }

        conf.Options.Add(Options.Vc.General.WindowsTargetPlatformVersion.Latest);

        conf.Options.Add(Options.Vc.General.WarningLevel.EnableAllWarnings);
        conf.Options.Add(Options.Vc.General.TreatWarningsAsErrors.Enable);

        conf.TargetPath = BaseConfiguration.ProjectTargetDirectory;
        conf.IntermediatePath = BaseConfiguration.ProjectIntermidiateDirectory;
        conf.BaseIntermediateOutputPath = BaseConfiguration.ProjectIntermidiateDirectory;

        if (BaseConfiguration.IsCPP)
        {
            if (UsePrecompiledHeaders)
            {
                conf.PrecompHeader = conf.PrecompHeader == null ? $"{Name}_stdafx.hpp" : conf.PrecompHeader;
                conf.PrecompSource = conf.PrecompSource == null ? $"{Name}_stdafx.cpp" : conf.PrecompSource;
            }

            var absoluteSourceRootPath = Path.GetFullPath(SourceRootPath);
            if (!Directory.Exists(absoluteSourceRootPath))
            {
                Directory.CreateDirectory(absoluteSourceRootPath);
            }

            var precompHeaderPath = Path.Combine(absoluteSourceRootPath, conf.PrecompHeader);
            if (!File.Exists(precompHeaderPath) && UsePrecompiledHeaders)
            {
                File.WriteAllText(precompHeaderPath, $"#pragma once{Environment.NewLine}");
            }

            var precompSourcePath = Path.Combine(absoluteSourceRootPath, conf.PrecompSource);
            if (!File.Exists(precompSourcePath) && UsePrecompiledHeaders)
            {
                File.WriteAllText(precompSourcePath, $"#include \"{conf.PrecompHeader}\"{Environment.NewLine}");
            }
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