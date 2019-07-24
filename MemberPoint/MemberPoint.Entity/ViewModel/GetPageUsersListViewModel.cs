using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPoint.Entity.ViewModel
{
    public class GetPageUsersListViewModel
    {
        /// <summary>
        /// 登录姓名
        /// </summary>
        public string U_LoginName { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string U_RealName { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string U_Telephone { get; set; }
        /// <summary>
        /// 当前页数
        /// </summary>
        public int pageIndex { get; set; }
        /// <summary>
        /// 页大小
        /// </summary>
        public int pageSize { get; set; }
    }
}
