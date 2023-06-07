using Sharpmake;

using System.IO;

[Generate]
public abstract class DefaultMainProject : BaseProject
{
    protected DefaultMainProject()
    {
        Name = BaseConfiguration.MainProjectName;
        SourceRootPath = Path.Combine(BaseConfiguration.SrcDirectory, BaseConfiguration.MainProjectName);
    }

    public override void Configure(Configuration conf, Target target)
    {
        var templatePath = Path.Combine(SharpmakeCsPath, "MainProjectTemplates", BaseConfiguration.IsCPP ? "CPP" : "C");
        foreach (var file in Directory.GetFiles(templatePath, "*.*", SearchOption.AllDirectories))
        {
            var relativePath = Path.GetRelativePath(templatePath, file);
            var srcPath = Path.Combine(SourceRootPath, relativePath);
            if (!File.Exists(srcPath))
            {
                var directoryPath = Path.GetDirectoryName(srcPath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                File.Copy(file, srcPath);
            }
        }

        if (BaseConfiguration.IsCPP)
        {
            conf.PrecompHeader = $"stdafx.hpp";
            conf.PrecompSource = $"stdafx.cpp";
        }

        base.Configure(conf, target);
    }
}