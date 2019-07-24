using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPoint.Entity.ViewModel
{
    public class ShopEditViewModel
    {
        [Display(Name = "店铺编号")]
        [Required(ErrorMessage = "必须输入信息")]
        public int S_ID { get; set; }

        [Display(Name = "店铺名称")]
        [Required(ErrorMessage = "必须输入店铺名称")]
        [StringLength(maximumLength: 10, MinimumLength = 2, ErrorMessage = "字符长度在2~10之间")]
        public string S_Name { get; set; }

        [Display(Name = "店铺类型")]
        public int? S_Category { get; set; }

        [Display(Name = "联系人")]
        public string S_ContactName { get; set; }

        [Display(Name = "联系电话")]
        public string S_ContactTel { get; set; }

        [Display(Name = "地址")]
        public string S_Address { get; set; }

        [Display(Name = "备注")]
        public string S_Remark { get; set; }

        [Display(Name = "是否设置")]
        public bool? S_IsHasSetAdmin { get; set; }

        [Display(Name = "添加时间")]
        public DateTime? S_CreateTime { get; set; }
    }
}
