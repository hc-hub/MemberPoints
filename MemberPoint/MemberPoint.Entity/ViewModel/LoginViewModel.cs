using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPoint.Entity.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="用户名必填")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "用户密码必填")]
        [DataType(DataType.Password,ErrorMessage ="输入的格式不正确")]
        public string Password { get; set; }
    }
}
