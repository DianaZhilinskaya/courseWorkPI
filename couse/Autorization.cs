namespace couse
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Autorization")]
    public partial class Autorization
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string login_user { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string password_user { get; set; }
    }
}
