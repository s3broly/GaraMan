using GaraMan.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace GaraMan.GaraDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Thanhvien385> Thanhviens { get; set; }
        public DbSet<Nhanvien385> Nhanviens { get; set; }
        public DbSet<Khachhang385> Khachhangs { get; set; }
        public DbSet<Nhacungcap385> Nhacungcaps { get; set; }
        public DbSet<Nhanvienbanhang385> Nhanvienbanhangs { get; set; }
        public DbSet<Nhanvienkho385> Nhanvienkhos { get; set; }
        public DbSet<NhanvienKT385> NhanvienKTs { get; set; }
        public DbSet<Nhanvienquanly385> Nhanvienquanlys {  get; set; }
        public DbSet<Phutung385> Phutungs { get; set; }
        public DbSet<Dichvu385> Dichvus { get; set; }
        public DbSet<Lichhen385> Lichhens { get; set; }
        public DbSet<Phutungyeucau385> Phutungyeucaus {  get; set; }
        public DbSet<Dichvuyeucau385> Dichvuyeucaus {  get; set; }
        public DbSet<Hoadonnhap385> Hoadonnhaps { get; set; }
        public DbSet<Hoadon385> Hoadons {  get; set; }
        //public DbSet<TKDichvu385> TKDichvus { get; set; }
        //public DbSet<TKPhutung385> TKPhutungs { get; set; }
        //public DbSet<TKKhachhang385> TKKhachhangs { get; set; }
        //public DbSet<TKNhacungcap385> TKNhacungcaps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Lichhen385>()
                .HasOne(l => l.Khachhang)
                .WithMany() 
                .HasForeignKey("KhachhangId");

            modelBuilder.Entity<Hoadonnhap385>()
            .HasOne(h => h.nhacungcap)
            .WithMany() 
            .HasForeignKey("NhacungcapId");

            modelBuilder.Entity<Hoadonnhap385>()
                .HasOne(h => h.nhanvienkho)
                .WithMany()
                .HasForeignKey("NhanvienkhoId");

            modelBuilder.Entity<Hoadonnhap385>()
                .HasMany(h => h.ListPhutung)
                .WithOne()
                .HasForeignKey("HoadonnhapId");
        }
    }
}
