namespace couse.mod
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Information_about_student_families
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Information_about_student_families()
        {
            Students = new HashSet<Students>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public bool? single_parent_students { get; set; }

        public bool? students_from_large_families { get; set; }

        public bool? students_with_disabled_parents_1_2_groups { get; set; }

        public bool? affected_by_the_Chernobyl_accident { get; set; }

        public bool? disaster_victims { get; set; }

        public bool? refugee_families { get; set; }

        public bool? parents_died_during_passage_of_military_or_police_services { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Students> Students { get; set; }
    }
}
