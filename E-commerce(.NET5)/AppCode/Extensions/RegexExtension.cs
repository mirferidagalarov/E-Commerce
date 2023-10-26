using System.Text.RegularExpressions;

namespace E_commerce_.NET5_.AppCode.Extensions
{
    static public partial class Extension
    {
        // ^([\w -\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9] { 1,3}\.)| (([\w -] +\.)+))([a - zA - Z]{ 2,4}|[0 - 9]{ 1,3})(\]?)$
        static public bool IsEmail(this string value)
        {
            return Regex.IsMatch(value, @"^([\\w -\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9] { 1,3}\\.)| (([\\w -] +\\.)+))([a - zA - Z]{ 2,4}|[0 - 9]{ 1,3})(\\]?)$");
        }
    }
}
