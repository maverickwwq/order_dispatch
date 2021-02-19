using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchServer.BaseClass
{
    public class Query
    {
        //查询功能相关变量
        public int queryUserID;//查询用户ID
        public string queryDept = null;//查询部门
        public string queryOrderODID = null;//查询调令的OD_ID
        public string queryStartTime = null;//查询收到调令的开始时间
        public string queryEndTime = null;//查询收到调令的结束时间
        public string []queryOrderStatus = null;//查询调令的状态
        public int pageSize;//每页记录数
        public int pageIndex;//当前页码
        public int totalPages;//总页数
        public int totalRecords;//记录总数

        public Query()
        { }
    }
}
