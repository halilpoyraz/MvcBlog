using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MvcBlog.Models.Mapping
{
    public class SiteTakipMap : EntityTypeConfiguration<SiteTakip>
    {
        public SiteTakipMap()
        {
            // Primary Key
            this.HasKey(t => t.MailAdress);

            // Properties
            this.Property(t => t.MailAdress)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("SiteTakip");
            this.Property(t => t.MailAdress).HasColumnName("MailAdress");
            this.Property(t => t.YazarID).HasColumnName("YazarID");
            this.Property(t => t.KategoriID).HasColumnName("KategoriID");

            // Relationships
            this.HasOptional(t => t.Kategori)
                .WithMany(t => t.SiteTakips)
                .HasForeignKey(d => d.KategoriID);
            this.HasOptional(t => t.Kullanici)
                .WithMany(t => t.SiteTakips)
                .HasForeignKey(d => d.YazarID);

        }
    }
}
