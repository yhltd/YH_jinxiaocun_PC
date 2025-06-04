using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.jxc_service
{
    public class ServicePage
    {
        public int pageCount = 10;
        public int count;
        public int nowPage = 1;
        public int countPage;

        public int getLimit1()
        {
            return (this.nowPage - 1) * this.pageCount;
        }

        public int getLimit2()
        {
            return this.nowPage * this.pageCount;
        }
    }
}