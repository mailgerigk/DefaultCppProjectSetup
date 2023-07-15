using Sharpmake;

using System.Diagnostics;
using System.IO;
using System.Linq;

[Generate]
public sealed class RaylibProject : VendorProject
{
    public static bool CanAdd
    {
        get
        {
            try
            {
                return Directory.GetDirectories(BaseConfiguration.VendorDirectory)
                    .Where(dir => dir.Contains("raylib"))
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
        .Where(dir => dir.Contains("raylib"))
        .Last();
}