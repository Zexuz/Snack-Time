using System.Collections.Generic;

namespace Mpv.JsonIpc
{
    public static class PropertyEnumConverterExtension
    {
        private static readonly Dictionary<Property, string> Map = new Dictionary<Property, string>
        {
            {Property.Volume, "volume"},
            {Property.Pause, "pause"},
            {Property.Position, "time-pos"},
        };

        public static string GetStringValue(this Property property)
        {
            return Map[property];
        }
    }
}