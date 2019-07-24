using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPoint.Entity.ViewModel
{
    public class GetPagedMemberCardListViewModel
    {
        /// <summary>
        /// 会员卡号
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// 会员姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 会员等级
        /// </summary>
        public int CardLevelId { get; set; }

        /// <summary>
        /// 当前页数
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// 页大小
        /// </summary>
        public int rows { get; set; }
    }
}
