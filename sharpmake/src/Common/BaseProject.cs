using Sharpmake;


public abstract class BaseProject : Project
{
    protected BaseProject()
    {
        AddTargets(BaseConfiguration.Target);
    }

    [Configure]
    public virtual void Configure(Configuration conf, Target target)
    {
        conf.ProjectFileName = Name;
        conf.ProjectPath = BaseConfiguration.SharpmakeOutputDirectory;

        conf.Options.Add(Options.Vc.Compiler.Exceptions.Enable);

        if(target.Optimization == Optimization.Debug)
        {
            conf.Options.Add(Options.Vc.Compiler.Inline.Disable);
        }

        conf.Options.Add(Options.Vc.Compiler.CppLanguageStandard.Latest);
        conf.Options.Add(Options.Vc.General.WindowsTargetPlatformVersion.Latest);

        conf.Options.Add(Options.Vc.General.WarningLevel.EnableAllWarnings);
        conf.Options.Add(Options.Vc.General.TreatWarningsAsErrors.Enable);

        conf.TargetPath = BaseConfiguration.ProjectTargetDirectory;
        conf.IntermediatePath = BaseConfiguration.ProjectIntermidiateDirectory;
        conf.BaseIntermediateOutputPath = BaseConfiguration.ProjectIntermidiateDirectory;
    }
}