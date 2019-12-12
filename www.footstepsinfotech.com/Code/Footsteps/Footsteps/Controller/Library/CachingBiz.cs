using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using Footsteps.Controller.Utilities;
using Footsteps.Model;

namespace Footsteps.Controller.Library
{
    public class CachingBiz
    {
        private static Dictionary<string, object> cachingObj = null;

        static CachingBiz()
        {
            cachingObj = new Dictionary<string, object>();
        }

        private bool HasCacheExpired(string key)
        {
            DateTime lastCachingTime = DateTime.Now;
            object cachingTimeObject;
            if (cachingObj == null || !cachingObj.TryGetValue(key, out cachingTimeObject))
            {
                // not required as code has been initialized in the static constructor.
                // if (cachingObj == null)
                //  cachingObj = new Dictionary<string, object>();

                // First Request...
                lastCachingTime = DateTime.Now;
                return UpdateCache(key, lastCachingTime);
            }
            lastCachingTime = Convert.ToDateTime(cachingTimeObject);
            if (GetTimeToExpire(lastCachingTime) > 0)
            {
                // Next Request And Cached Object has not Expired...
                lastCachingTime = DateTime.Now;
                return UpdateCache(key, lastCachingTime);
            }
            return false;
        }

        private bool UpdateCache(string key, object value)
        {
            bool success = false;
            lock (cachingObj)
            {
                if (cachingObj.ContainsKey(key))
                    cachingObj.Remove(key);

                cachingObj[key] = value;
                success = true;
            }
            return success;
        }

        private int GetTimeToExpire(DateTime lastCachingTime)
        {
            string cachingTimeInMinutes = ConfigurationManager.AppSettings["CacheConfigurationTimeout"];
            int seconds = Convert.ToInt32(cachingTimeInMinutes) * 60; // convert to seconds
            DateTime currentTime = DateTime.Now;
            if (lastCachingTime == null)
                // First request and the object is not yet cached.
                return -1;
            return DateTime.Compare(currentTime, lastCachingTime.AddSeconds(seconds));
        }

        public string GetJqueryContents(string path)
        {
            object data = null;
            try
            {
                string key = CachingConstants.LastCachingTime + CachingConstants.JQueryContents;
                if (HasCacheExpired(key) 
                    || cachingObj == null || !cachingObj.TryGetValue(CachingConstants.JQueryContents, out data))
                {
                    StringBuilder builder = new StringBuilder("<script type='text/javascript'>");
                    builder.Append(GetFileContents(path));
                    builder.Append("</script>");
                    data = builder.ToString();
                    UpdateCache(CachingConstants.JQueryContents, data);
                }
                else
                    data = cachingObj[CachingConstants.JQueryContents];
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Caught the exception " + e.Message);
            }
            return data as string;
        }

        public string GetCompressedSiteCss(string path)
        {
            object data = null;
            try
            {
                string key = CachingConstants.LastCachingTime + CachingConstants.CssContents;
                if (HasCacheExpired(key) 
                    || cachingObj == null || !cachingObj.TryGetValue(CachingConstants.CssContents, out data))
                {
                    StringBuilder builder = new StringBuilder("<style type='text/css'>");
                    builder.Append(GetFileContents(path));
                    builder.Append("</style>");
                    data = builder.ToString();
                    UpdateCache(CachingConstants.CssContents, data);
                }
                else
                    data = cachingObj[CachingConstants.CssContents];
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Caught the exception " + e.Message);
            }
            return data as string;
        }

        public string GetFileContents(string path)
        {
            StringBuilder builder = new StringBuilder();
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string text = line.TrimEnd().TrimStart();
                text = text.Replace(Environment.NewLine, "");
                builder.Append(text);
            }
            return builder.ToString();
        }

        public string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}