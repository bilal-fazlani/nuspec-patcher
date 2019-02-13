using System;

namespace NuspecPatcher.Patchers
{
    public class VersionPatcher : Patcher
    {
        private readonly string _version;

        public VersionPatcher(string version)
        {
            _version = version;
        }

        public override string Patch(string value)
        {
            if (string.IsNullOrWhiteSpace(_version))
            {
                throw new PatcherException("please specify a version");
            }
            else
            {
                return PatchTag("version", _version, value);
            }
        }
    }
}