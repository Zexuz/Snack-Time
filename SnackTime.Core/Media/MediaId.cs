using System;

namespace SnackTime.Core.Media
{
    public class MediaId
    {
        public Provider Type           { get; }
        public int      IdFromProvider { get; }

        public MediaId(Provider type, int idFromProvider)
        {
            IdFromProvider = idFromProvider;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Type.ToString()}:{IdFromProvider}";
        }

        public static MediaId Parse(string mediaId)
        {
            var parts = mediaId.Split(":");

            if (parts.Length != 2)
            {
                throw new ArgumentException($"The MediaId {mediaId} is not valid");
            }

            var typeStr = parts[0];
            var idFromProvider = int.Parse(parts[1]);

            if (!Enum.TryParse(typeof(Provider), typeStr, true, out var type))
            {
                throw new ArgumentException($"Can't parse str {typeStr} to enum");
            }

            return new MediaId((Provider) type, idFromProvider);
        }
    }
}