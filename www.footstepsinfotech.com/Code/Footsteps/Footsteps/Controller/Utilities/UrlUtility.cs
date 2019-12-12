using System;
using System.Text;
using System.Web;

namespace Footsteps.Controller.Utilities
{
    public static class UrlUtility
    {
        #region Utility Methods
        private static string ReplaceUnwantedCharacters(string input)
        {
            StringBuilder builder = new StringBuilder(input.Trim());
            builder = builder.Replace("'", "");
            builder = builder.Replace("&", "");
            builder = builder.Replace(",", "");
            builder = builder.Replace(".", "");
            builder = builder.Replace("#", "");
            builder = builder.Replace("\\", "");
            builder = new StringBuilder(builder.ToString().Trim());
            builder = builder.Replace(" ", "-");
            return HttpUtility.UrlEncode(builder.ToString().ToLower().Trim());
        }
        #endregion
    }
}