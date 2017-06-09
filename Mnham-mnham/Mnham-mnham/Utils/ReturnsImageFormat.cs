using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace Mnham_mnham.Utils
{
    public class ReturnsImageFormat
    {
        public static String ReturnImageFormatString(ImageFormat f)
        {
            String format;
            if (f.Equals(ImageFormat.Png))
            {
                format = "png";
            }
            else if (f.Equals(ImageFormat.Jpeg))
            {
                format = "jpeg";
            }
            else if (f.Equals(ImageFormat.Gif))
            {
                format = "gif";
            }
            else
            {
                format = null;
            }
            return format;
        }
    }
}