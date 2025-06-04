using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.scheduling.model
{
    public class WorkItem : work_detail
    {
        public WorkItem() { }

        public WorkItem(WorkItem workItem) {
            base.id = workItem.id;
            base.order_id = workItem.order_id;
            base.work_num = workItem.work_num;
            base.work_start_date = workItem.work_start_date;
            base.company = workItem.company;
            base.row_num = workItem.row_num;
            base.is_insert = workItem.is_insert;
            this.moduleInfo = workItem.moduleInfo;
            this.workDayList = workItem.workDayList;
            this.orderId = workItem.orderId;
            this.type = workItem.type;
        }

        public module_info moduleInfo { get; set; }
        public List<WorkDay> workDayList { get; set; }
        public string orderId { get; set; }
        public string type { get; set; }
    }
}