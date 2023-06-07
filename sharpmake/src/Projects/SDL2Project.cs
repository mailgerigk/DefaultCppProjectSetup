using Sharpmake;

using System.Diagnostics;
using System.IO;
using System.Linq;

[Generate]
public sealed class SDL2Project : VendorProject
{
    protected override string VendorFolder
        => Directory.GetDirectories(BaseConfiguration.VendorDirectory)
        .Where(dir => dir.Contains("SDL2-devel"))
        .Last();
}