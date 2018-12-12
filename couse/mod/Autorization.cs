namespace couse.mod
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("Autorization")]
    public partial class Autorization
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(70)]
        [DisplayName("Login")]
        public string login_user { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        [DisplayName("Password")]
        public string password_user { get; set; }
        
        //public string loginErrorMessage { get; set; }

    }
}
