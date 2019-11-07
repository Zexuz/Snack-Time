using System;
using System.Collections.Generic;
using System.IO;

namespace SnackTime.Core.Repository
{
    public class PathService
    {
        public string GetAppDataPath()
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var snackTimePath = Path.Combine(appData, "SnackTime");
            if (!Directory.Exists(snackTimePath))
            {
                Directory.CreateDirectory(snackTimePath);
            }

            return Path.Combine(appData, "SnackTime");
        }

        public string GetDatabasePath()
        {
            return Path.Combine(GetAppDataPath(), "mediaRepo.db");
        }
    }
}