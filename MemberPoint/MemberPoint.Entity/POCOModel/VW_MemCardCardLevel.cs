namespace MemberPoint.Entity.POCOModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VW_MemCardCardLevel
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MC_ID { get; set; }

        public int? CL_ID { get; set; }

        public int? S_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string MC_CardID { get; set; }

        [StringLength(20)]
        public string MC_Password { get; set; }

        [StringLength(20)]
        public string MC_Name { get; set; }

        public int? MC_Sex { get; set; }

        [StringLength(50)]
        public string MC_Mobile { get; set; }

        [StringLength(200)]
        public string MC_Photo { get; set; }

        public int? MC_Birthday_Month { get; set; }

        public int? MC_Birthday_Day { get; set; }

        public byte? MC_BirthdayType { get; set; }

        public bool? MC_IsPast { get; set; }

        public DateTime? MC_PastTime { get; set; }

        public int? MC_Point { get; set; }

        public float? MC_Money { get; set; }

        public float? MC_TotalMoney { get; set; }

        public int? MC_TotalCount { get; set; }

        public int? MC_OverCount { get; set; }

        public int? MC_State { get; set; }

        public bool? MC_IsPointAuto { get; set; }

        public int? MC_RefererID { get; set; }

        [StringLength(50)]
        public string MC_RefererCard { get; set; }

        [StringLength(20)]
        public string MC_RefererName { get; set; }

        public DateTime? MC_CreateTime { get; set; }

        [StringLength(20)]
        public string CL_LevelName { get; set; }
    }
}
