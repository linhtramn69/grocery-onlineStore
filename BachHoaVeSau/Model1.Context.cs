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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CuaHangBachHoaEntities : DbContext
    {
        public CuaHangBachHoaEntities()
            : base("name=CuaHangBachHoaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DONDAT> DONDATs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LOAISANPHAM> LOAISANPHAMs { get; set; }
        public virtual DbSet<SANPHAM> SANPHAMs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<CHITIETDONDAT> CHITIETDONDATs { get; set; }
        public virtual DbSet<GIOHANG> GIOHANGs { get; set; }
    }
}
