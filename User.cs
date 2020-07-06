using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchServer.BaseClass
{
    public class User
    {
        public int userID = -1;//用户ID
        public string userDept = "";//用户部门
        public string userName = "";//用户姓名
        public string userRole = "";//用户角色
        public string loginName = "";//登录用户名
        public string loginPassword = "";//登录密码

        public User()
        { }

        public User(int userID,string userDept, string userName, string userRole, string loginName, string loginPassword)
        {
            this.userID = userID;
            this.userDept = userDept;
            this.userName = userName;
            this.userRole = userRole;
            this.loginName = loginName;
            this.loginPassword = loginPassword;
        }
    }
}
