using System;

namespace SnackTime.Core
{

    internal enum Provider
    {
        Sonarr,
        Radarr
    }
    internal class ProviderId
    {
        public Provider Provider { get; }
        public int      Id       { get; }

        public ProviderId(Provider provider, int id)
        {
            Provider = provider;
            Id = id;
        }

        public static bool TryParse(string id, out ProviderId providerId)
        {
            providerId = null;

            var parts = id.Split("-");
            if (parts.Length != 2)
            {
                return false;
            }

            if (!Enum.TryParse(parts[0], out Provider provider))
            {
                return false;
            }

            if (!int.TryParse(parts[1], out var number))
            {
                return false;
            }

            providerId = new ProviderId(provider, number);
            return true;
        }

        public override string ToString()
        {
            return $"{Provider:G}-{Id}";
        }
    }
}