using System;

namespace NuspecPatcher.Patchers
{
    public class CopyrightPatcher : Patcher
    {
        public CopyrightPatcher(string nuspecPath) : base(nuspecPath)
        {
        }

        public override string Patch(string value)
        {
            string copyrightYear = DateTime.Now.Year.ToString("0000");
            return PatchTag("copyright", copyrightYear, _nuspecPath);
        }
    }
}