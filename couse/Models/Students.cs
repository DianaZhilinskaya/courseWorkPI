//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace couse.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Students
    {
        public int students_id { get; set; }
        public Nullable<int> count_of_students { get; set; }
        public Nullable<int> place_of_residence { get; set; }
        public Nullable<int> needing_social_protection { get; set; }
        public Nullable<int> underage_students { get; set; }
        public Nullable<int> information_about_student_families { get; set; }
        public Nullable<bool> internal_control_students { get; set; }
        public Nullable<bool> underperforming_students { get; set; }
        public Nullable<bool> family_students { get; set; }
        public Nullable<bool> students_with_children { get; set; }
        public Nullable<bool> with_severe_chronic_diseases { get; set; }
        public Nullable<int> form_of_education { get; set; }
        public Nullable<bool> student_activists { get; set; }
    
        public virtual Count_of_students Count_of_students1 { get; set; }
        public virtual Form_of_education Form_of_education1 { get; set; }
        public virtual Information_about_student_families Information_about_student_families1 { get; set; }
        public virtual Needing_social_protection Needing_social_protection1 { get; set; }
        public virtual Place_of_residence Place_of_residence1 { get; set; }
        public virtual Students_id Students_id1 { get; set; }
    }
}