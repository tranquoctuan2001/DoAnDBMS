﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Book.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DoAnEntities1 : DbContext
    {
        public DoAnEntities1()
            : base("name=DoAnEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NguoiQuanLy> NguoiQuanLies { get; set; }
        public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<DatHang> DatHangs { get; set; }
        public virtual DbSet<Gio> Gios { get; set; }
        public virtual DbSet<View_KH> View_KH { get; set; }
        public virtual DbSet<view_thongtinKH> view_thongtinKH { get; set; }
    
        [DbFunction("DoAnEntities1", "SumMoney")]
        public virtual IQueryable<SumMoney_Result> SumMoney(Nullable<int> maHD)
        {
            var maHDParameter = maHD.HasValue ?
                new ObjectParameter("MaHD", maHD) :
                new ObjectParameter("MaHD", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<SumMoney_Result>("[DoAnEntities1].[SumMoney](@MaHD)", maHDParameter);
        }
    
        public virtual ObjectResult<BookNotOrder_Result> BookNotOrder()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BookNotOrder_Result>("BookNotOrder");
        }
    
        public virtual ObjectResult<BookNotSell_Result> BookNotSell()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BookNotSell_Result>("BookNotSell");
        }
    
        public virtual int Don(Nullable<int> maKH, Nullable<System.DateTime> ngayDat, string maSach, Nullable<int> soLuong)
        {
            var maKHParameter = maKH.HasValue ?
                new ObjectParameter("MaKH", maKH) :
                new ObjectParameter("MaKH", typeof(int));
    
            var ngayDatParameter = ngayDat.HasValue ?
                new ObjectParameter("NgayDat", ngayDat) :
                new ObjectParameter("NgayDat", typeof(System.DateTime));
    
            var maSachParameter = maSach != null ?
                new ObjectParameter("MaSach", maSach) :
                new ObjectParameter("MaSach", typeof(string));
    
            var soLuongParameter = soLuong.HasValue ?
                new ObjectParameter("SoLuong", soLuong) :
                new ObjectParameter("SoLuong", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Don", maKHParameter, ngayDatParameter, maSachParameter, soLuongParameter);
        }
    
        public virtual int PhanQuyenAdmin(string login, string db)
        {
            var loginParameter = login != null ?
                new ObjectParameter("login", login) :
                new ObjectParameter("login", typeof(string));
    
            var dbParameter = db != null ?
                new ObjectParameter("db", db) :
                new ObjectParameter("db", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PhanQuyenAdmin", loginParameter, dbParameter);
        }
    
        public virtual int PhanQuyenUser(string login, string db)
        {
            var loginParameter = login != null ?
                new ObjectParameter("login", login) :
                new ObjectParameter("login", typeof(string));
    
            var dbParameter = db != null ?
                new ObjectParameter("db", db) :
                new ObjectParameter("db", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PhanQuyenUser", loginParameter, dbParameter);
        }
    
        public virtual ObjectResult<recommend_Result> recommend(string theloai)
        {
            var theloaiParameter = theloai != null ?
                new ObjectParameter("theloai", theloai) :
                new ObjectParameter("theloai", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<recommend_Result>("recommend", theloaiParameter);
        }
    
        public virtual ObjectResult<searchBook_Result> searchBook(string tenSach)
        {
            var tenSachParameter = tenSach != null ?
                new ObjectParameter("tenSach", tenSach) :
                new ObjectParameter("tenSach", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<searchBook_Result>("searchBook", tenSachParameter);
        }
    
        public virtual int TongTien(Nullable<int> maKH)
        {
            var maKHParameter = maKH.HasValue ?
                new ObjectParameter("MaKH", maKH) :
                new ObjectParameter("MaKH", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("TongTien", maKHParameter);
        }
    
        public virtual int TraTien(Nullable<int> maKH, Nullable<decimal> tien, Nullable<System.DateTime> ngayNhan)
        {
            var maKHParameter = maKH.HasValue ?
                new ObjectParameter("MaKH", maKH) :
                new ObjectParameter("MaKH", typeof(int));
    
            var tienParameter = tien.HasValue ?
                new ObjectParameter("Tien", tien) :
                new ObjectParameter("Tien", typeof(decimal));
    
            var ngayNhanParameter = ngayNhan.HasValue ?
                new ObjectParameter("NgayNhan", ngayNhan) :
                new ObjectParameter("NgayNhan", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("TraTien", maKHParameter, tienParameter, ngayNhanParameter);
        }
    
        public virtual ObjectResult<ViewCart_Result> ViewCart(Nullable<int> maKH)
        {
            var maKHParameter = maKH.HasValue ?
                new ObjectParameter("MaKH", maKH) :
                new ObjectParameter("MaKH", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ViewCart_Result>("ViewCart", maKHParameter);
        }
    
        public virtual int XoaHoaDon(Nullable<int> maHD, string maSach)
        {
            var maHDParameter = maHD.HasValue ?
                new ObjectParameter("MaHD", maHD) :
                new ObjectParameter("MaHD", typeof(int));
    
            var maSachParameter = maSach != null ?
                new ObjectParameter("MaSach", maSach) :
                new ObjectParameter("MaSach", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("XoaHoaDon", maHDParameter, maSachParameter);
        }
    
        public virtual int XoaQuyenAdmin(string login, string db)
        {
            var loginParameter = login != null ?
                new ObjectParameter("login", login) :
                new ObjectParameter("login", typeof(string));
    
            var dbParameter = db != null ?
                new ObjectParameter("db", db) :
                new ObjectParameter("db", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("XoaQuyenAdmin", loginParameter, dbParameter);
        }
    
        public virtual int XoaQuyenUser(string login, string db)
        {
            var loginParameter = login != null ?
                new ObjectParameter("login", login) :
                new ObjectParameter("login", typeof(string));
    
            var dbParameter = db != null ?
                new ObjectParameter("db", db) :
                new ObjectParameter("db", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("XoaQuyenUser", loginParameter, dbParameter);
        }
    }
}
