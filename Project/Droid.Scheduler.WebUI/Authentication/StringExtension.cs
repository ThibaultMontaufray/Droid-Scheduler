using System;
using System.Collections.Generic;
using System.Text;

namespace Droid.Scheduler.WebUI.Context
{
    public static class StringExtension
    {
        public static string Quoted(this string str)
        {
            return "\"" + str + "\"";
        }
    }
}
