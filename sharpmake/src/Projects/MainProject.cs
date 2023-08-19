using Sharpmake;

[Generate]
public sealed class MainProject : DefaultMainProject
{
    public override void Configure(Configuration conf, Target target)
    {
        base.Configure(conf, target);
        // TODO: add more project dependencies
    }
}