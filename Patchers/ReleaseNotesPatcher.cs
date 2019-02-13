using System.IO;

namespace NuspecPatcher.Patchers
{
    public class ReleaseNotesPatcher : Patcher
    {
        private readonly string _version;

        public ReleaseNotesPatcher(string nuspecPath, string version) : base(nuspecPath)
        {
            _version = version;
        }

        public override string Patch(string value)
        {
            if (!File.Exists($"./releaseNotes/{_version}.txt"))
            {
                throw new PatcherException($"Could not find file './releaseNotes/{_version}.txt'");
            }
            string fileContents = File.ReadAllText($"./releaseNotes/{_version}.txt");
            return PatchTag("releaseNotes", fileContents, _nuspecPath);
        }
    }
}