using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DBManager.Library
{
    public static class ExtensionMethods
    {
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
            // return HttpUtility.UrlEncode(builder.ToString().ToLower().Trim());
            return builder.ToString().ToLower().Trim();
        }

        public static string ToUrlString(this string text)
        {
            char[] arr = text.Where(c => (Char.IsLetterOrDigit(c) ||
                             Char.IsWhiteSpace(c) ||
                             c == '-' ||
                             c == '/' ||
                             c == '_')).ToArray();

            text = new String(arr);

            return ReplaceUnwantedCharacters(text.Replace('_', '-').ToLower()).Replace(' ', '-');
        }

        public static string ToTitleCase(this string input)
        {
            input = input.ToLower();
            return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(input);
        }
    }
}
