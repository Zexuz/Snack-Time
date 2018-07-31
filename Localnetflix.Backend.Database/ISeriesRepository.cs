using Localnetflix.Backend.Database.Models;

namespace Localnetflix.Backend.Database
{
    public interface ISeriesRepository:IRepository<Series>
    {
        Series FindByName(string name);
    }
}