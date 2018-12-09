namespace couse.mod
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Students_id
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(50)]
        public string FIO { get; set; }

        public int? group_students { get; set; }

        public virtual Group_students Group_students1 { get; set; }

        public virtual Students Students { get; set; }
    }
}
