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
    
    public partial class Group_students
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Group_students()
        {
            this.Students_id = new HashSet<Students_id>();
        }
    
        public int ID { get; set; }
        public Nullable<int> number_of_group { get; set; }
        public string faculty { get; set; }
        public Nullable<int> year_of_create { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Students_id> Students_id { get; set; }
    }
}
