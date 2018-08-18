using System.Collections.Generic;
using System.Linq;
using MediaHelper.Model;

namespace MediaHelper.Backend
{
    public class MedieFileService
    {
        private MediaFileRepositorty _repo;


        public MedieFileService()
        {
            _repo = new MediaFileRepositorty();
        }

        public void AddOrUpdate(SeriesFile file)
        {
            _repo.AddOrUpdate(file);
        }


        public MediaFile GetLastWatched()
        {
            return _repo.GetAll().OrderByDescending(file => file.LastWatched).First();
        }

        public IEnumerable<MediaFile> GetLatestWatched()
        {
            return _repo.GetAll().OrderByDescending(file => file.LastWatched);
        }

        public IEnumerable<MediaFile> GetLatestWatched(int seriesId)
        {
            return _repo.GetAll().Where(file => file.Provider == Provider.Sonarr && ((SeriesFile) file).SeriesId == seriesId);
        }

        public MediaFile GetLastWatched(int seriesId)
        {
            return _repo.GetAll().OrderByDescending(file => file.LastWatched).FirstOrDefault(file => file.SeriesId == seriesId);
        }
    }
}