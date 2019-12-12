using System;
using System.Configuration;

using Twitterizer;

namespace Footsteps.Controller.Utilities
{
    public class SocialNetworkingHelper
    {
        #region Facebook posting code commented out.
        /*
         * using Facebook.Rest;
         * using Facebook.Session;
         * using Facebook.Schema;
         * using Facebook.Utility;
         * using System.Runtime.Serialization;
        public static bool SendFacebookFeed(FacebookFeed feed, out string errorMessage)
        {
            try
            {

                Api api = new Api(new ConnectSession(ConfigurationManager.AppSettings.Get("FAPIKey"), ConfigurationManager.AppSettings.Get("66ec801b79220e4c95c367227c3530dc")));
                api.Session.SessionKey = ConfigurationManager.AppSettings.Get("FSessionKey");
                api.Session.SessionSecret = ConfigurationManager.AppSettings.Get("FSessionSecret");

                //Attachment
                attachment attach = new attachment();
                attach.caption = feed.AttachmentCaption;
                attach.name = feed.AttachmentName;
                attach.href = feed.AttachmentHref;
                attach.description = feed.AttachmentDescription;

                attach.media = new List<attachment_media>(){new attachment_media_image()
                        {
                            src = feed.AttachmentMediaImageSrc,
                            href = feed.AttachmentMediaImageHref
                        }};

                //LINKS
                List<action_link> links = new List<action_link>();

                action_link link = new action_link();
                link.href = feed.LinkHref;
                link.text = feed.LinkText;

                links.Add(link);

                var result = api.Stream.Publish(feed.StatusMessage, attach, links, "127834527250801", 0);
                result = api.Stream.Publish(feed.StatusMessage, attach, links, null, 0);
                errorMessage = "";
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public class FacebookFeed
        {
            [DataMember]
            public string StatusMessage { get; set; }           

            [DataMember]
            public string LinkHref { get; set; }                
            [DataMember]
            public string LinkText { get; set; }                

            [DataMember]
            public string AttachmentCaption { get; set; }       
            [DataMember]
            public string AttachmentName { get; set; }          
            [DataMember]
            public string AttachmentHref { get; set; }          
            [DataMember]
            public string AttachmentDescription { get; set; }   
            [DataMember]
            public string AttachmentMediaImageSrc { get; set; } 
            [DataMember]
            public string AttachmentMediaImageHref { get; set; }
        }
        */

        #endregion

        public static bool SendTweet(string tweet, out string errorMessage)
        {
            if (tweet != null && tweet.Length > 160)
            {
                tweet = tweet.Substring(0, 160 - 3) + "...";
            }
            try
            {
                OAuthTokens accessToken = new OAuthTokens();
                accessToken.AccessToken = ConfigurationManager.AppSettings["TaccessToken"];
                accessToken.AccessTokenSecret = ConfigurationManager.AppSettings["TaccessTokenSecret"];
                accessToken.ConsumerKey = ConfigurationManager.AppSettings["TconsumerKey"];
                accessToken.ConsumerSecret = ConfigurationManager.AppSettings["TconsumerSecret"];

                TwitterStatus.Update(accessToken, tweet);
                errorMessage = "";
                return true;
            }
            catch (Exception Ex)
            {
                errorMessage = Ex.Message;
                return false;
            }
        }
    }
}