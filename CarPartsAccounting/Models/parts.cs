//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarPartsAccounting.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class parts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public parts()
        {
            this.sold_parts = new HashSet<sold_parts>();
        }
    
        public int id { get; set; }
        public string part_name { get; set; }
        public string country { get; set; }
        public string firm { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sold_parts> sold_parts { get; set; }
    }
}
