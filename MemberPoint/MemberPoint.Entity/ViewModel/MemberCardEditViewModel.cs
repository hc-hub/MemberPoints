using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemberPoint.Common;

namespace MemberPoint.Entity.ViewModel
{
    public class MemberCardEditViewModel
    {
        public int Id { get; set; }
        public string CardId { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }


        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "两次输入的密码不一致")]
        public string PasswordConfirm { get; set; }

        public SexTypeEnum Sex { get; set; }

        public int CardLevelId { get; set; }

        public int BirthdayType { get; set; }

        public int BirthdayMonth { get; set; }

        public int BirthdayDay { get; set; }

        public bool IsPast { get; set; }

        public string PastTime { get; set; }

        public CardStateTypeEnum CardState { get; set; }

        public decimal Money { get; set; }
        public decimal TotalMoney { get; set; }

        public int Point { get; set; }

        public bool IsPointAuto { get; set; }

        public string RefererCard { get; set; }

        public string RefererName { get; set; }

        public int RefererID { get; set; }

    }
}
