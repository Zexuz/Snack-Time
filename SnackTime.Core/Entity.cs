using Newtonsoft.Json;

namespace SnackTime.Core
{
    public abstract class Entity
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}