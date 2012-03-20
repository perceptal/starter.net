using System;
using System.Web;
using System.Web.Caching;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Core.Web
{
    public class ImageHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            int height = 0, width = 0;

            int.TryParse(context.Request.Params["h"], out height);
            int.TryParse(context.Request.Params["w"], out width);
            
            context.Response.Clear();
            context.Response.ContentType = "image/jpeg";

            if (width <= 0 && height <= 0)
            {
                context.Response.WriteFile(context.Request.PhysicalPath);
                context.Response.End();
            }
            else
            {
                string id = "{0}.{1}.{2}".FormatWith(context.Request.PhysicalPath, height, width);
                var buffer = context.Cache[id] as byte[];

                if (buffer == null)
                {
                    buffer = new ImageGenerator().Generate(context.Request.PhysicalPath, height, width);
                    context.Cache[id] = buffer;
                }

                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                context.Response.End();
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}