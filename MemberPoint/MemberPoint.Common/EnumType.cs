using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPoint.Common
{
    public enum CardStateTypeEnum
    {
        [Description("正常")]
        正常 = 1,
        [Description("挂失")]
        挂失 = 2,
        [Description("锁定")]
        锁定 = 3
    }
    public enum OrderTypeEnum
    {
        [Description("兑换积分")]
        兑换积分 = 1,
        [Description("积分返现")]
        积分返现 = 2,
        [Description("减积分")]
        减积分 = 3,
        [Description("转介绍积分")]
        转介绍积分 = 4,
        [Description("快速消费")]
        快速消费 = 5
    }
    public enum RoleTypeEnum
    {
        [Description("系统管理员")]
        系统管理员 = 1,
        [Description("店长")]
        店长 = 2,
        [Description("业务员")]
        业务员 = 3
    }
    public enum SexTypeEnum
    {
        [Description("男")]
        男 = 1,
        [Description("女")]
        女 = 2
    }
    public enum CategoryTypeEnum
    {
        [Description("总部")]
        总部 = 1,
        [Description("加盟店")]
        加盟店 = 2,
        [Description("自营店")]
        自营店 = 3
    }
}
