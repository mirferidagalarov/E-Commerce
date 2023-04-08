using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text.RegularExpressions;

namespace E_commerce_.NET5_.AppCode.Extensions
{
    static public partial class Extension
    {

        static public string GetCurrentCulture(this HttpContext ctx)
        {
            var match = Regex.Match(ctx.Request.Path, @"\/(?<lang>az|en|ru)\/?.*");

            if (match.Success)
            {
                return match.Groups["lang"].Value;
               
            }
            if (ctx.Request.Cookies.TryGetValue("lang", out string lang))
            {
                return lang;
            } 
               

            return "az";
        }

    }
}
