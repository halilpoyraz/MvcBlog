using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MvcBlog.Models.Mapping
{
    public class MakaleMap : EntityTypeConfiguration<Makale>
    {
        public MakaleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Baslik)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.Icerik)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Makale");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Baslik).HasColumnName("Baslik");
            this.Property(t => t.Icerik).HasColumnName("Icerik");
            this.Property(t => t.YayimTarihi).HasColumnName("YayimTarihi");
            this.Property(t => t.KategriID).HasColumnName("KategriID");
            this.Property(t => t.MakaleTipID).HasColumnName("MakaleTipID");
            this.Property(t => t.YazarID).HasColumnName("YazarID");
            this.Property(t => t.KapakResimID).HasColumnName("KapakResimID");
            this.Property(t => t.Goruntulenme).HasColumnName("Goruntulenme");
            this.Property(t => t.Begeni).HasColumnName("Begeni");
            this.Property(t => t.Aktif).HasColumnName("Aktif");

            // Relationships
            this.HasMany(t => t.Resims)
                .WithMany(t => t.Makales1)
                .Map(m =>
                    {
                        m.ToTable("MakaleResim");
                        m.MapLeftKey("MakaleID");
                        m.MapRightKey("ResimID");
                    });

            this.HasRequired(t => t.Kategori)
                .WithMany(t => t.Makales)
                .HasForeignKey(d => d.KategriID);
            this.HasRequired(t => t.Kullanici)
                .WithMany(t => t.Makales)
                .HasForeignKey(d => d.YazarID);
            this.HasRequired(t => t.MakaleTip)
                .WithMany(t => t.Makales)
                .HasForeignKey(d => d.MakaleTipID);
            this.HasRequired(t => t.Resim)
                .WithMany(t => t.Makales)
                .HasForeignKey(d => d.KapakResimID);

        }
    }
}
