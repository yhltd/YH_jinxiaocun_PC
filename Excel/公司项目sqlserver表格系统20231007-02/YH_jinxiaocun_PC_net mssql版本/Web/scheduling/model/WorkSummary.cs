using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.scheduling.model
{
    public class WorkSummary
    {
        public string type { get; set; }
        public string name { get; set; }
        public double num { get; set; }
        public string parentName { get; set; }
        public int workNum { get; set; }
    }
}