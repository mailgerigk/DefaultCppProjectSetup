using Sharpmake;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

public abstract class VendorProject : BaseProject
{
    protected abstract string VendorFolder { get; }

    protected VendorProject()
    {
        AddTargets(BaseConfiguration.Target);

        Name = TypeNameWithoutPostfix;
        SourceRootPath = Path.Combine(BaseConfiguration.VendorDirectory, VendorFolder);
        Debug.Assert(Directory.Exists(SourceRootPath));
        UsePrecompiledHeaders = false;
    }

    public override void Configure(Configuration conf, Target target)
    {
        base.Configure(conf, target);

        conf.Output = Configuration.OutputType.Utility;

        conf.SourceFilesCompileAsCRegex.Clear();
        conf.SourceFilesCompileAsCPPRegex.Clear();

        conf.IncludePaths.Clear();
        foreach (var directory in Directory.GetDirectories(SourceRootPath, "include", SearchOption.AllDirectories))
        {
            conf.IncludePaths.Add(directory);
        }

        var libraryPaths = new HashSet<string>();
        var libraryFiles = new HashSet<string>();
        foreach (var directory in Directory.GetDirectories(SourceRootPath, "*", SearchOption.AllDirectories))
        {
            if (directory.Contains(target.Platform == Platform.win32 ? "x86" : "x64"))
            {
                foreach (var file in Directory.GetFiles(directory, "*.lib", SearchOption.AllDirectories))
                {
                    libraryPaths.Add(Path.GetDirectoryName(file));
                    libraryFiles.Add(Path.GetFileNameWithoutExtension(file));
                }
                foreach (var file in Directory.GetFiles(directory, "*.dll", SearchOption.AllDirectories))
                {
                    conf.TargetCopyFiles.Add(file);
                }
            }
        }
        // no libraryPaths found that contain either x86 or x64, try just a lib folder then
        if(!libraryPaths.Any())
        {
            foreach (var directory in Directory.GetDirectories(SourceRootPath, "lib", SearchOption.AllDirectories))
            {
                foreach (var file in Directory.GetFiles(directory, "*.lib", SearchOption.AllDirectories))
                {
                    libraryPaths.Add(Path.GetDirectoryName(file));
                    libraryFiles.Add(Path.GetFileNameWithoutExtension(file));
                }
                foreach (var file in Directory.GetFiles(directory, "*.dll", SearchOption.AllDirectories))
                {
                    conf.TargetCopyFiles.Add(file);
                }
            }
        }

        conf.LibraryPaths.AddRange(libraryPaths);
        conf.LibraryFiles.AddRange(libraryFiles);
    }
}