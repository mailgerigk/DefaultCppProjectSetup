using Sharpmake;

using System;
using System.IO;

public abstract class LibraryProject : BaseProject
{
    protected Configuration.OutputType Output => Configuration.OutputType.Lib;
    public override string SolutionFolder
    {
        get
        {
            if (Output == Configuration.OutputType.Lib)
                return "lib/static";
            if (Output == Configuration.OutputType.Dll)
                return "lib/dynamic";
            if (Output == Configuration.OutputType.Utility)
                return "lib/headerOnly";
            throw new NotSupportedException();
        }
    }

    protected LibraryProject()
    {
        AddTargets(BaseConfiguration.Target);

        Name = TypeNameWithoutPostfix;
        SourceRootPath = Path.Combine(BaseConfiguration.SrcDirectory, SolutionFolder, TypeNameWithoutPostfix);
    }

    public override void Configure(Configuration conf, Target target)
    {
        base.Configure(conf, target);

        if (!Directory.Exists(SourceRootPath))
        {
            Directory.CreateDirectory(SourceRootPath);
        }

        var libaryHeaderFile = $"{TypeNameWithoutPostfix}{BaseConfiguration.HeaderExtension}";
        var libraryHeaderPath = Path.Combine(SourceRootPath, libaryHeaderFile);
        if (!File.Exists(libraryHeaderPath))
        {
            File.WriteAllText(libraryHeaderPath, $"#pragma once{Environment.NewLine}");
        }

        var libraryTranslationUnitPath = Path.Combine(SourceRootPath, $"{TypeNameWithoutPostfix}{BaseConfiguration.TranslationUnitExtension}");
        if (Output != Configuration.OutputType.Utility && !File.Exists(libraryTranslationUnitPath))
        {
            File.WriteAllText(libraryTranslationUnitPath, $"#include \"{libaryHeaderFile}\"{Environment.NewLine}static int suppress_4206;{Environment.NewLine}");
        }

        conf.Output = Output;
    }
}