using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPoint.Entity.ViewModel
{
    public class UsersViewModel
    {
        [Display(Name = "用户ID")]
        public int U_ID { get; set; }

        [Display(Name = "店铺名称")]
        public string S_Name { get; set; }

        [Display(Name = "登录姓名")]
        public string U_LoginName { get; set; }

        [Display(Name = "用户姓名")]
        public string U_Password { get; set; }

        [Display(Name = "真实姓名")]
        public string U_RealName { get; set; }

        [Display(Name = "性别")]
        public string U_Sex { get; set; }

        [Display(Name = "电话")]
        public string U_Telephone { get; set; }

        [Display(Name = "角色")]
        public string U_RoleName { get; set; }

        [Display(Name = "是否删除")]
        public bool? U_CanDelete { get; set; }
    }
}
