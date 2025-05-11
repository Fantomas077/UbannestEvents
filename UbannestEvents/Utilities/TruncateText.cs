namespace UbannestEvents.Utilities
{
    public class TruncateText
    {
        public static string  Truncate(string text, int maxLength)
        {
            if (text.Length <= maxLength)
            {
                return text;
            }
            else
            {
                return text.Substring(0, maxLength) + "...";
            }
        }
    }
}
