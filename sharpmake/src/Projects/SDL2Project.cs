using Sharpmake;

using System.Diagnostics;
using System.IO;
using System.Linq;

[Generate]
public sealed class SDL2Project : BaseProject
{
    public SDL2Project()
    {
        Name = "SDL2";

        var directory = Directory.GetDirectories(BaseConfiguration.VendorDirectory).Where(dir => dir.Contains("SDL2-devel")).Last();
        var subdirectories = Directory.GetDirectories(directory);
        if (!subdirectories.Contains("include") && subdirectories.Length == 1)
        {
            directory = subdirectories.First();
        }

        // TODO: automatically download the latest sdl2 develop release instead
        Debug.Assert(Directory.GetDirectories(directory).Contains("include"));

        SourceRootPath = directory;
    }

    public override void Configure(Configuration conf, Target target)
    {
        base.Configure(conf, target);

        conf.Output = Configuration.OutputType.Lib;

        conf.IncludePaths.Clear();
        conf.IncludePaths.Add(Path.Combine(SourceRootPath, "include"));

        var platformTarget = target.Platform == Platform.win64 ? "x64" : "x86";
        var libPath = Path.Combine(SourceRootPath, "lib", platformTarget);
        conf.LibraryPaths.Add(libPath);

        conf.LibraryFiles.Add("SDL2main");
        conf.LibraryFiles.Add("SDL2test");

        conf.TargetCopyFiles.Add(Path.Combine(libPath, "SDL2.dll"));
    }
}