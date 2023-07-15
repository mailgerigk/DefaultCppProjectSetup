using Sharpmake;

using System.Diagnostics;
using System.IO;
using System.Linq;

[Generate]
public sealed class SDL2Project : VendorProject
{
    public static bool CanAdd
    {
        get
        {
            try
            {
                return Directory.GetDirectories(BaseConfiguration.VendorDirectory)
                    .Where(dir => dir.Contains("SDL2-devel"))
                    .Any();
            }
            catch (IOException)
            {
                return false;
            }
        }
    }


    protected override string VendorFolder
        => Directory.GetDirectories(BaseConfiguration.VendorDirectory)
        .Where(dir => dir.Contains("SDL2-devel"))
        .Last();
}