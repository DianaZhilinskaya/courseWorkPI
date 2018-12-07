namespace couse
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Students
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int students_id { get; set; }

        public int? count_of_students { get; set; }

        public int? place_of_residence { get; set; }

        public int? needing_social_protection { get; set; }

        public int? underage_students { get; set; }

        public int? information_about_student_families { get; set; }

        public bool? internal_control_students { get; set; }

        public bool? underperforming_students { get; set; }

        public bool? family_students { get; set; }

        public bool? students_with_children { get; set; }

        public bool? with_severe_chronic_diseases { get; set; }

        public int? form_of_education { get; set; }

        public bool? student_activists { get; set; }

        public virtual Count_of_students Count_of_students1 { get; set; }

        public virtual Form_of_education Form_of_education1 { get; set; }

        public virtual Information_about_student_families Information_about_student_families1 { get; set; }

        public virtual Needing_social_protection Needing_social_protection1 { get; set; }

        public virtual Place_of_residence Place_of_residence1 { get; set; }

        public virtual Students_id Students_id1 { get; set; }
    }
}
