namespace MemberPoint.Entity.POCOModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VW_ShopCategoryItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int S_ID { get; set; }

        [StringLength(20)]
        public string S_Name { get; set; }

        public int? S_Category { get; set; }

        [StringLength(20)]
        public string S_ContactName { get; set; }

        [StringLength(20)]
        public string S_ContactTel { get; set; }

        [StringLength(50)]
        public string S_Address { get; set; }

        [StringLength(100)]
        public string S_Remark { get; set; }

        public bool? S_IsHasSetAdmin { get; set; }

        public DateTime? S_CreateTime { get; set; }

        [StringLength(20)]
        public string C_Category { get; set; }

        public int? CI_ID { get; set; }

        [StringLength(20)]
        public string CI_Name { get; set; }
    }
}
