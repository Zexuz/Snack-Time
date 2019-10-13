using System;
using System.Threading;
using SnackTime.Core.Media;
using SnackTime.MediaServer.Models.ProtoGenerated;

namespace SnackTime.Core
{
    public class PlayableId
    {
        public Provider Provider { get; private set; }
        public int      FileId   { get; private set; }

        public PlayableId(Provider provider, int fileId)
        {
            Provider = provider;
            FileId = fileId;
        }

        public override string ToString()
        {
            return FileId == 0 ? string.Empty : $"{Provider.ToString()}-{FileId}";
        }

        public static bool TryParse(string id, out PlayableId playableId)
        {
            playableId = null;

            var parts = id.Split("-");

            if (parts.Length != 2)
            {
                return false;
            }

            if (!Enum.TryParse<Provider>(parts[0], out var provider))
            {
                return false;
            }

            if (!int.TryParse(parts[1], out var fileId))
            {
                return false;
            }

            playableId = new PlayableId(provider, fileId);
            return true;
        }
    }
}