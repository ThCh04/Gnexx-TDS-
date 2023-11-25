using System.Text.RegularExpressions;

namespace Gnexx.Services.Services.Helpers
{
    public class ValidationModels
    {
        private static readonly Regex regex = new Regex("^[a-zA-Z0-9]*$");

        public static bool IsValid(string str)
        {
            if (regex.IsMatch(str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
