namespace couse.mod
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Students_all
    {
        [Key]
        [StringLength(50)]
        public string FIO { get; set; }

        public int? number_of_group { get; set; }

        public bool? from_Minsk { get; set; }

        public bool? from_the_countryside { get; set; }

        public bool? from_other_regions { get; set; }

        public bool? from_CIS_countries { get; set; }

        public bool? from_other_countries { get; set; }

        public bool? in_dorm { get; set; }

        public bool? in_a_private_apartment { get; set; }

        public bool? houses { get; set; }

        public bool? at_full_state_providing { get; set; }

        public bool? have_a_guardian { get; set; }

        public int? orphan_students { get; set; }

        public bool? lost_the_last_of_the_parents_in_the_period_of_study { get; set; }

        public bool? in_custody { get; set; }

        public bool? disabled_students { get; set; }

        public int? underage_students { get; set; }

        public bool? single_parent_students { get; set; }

        public bool? students_from_large_families { get; set; }

        public bool? students_with_disabled_parents_1_2_groups { get; set; }

        public bool? affected_by_the_Chernobyl_accident { get; set; }

        public bool? disaster_victims { get; set; }

        public bool? refugee_families { get; set; }

        public bool? parents_died_during_passage_of_military_or_police_services { get; set; }

        public bool? internal_control_students { get; set; }

        public bool? underperforming_students { get; set; }

        public bool? family_students { get; set; }

        public bool? students_with_children { get; set; }

        public bool? with_severe_chronic_diseases { get; set; }

        public bool? budget { get; set; }

        public bool? paid { get; set; }

        public bool? student_activists { get; set; }
    }
}
