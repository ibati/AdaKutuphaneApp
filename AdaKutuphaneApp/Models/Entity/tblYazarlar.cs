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
    using System.ComponentModel.DataAnnotations;

    public partial class tblYazarlar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblYazarlar()
        {
            this.tblKitaplar = new HashSet<tblKitaplar>();
        }
    
        public int ID { get; set; }

        [Required(ErrorMessage = "L�tfen yazar ad� giriniz")]
        public string AD { get; set; }

        [Required(ErrorMessage = "L�tfen yazar soyad� giriniz")]
        public string SOYAD { get; set; }
        public string DETAY { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblKitaplar> tblKitaplar { get; set; }
    }
}
