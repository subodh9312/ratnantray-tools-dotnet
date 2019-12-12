using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Text;
using System.Data.Common;
using System.Web.Security;
using Footsteps.Controller.Utilities;

namespace Footsteps
{
    /// <summary>
    /// Summary description for ImageHandler
    /// </summary>
    public class ImageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string userName = "";
            if (!String.IsNullOrEmpty(context.Request.QueryString["UserName"]))
                userName = context.Request.QueryString["UserName"];
            else
                throw new ArgumentException("No parameter specified");

            context.Response.ContentType = "application/pdf";
            byte[] imageArray = new BizUtility().GetResumeData(userName);
            Stream strm = new MemoryStream(imageArray);
            byte[] buffer = new byte[2048];
            int byteSeq = strm.Read(buffer, 0, 2048);

            while (byteSeq > 0)
            {
                context.Response.OutputStream.Write(buffer, 0, byteSeq);
                byteSeq = strm.Read(buffer, 0, 2048);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}