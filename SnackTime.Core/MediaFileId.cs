using System;
using SnackTime.MediaServer.Models.ProtoGenerated;

namespace SnackTime.Core
{
    public class MediaFileId
    {
        public int       MediaId  { get; set; }
        public int       FileId   { get; set; }
        public Providers Provider { get; set; }


        public override string ToString()
        {
            return FileId == 0 ? string.Empty : $"{Provider.ToString()}-{MediaId}-{FileId}";
        }

        public static bool TryParse(string id, out MediaFileId mediaFileId)
        {
            mediaFileId = new MediaFileId();

            var parts = id.Split("-");

            if (parts.Length != 3)
            {
                return false;
            }


            var providerStr = parts[0];
            var mediaIdStr = parts[1];
            var fileIdStr = parts[2];

            if (!Enum.TryParse<Providers>(providerStr, out var provider))
            {
                return false;
            }

            if (!int.TryParse(mediaIdStr, out var mediaId))
            {
                return false;
            }

            if (!int.TryParse(fileIdStr, out var fileId))
            {
                return false;
            }

            mediaFileId.Provider = provider;
            mediaFileId.FileId = fileId;
            mediaFileId.MediaId = mediaId;

            return true;
        }
    }
}