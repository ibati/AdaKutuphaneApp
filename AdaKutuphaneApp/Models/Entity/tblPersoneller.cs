//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdaKutuphaneApp.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblPersoneller
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPersoneller()
        {
            this.tblHareketler = new HashSet<tblHareketler>();
        }
    
        public int ID { get; set; }
        public string AD { get; set; }
        public string SOYAD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblHareketler> tblHareketler { get; set; }
    }
}