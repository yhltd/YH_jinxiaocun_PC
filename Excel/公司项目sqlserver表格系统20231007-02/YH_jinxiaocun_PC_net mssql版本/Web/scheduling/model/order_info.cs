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
    
    public partial class order_info
    {
        public int id { get; set; }
        public string code { get; set; }
        public string product_name { get; set; }
        public string norms { get; set; }
        public string order_id { get; set; }
        public Nullable<System.DateTime> set_date { get; set; }
        public int set_num { get; set; }
        public string company { get; set; }
        public string is_complete { get; set; }
    }
}
