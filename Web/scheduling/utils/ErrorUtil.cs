using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.scheduling.utils
{
    public class ErrorUtil : SystemException
    {
        public ErrorUtil() { }
        public ErrorUtil(string msg) : base(msg) { }
    }
}