namespace MemberPoint.Entity.POCOModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConsumeOrderCategoryItem")]
    public partial class ConsumeOrderCategoryItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CO_ID { get; set; }

        public int? S_ID { get; set; }

        public int? U_ID { get; set; }

        [StringLength(20)]
        public string CO_OrderCode { get; set; }

        public byte? CO_OrderType { get; set; }

        public int? MC_ID { get; set; }

        [StringLength(50)]
        public string MC_CardID { get; set; }

        public int? EG_ID { get; set; }

        public float? CO_TotalMoney { get; set; }

        public float? CO_DiscountMoney { get; set; }

        public int? CO_GavePoint { get; set; }

        public float? CO_Recash { get; set; }

        [StringLength(255)]
        public string CO_Remark { get; set; }

        public DateTime? CO_CreateTime { get; set; }

        [StringLength(20)]
        public string C_Category { get; set; }

        public int? CI_ID { get; set; }

        [StringLength(20)]
        public string CI_Name { get; set; }

        [StringLength(20)]
        public string MC_Name { get; set; }

        [StringLength(50)]
        public string MC_Mobile { get; set; }

        public int? CL_ID { get; set; }
    }
}
