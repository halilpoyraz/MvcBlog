using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MvcBlog.Models.Mapping
{
    public class ResimMap : EntityTypeConfiguration<Resim>
    {
        public ResimMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Adi)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.KucukResimYol)
                .HasMaxLength(500);

            this.Property(t => t.OrtaResimYol)
                .HasMaxLength(500);

            this.Property(t => t.BuyukResimYol)
                .HasMaxLength(500);

            this.Property(t => t.VideoYol)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Resim");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Adi).HasColumnName("Adi");
            this.Property(t => t.KucukResimYol).HasColumnName("KucukResimYol");
            this.Property(t => t.OrtaResimYol).HasColumnName("OrtaResimYol");
            this.Property(t => t.BuyukResimYol).HasColumnName("BuyukResimYol");
            this.Property(t => t.VideoYol).HasColumnName("VideoYol");
            this.Property(t => t.EkleyenID).HasColumnName("EkleyenID");
            this.Property(t => t.EklenmeTarihi).HasColumnName("EklenmeTarihi");
            this.Property(t => t.Goruntulenme).HasColumnName("Goruntulenme");
            this.Property(t => t.Begeni).HasColumnName("Begeni");

            // Relationships
            this.HasRequired(t => t.Kullanici)
                .WithMany(t => t.Resims)
                .HasForeignKey(d => d.EkleyenID);

        }
    }
}
