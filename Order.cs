using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatchServer.BaseUtil;

namespace DispatchServer.BaseClass
{
    public class Order
    {
        public int orderId;//调度令ID
        public string orderCode;//文号

        public List<OrderOp> orderOpList;
        public List<OrderRecord> orderRecordList;

        public Order()
        {
            orderId=-1;
            orderCode = null;
            orderOpList = null;
            orderRecordList = null;
        }

        public Order(
            List<OrderOp> orderOpList,
            List<OrderRecord> orderRecordList
            )
        {
            this.orderOpList = orderOpList;
            this.orderRecordList = orderRecordList;
            this.orderId = orderOpList.ElementAt(0).orderId;
            this.orderCode = orderOpList.ElementAt(0).orderCode;
        }
    }
}
