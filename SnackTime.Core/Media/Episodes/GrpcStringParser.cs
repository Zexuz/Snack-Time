namespace SnackTime.Core.Media.Episodes
{
    public static class GrpcStringParser
    {
        public static string Parse(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return string.Empty;
            }


            return string.IsNullOrWhiteSpace(str) ? string.Empty : str;
        }
    }
}