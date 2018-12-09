namespace couse.mod
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Curators
    {
        [Key]
        [StringLength(30)]
        public string FIO { get; set; }

        public int? number_of_group { get; set; }
    }
}
