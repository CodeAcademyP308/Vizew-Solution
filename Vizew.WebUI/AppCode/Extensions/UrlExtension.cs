using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Vizew.WebUI
{
    public static partial class Extension
    {
        static public string FriendlyUrlContext(this UrlHelper url, string context)
        {
            if (string.IsNullOrWhiteSpace(context))
                return "";


            context = context.Replace("Ü", "u").Replace("ü", "u");
            context = context.Replace("İ", "i").Replace("I", "i").Replace("ı", "i");
            context = context.Replace("Ş", "s").Replace("ş", "s");
            context = context.Replace("Ö", "o").Replace("ö", "o");
            context = context.Replace("Ç", "c").Replace("ç", "c");
            context = context.Replace("Ğ", "g").Replace("ğ", "g");
            context = context.Replace("Ə", "e").Replace("ə", "e");
            context = context.Replace(" ", "-").Replace("---", "-");
            context = context.Replace("?", "").Replace("/", "")
                .Replace("\\", "").Replace(".", "").Replace("'", "").Replace("#", "").Replace("%", "")
                .Replace("&", "").Replace("*", "").Replace("!", "").Replace("@", "").Replace("+", "");

            context = Regex.Replace(context.ToLower(), @"\s+", "");

            context = Regex.Replace(context, @"\&+", "and");
            context = Regex.Replace(context, @"[^a-z0-9]", "-");
            context = Regex.Replace(context, @"-+", "-");
            //context = context.Trim('-');
            //context = context + "d e   ve   lop  ment";
            context = Regex.Replace(context, @"\s+", "");

            return context;

            return context;
        }
    }
}