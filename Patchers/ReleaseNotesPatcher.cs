using System.IO;

namespace NuspecPatcher.Patchers
{
    public class ReleaseNotesPatcher : Patcher
    {
        private readonly string _version;

        public ReleaseNotesPatcher(string version)
        {
            _version = version;
        }

        public override string Patch(string value)
        {
            if (!File.Exists($"./releaseNotes/{_version}.txt"))
            {
                throw new PatcherException($"Could not find file './releaseNotes/{_version}.txt'");
            }
            string newReleaseNotes = File.ReadAllText($"./releaseNotes/{_version}.txt");
            return PatchTag("releaseNotes", newReleaseNotes, value);
        }
    }
}