using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPoint.Entity.ViewModel
{
    public class TransferMoneyViewModel
    {

    //    EXEC dbo.SP_TransferMoney @userId = 1, -- int
    //@fromMemberCardId = '123456', -- varchar(64)
    //@toMemberCardId = '654321', -- varchar(64)
    //@transferMoney = 1000000000, -- decimal(18, 0)
    //@remark = N'转你一个亿', -- nvarchar(128)
    //@errorMsg = @errorMsg OUTPUT -- nvarchar(128)

        public int UserId { get; set; }

        public string FromMemberCardId { get; set; }

        public string ToMemberCardId { get; set; }

        public decimal TransferMoney { get; set; }

        public string Remark { get; set; }

      

    }
}
