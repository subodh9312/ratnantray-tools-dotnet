using System;
using System.Web;
using System.Text;
using System.Xml;
using Footsteps.Controller.Library;

namespace Footsteps.Controller.Utilities
{
    public static class RSSUtility
    {
        public static void GenerateRssResponseXML(HttpResponse Response, StringBuilder title, StringBuilder description, StringBuilder link, string headerDisplayName)
        {
            // clear out the buffer
            Response.Clear();
            // set response content type
            Response.ContentType = "text/xml";

            // delcare and instantiate XMLTextWriter object
            XmlTextWriter xtw = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);

            // write out the XML declaration and version 1.0 info
            xtw.WriteStartDocument();

            // write out the rss xml element "rss" (required)
            xtw.WriteStartElement("rss");
            xtw.WriteAttributeString("version", "2.0");

            // write out "channel" element (required)
            xtw.WriteStartElement("channel");
            xtw.WriteElementString("title", headerDisplayName + " Updates");
            xtw.WriteElementString("link", Constants.ServerAddress);
            xtw.WriteElementString("description", "Let's Share!");
            xtw.WriteElementString("copyright", "Copyright " + DateTime.Now.Year.ToString() + ". All rights reserved.");

            string[] titles = title.ToString().Split('$');
            string[] descriptions = description.ToString().Split('$');
            string[] links = link.ToString().Split('$');

            if ((titles.Length <= descriptions.Length) && (titles.Length == links.Length)) // everything is as expected
            {
                for (int i = 0; i < titles.Length; i++)
                {
                    if (string.IsNullOrEmpty(descriptions[i]))
                        continue;
                    xtw.WriteStartElement("item");
                    // write out title, link, and description based on the feed being requested,
                    // all three elements are required
                    xtw.WriteElementString("title", titles[i]);
                    xtw.WriteElementString("link", links[i]);
                    xtw.WriteElementString("description", descriptions[i]);
                    xtw.WriteEndElement();
                }
            }

            // Close all tags
            xtw.WriteEndElement();
            xtw.WriteEndElement();
            xtw.WriteEndDocument();
            xtw.Flush();
            xtw.Close();
        }
    }
}