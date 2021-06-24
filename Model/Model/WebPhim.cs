using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Model.Model
{
    public partial class WebPhim : DbContext
    {
        public WebPhim()
            : base("name=WebPhim")
        {
        }

        public virtual DbSet<BinhLuan> BinhLuans { get; set; }
        public virtual DbSet<ChuDe> ChuDes { get; set; }
        public virtual DbSet<Phim> Phims { get; set; }
        public virtual DbSet<QuyenSuDung> QuyenSuDungs { get; set; }
        public virtual DbSet<QuyenUser> QuyenUsers { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BinhLuan>()
                .Property(e => e.TenTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<ChuDe>()
                .HasMany(e => e.Phims)
                .WithMany(e => e.ChuDes)
                .Map(m => m.ToTable("Phim_ChuDe").MapLeftKey("idChuDe").MapRightKey("idPhim"));

            modelBuilder.Entity<Phim>()
                .Property(e => e.Anh)
                .IsUnicode(false);

            modelBuilder.Entity<Phim>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<Phim>()
                .HasMany(e => e.BinhLuans)
                .WithRequired(e => e.Phim)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuyenSuDung>()
                .HasMany(e => e.QuyenUsers)
                .WithRequired(e => e.QuyenSuDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuyenUser>()
                .Property(e => e.TenTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TenTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.PassWord)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.BinhLuans)
                .WithRequired(e => e.TaiKhoan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.QuyenUsers)
                .WithRequired(e => e.TaiKhoan)
                .WillCascadeOnDelete(false);
        }
    }
}
