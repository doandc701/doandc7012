//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_flim.Areas.Admin.Models.Framework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Phim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phim()
        {
            this.ListDV = new HashSet<ListDV>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Time { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string Image { get; set; }
        public string Detail { get; set; }
        public Nullable<bool> Active { get; set; }
        public string ChiMuc { get; set; }
        public string Video { get; set; }
    
        public virtual DanhMuc DanhMuc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListDV> ListDV { get; set; }
    }
}