using System;
using System.Linq;
using Localnetflix.Backend.Database.Models;

namespace Localnetflix.Backend.Database
{
    public class SeriesRepository : Repository<Series>, ISeriesRepository
    {
        public SeriesRepository()
        {
        }

        public Series FindByName(string name)
        {
            var all = Collection.FindAll();
            return all.FirstOrDefault(series => string.Equals(series.Name, name, StringComparison.CurrentCultureIgnoreCase));
        }
        
    }
}