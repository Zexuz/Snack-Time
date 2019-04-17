using System;

namespace SnackTime.Core
{
    public class MediaFileIdService
    {
        public string GenerateId(int id, MediaServer.Models.ProtoGenerated.Providers providers)
        {
            return $"{providers.ToString()}-{id}";
        }


        public MediaServer.Models.ProtoGenerated.Providers GetProviderFromId(string id)
        {
            var parts = id.Split("-");

            if (!Enum.TryParse<MediaServer.Models.ProtoGenerated.Providers>(parts[0], out var provider))
            {
                throw new Exception($"Can't parse enum id {id}");
            }

            return provider;
        }
    }
}