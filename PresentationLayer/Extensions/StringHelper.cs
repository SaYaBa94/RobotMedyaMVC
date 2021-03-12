using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PresentationLayer.Extensions
{
    public static class StringHelper
    {
        public static string SkipImgTags(this string html)
        {
            return Regex.Replace(html, @"(<img\/?[^>]+>)", @"", RegexOptions.IgnoreCase);
        }

        public static string SkipIFrameTags(this string html)
        {
            return Regex.Replace(html, @"(<iframe\/?[^>]+>)", @"", RegexOptions.IgnoreCase);
        }


        public static string SkipTableTags(this string html)
        {
            if (html.Contains("</table>"))
            {
                int start = html.Split("<table")[0].Length;
                int end = html.Split("</table>")[0].Length;
                string table = html.Substring(start, (end - start + 8));
                return html.Replace(table, "");
            }
            else
            {
                return html;
            }

        }
    }
}
