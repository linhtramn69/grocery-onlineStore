//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BachHoaVeSau
{
    using System;
    using System.Collections.Generic;
    
    public partial class DONDAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONDAT()
        {
            this.CHITIETDONDATs = new HashSet<CHITIETDONDAT>();
            this.HOADONs = new HashSet<HOADON>();
        }
    
        public int MADONDAT { get; set; }
        public System.DateTime NGAYGIO { get; set; }
        public string SDTNHAN { get; set; }
        public int TONG { get; set; }
        public int TRANGTHAI { get; set; }
        public string DIACHINHAN { get; set; }
        public int ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONDAT> CHITIETDONDATs { get; set; }
        public virtual KHACHHANG KHACHHANG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
    }
}
