//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web.scheduling.model
{
    using System;
    using System.Collections.Generic;
    
    public partial class time_config
    {
        public int id { get; set; }
        public Nullable<int> week { get; set; }
        public string morning_start { get; set; }
        public string morning_end { get; set; }
        public string noon_start { get; set; }
        public string noon_end { get; set; }
        public string night_start { get; set; }
        public string night_end { get; set; }
        public string company { get; set; }
    }
}
