using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MvcBlog.Models.Mapping
{
    public class YorumMap : EntityTypeConfiguration<Yorum>
    {
        public YorumMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Baslik)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Icerik)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Yorum");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Baslik).HasColumnName("Baslik");
            this.Property(t => t.Icerik).HasColumnName("Icerik");
            this.Property(t => t.MakaleID).HasColumnName("MakaleID");
            this.Property(t => t.EklenmeTarihi).HasColumnName("EklenmeTarihi");
            this.Property(t => t.YazarID).HasColumnName("YazarID");
            this.Property(t => t.Aktif).HasColumnName("Aktif");

            // Relationships
            this.HasRequired(t => t.Kullanici)
                .WithMany(t => t.Yorums)
                .HasForeignKey(d => d.YazarID);
            this.HasRequired(t => t.Makale)
                .WithMany(t => t.Yorums)
                .HasForeignKey(d => d.MakaleID);

        }
    }
}
