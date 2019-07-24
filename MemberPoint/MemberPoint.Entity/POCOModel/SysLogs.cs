namespace MemberPoint.Entity.POCOModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SysLogs
    {
        [Key]
        public int SL_ID { get; set; }

        public int? U_ID { get; set; }

        [StringLength(20)]
        public string SL_Module { get; set; }

        [StringLength(255)]
        public string SL_Details { get; set; }

        public DateTime? SL_CreateTime { get; set; }

        public virtual Users Users { get; set; }
    }
}
