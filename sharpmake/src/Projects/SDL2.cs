using Sharpmake;

using System.Diagnostics;
using System.IO;
using System.Linq;

[Generate]
public sealed class SDL2 : BaseProject
{
    public SDL2()
    {
        Name = "SDL2";

        var directory = Directory.GetDirectories(BaseConfiguration.VendorDirectory).Where(dir => dir.StartsWith("SDL2-devel")).Last();
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
        bool is_x64 = target.Platform == Platform.win64;
        var platformTarget = is_x64 ? "x64" : "x86";
        var libPath = Path.Combine(SourceRootPath, "lib", platformTarget);

        conf.Output = Configuration.OutputType.Utility;

        conf.IncludePaths.Add(Path.Combine(SourceRootPath, "include"));

        conf.LibraryFiles.Add(Path.Combine(libPath, "SDL2.lib"));
        conf.LibraryFiles.Add(Path.Combine(libPath, "SDL2main.lib"));
        conf.LibraryFiles.Add(Path.Combine(libPath, "SDL2test.lib"));

        conf.TargetCopyFiles.Add(Path.Combine(libPath, "SDL2.dll"));
    }
}