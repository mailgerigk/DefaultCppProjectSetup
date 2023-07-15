using Sharpmake;

using System.IO;

[Generate]
public sealed class MainProject : DefaultMainProject
{
    public override void Configure(Configuration conf, Target target)
    {
        base.Configure(conf, target);

        if(SDL2Project.CanAdd)
        {
            conf.LibraryFiles.Add("opengl32");
            conf.AddPrivateDependency<SDL2Project>(target);
        }

	// TODO: add more project dependencies
    }
}