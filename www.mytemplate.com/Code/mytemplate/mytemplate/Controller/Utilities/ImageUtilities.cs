using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Configuration;
using System.Web.DynamicData;
using System.Web.Security;

namespace mytemplate.Controller.Utilities
{
    public static class ImageUtilities
    {
        public static string PHOTO_UPLOAD_PATH
        {
            get
            {
                return ConfigurationManager.AppSettings["ServerPhysicalPath"] + @"Uploads\Products\";
            }
        }

        public const string PHOTO_RELATIVE_PATH = @"~/Uploads/Products/";

        public static string Get200FileName(string fileName)
        {
            if (String.IsNullOrEmpty(fileName) || String.IsNullOrWhiteSpace(fileName))
                return "";
            string temp = fileName.Substring(PHOTO_RELATIVE_PATH.Length);
            return PHOTO_RELATIVE_PATH + "200" + temp;
        }

        public static string Get100FileName(string fileName)
        {
            if (String.IsNullOrEmpty(fileName) || String.IsNullOrWhiteSpace(fileName))
                return "";
            string temp = fileName.Substring(PHOTO_RELATIVE_PATH.Length);
            return PHOTO_RELATIVE_PATH + "100" + temp;
        }

        public static void ResizeImageAndSave(int square, Stream fromStream, string fileName)
        {
            Image image = Image.FromStream(fromStream);

            //Calculate Heights and Width
            int newWidth;
            int newHeight;
            if (image.Width >= image.Height)
            {
                newWidth = square;
                newHeight = (int)(image.Height * square / image.Width);
            }
            else
            {
                newHeight = square;
                newWidth = (int)(image.Width * square / image.Height);
            }

            Bitmap thumbnailBitmap = new Bitmap(newWidth, newHeight);

            Graphics thumbnailGraph = Graphics.FromImage(thumbnailBitmap);

            //Set Quality
            thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;

            Rectangle imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
            thumbnailGraph.DrawImage(image, imageRectangle);

            thumbnailBitmap.Save(fileName, image.RawFormat);

            //Dispose
            thumbnailGraph.Dispose();
            thumbnailBitmap.Dispose();
            image.Dispose();
        }

        public static string GetImageUrl(WebProfile profile)
        {
            BizUtility bizUtility = new BizUtility();
            // if (profile.ProfilePicture != null) // this always returns NULL due to Image SP Problem
            byte[] result = bizUtility.GetProfilePicture(profile.UserName);
            if (result != null)
                return "~/ImageHandler.ashx?UserName=" + profile.UserName;
            return MetaModel.Default.DynamicDataFolderVirtualPath + "Content/Photos/no-image.gif";
        }
    }
}