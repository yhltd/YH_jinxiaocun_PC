using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.scheduling.utils
{
    public class TimeError : SystemException
    {
        public TimeError() { }
        public TimeError(string msg) : base(msg) { }
    }
}