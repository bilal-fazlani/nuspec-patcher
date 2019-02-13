using System.IO;
using System.Text.RegularExpressions;

namespace NuspecPatcher.Patchers
{
    public abstract class Patcher
    {
        protected readonly string _nuspecPath;

        public Patcher(string nuspecPath)
        {
            _nuspecPath = nuspecPath;
        }
        
        protected string PatchTag(string tag, string newValue ,string nuspecFile)
        {
            var fileContents = File.ReadAllText(nuspecFile);
            var pattern = $@"(.*)(<{tag}>(.*)<\/{tag}>)(.*)";
            var regex = Regex.Match(fileContents, pattern, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.CultureInvariant);
            
            if (regex.Success)
            {
                var currentValue = regex.Groups[3];
                string replacedText = Regex.Replace(fileContents, pattern, $"$1<{tag}>{newValue}</{tag}>$4", RegexOptions.Multiline | RegexOptions.Singleline);
                return replacedText;   
            }
            else
            {
                throw new PatcherException("could not parse nuspec file");
            }
        }
        
        public abstract string Patch(string value);
    }
}