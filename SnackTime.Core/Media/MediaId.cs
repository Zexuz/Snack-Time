using System;
using SnackTime.Core.Database;
using SnackTime.MediaServer.Models.ProtoGenerated;

namespace SnackTime.Core.Media
{
    public class MediaId
    {
        public Provider Type           { get; }
        public string   IdFromProvider { get; }

        public MediaId(Provider type, string idFromProvider)
        {
            IdFromProvider = idFromProvider;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Type.ToString()}-{IdFromProvider}";
        }


        public static bool TryParse(string idStr, out MediaId mediaId)
        {
            mediaId = null;
            var parts = idStr.Split("-");

            if (parts.Length != 2)
            {
                return false;
            }

            if (!Enum.TryParse<Provider>(parts[0], out var provider))
            {
                return false;
            }

            mediaId = new MediaId(provider, parts[1]);
            return true;
        }
    }
}