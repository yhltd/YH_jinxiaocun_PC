using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.scheduling.utils
{
    public class ErrorUtil1 : SystemException
    {
        public ErrorUtil1() { }
        public ErrorUtil1(string msg) : base(msg) { }
    }
}