using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPoint.Entity.ViewModel
{
    public class ShopListViewModel
    {
        public int S_ID { get; set; }

        [Display(Name = "店铺名称")]
        public string S_Name { get; set; }

        [Display(Name = "店铺类型")]
        public string S_Category { get; set; }

        [Display(Name = "联系人")]
        public string S_ContactName { get; set; }

        [Display(Name = "联系电话")]
        public string S_ContactTel { get; set; }

        [Display(Name = "地址")]
        public string S_Address { get; set; }

        [Display(Name = "备注")]
        public string S_Remark { get; set; }
    }
}
