namespace MemberPoint.Entity.POCOModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VW_UserCategoryItems
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int U_ID { get; set; }

        public int? S_ID { get; set; }

        [StringLength(20)]
        public string U_LoginName { get; set; }

        [StringLength(50)]
        public string U_Password { get; set; }

        [StringLength(20)]
        public string U_RealName { get; set; }

        [StringLength(10)]
        public string U_Sex { get; set; }

        [StringLength(20)]
        public string U_Telephone { get; set; }

        public int? U_Role { get; set; }

        public bool? U_CanDelete { get; set; }

        [StringLength(20)]
        public string C_Category { get; set; }

        public int? CI_ID { get; set; }

        [StringLength(20)]
        public string CI_Name { get; set; }
    }
}
