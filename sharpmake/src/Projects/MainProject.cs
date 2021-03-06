using Sharpmake;

[Generate]
public sealed class MainProject : BaseProject
{
    public MainProject()
    {
        Name = BaseConfiguration.MainProjectName;
        SourceRootPath = BaseConfiguration.SrcDirectory;
    }

    public override void Configure(Configuration conf, Target target)
    {
        base.Configure(conf, target);

        conf.PrecompHeader = $"stdafx.hpp";
        conf.PrecompSource = $"stdafx.cpp";
    }
}