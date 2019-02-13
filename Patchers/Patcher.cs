using System.IO;
using System.Text.RegularExpressions;

namespace NuspecPatcher.Patchers
{
    public abstract class Patcher
    {
        protected string PatchTag(string tag, string newValue ,string fileContents)
        {
            var pattern = $@"(.*)(<{tag}>(.*)<\/{tag}>)(.*)";
            var regex = Regex.Match(fileContents, pattern, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.CultureInvariant);
            
            if (regex.Success)
            {
                string replacedText = Regex.Replace(fileContents, pattern, $"$1<{tag}>{newValue}</{tag}>$4", RegexOptions.Multiline | RegexOptions.Singleline);
                return replacedText;   
            }

            throw new PatcherException("could not parse nuspec file");
        }
        
        public abstract string Patch(string value);
    }
}