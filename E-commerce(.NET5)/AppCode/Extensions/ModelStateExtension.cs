using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Text.RegularExpressions;

namespace E_commerce_.NET5_.AppCode.Extensions
{
    static public partial class Extension
    {

        static public bool IsModelStateValid(this IActionContextAccessor ctx)
        {
            return ctx.ActionContext.ModelState.IsValid;

        }

    }
}

