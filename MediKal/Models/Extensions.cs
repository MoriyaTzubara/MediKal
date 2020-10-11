using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediKal.Models
{
    public static class Extensions
    {
        static public string GetHiddenMail(this string mail)
        {
            return mail.Replace(mail.Substring(4, mail.Length - 14), string.Concat(Enumerable.Repeat("*", mail.Length - 14)));
        }

    }
}