using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CommandDotNet.Attributes;
using NuspecPatcher.Patchers;

namespace NuspecPatcher
{
    public class App
    {
        public int Patch(
            [Argument(Description = "REQUIRED. New version of nuget package")]string version, 
            [Option(LongName = "release-notes", ShortName = "r", Description = "If enabled, patches release notes in nuspec file. " +
                                  "It expects a release notes file at ./releaseNotes/<version>.txt")]bool releaseNotes = false,
            [Option(LongName = "copyright", ShortName = "c", Description = "If enabled, overrides the copyright year in nuspec file with current year")]bool copyright = false,
            [Option(LongName = "nuspec-path", Description = "path of nuspec file to be patched")]string nuspecPath = "package.nuspec")
        {
            try
            {
                if(!File.Exists(nuspecPath)) throw new PatcherException("could not find the nuspec file");
                
                var patchers = new List<Patcher> { new VersionPatcher(version) };
                
                if(releaseNotes) patchers.Add(new ReleaseNotesPatcher(version));
                
                if(copyright) patchers.Add(new CopyrightPatcher());

                string patchedContent = patchers.Aggregate(File.ReadAllText(nuspecPath),
                    (previous, patcher) => patcher.Patch(previous));
                File.WriteAllText(nuspecPath, patchedContent);
                Console.WriteLine("file patched successfully");
                return 0;
            }
            catch (PatcherException err)
            {
                Console.Error.WriteLine(err.Message);
                return 1;
            }
        }
    }
}