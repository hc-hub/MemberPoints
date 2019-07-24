using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPoint.Entity.ViewModel
{
    public class MemberCardListViewModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int Id { get; set; }

        public string CardId { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }

        public float TotalMoney { get; set; }
        public float Money { get; set; }

        public string State { get; set; }

        public int Point { get; set; }

        public string Sex { get; set; }

        public DateTime CreateTime { get; set; }

        public string CardLevelName { get; set; }
    }
}
