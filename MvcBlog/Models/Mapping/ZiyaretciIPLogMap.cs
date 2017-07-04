using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MvcBlog.Models.Mapping
{
    public class ZiyaretciIPLogMap : EntityTypeConfiguration<ZiyaretciIPLog>
    {
        public ZiyaretciIPLogMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IPAddress, t.Tarih });

            // Properties
            this.Property(t => t.IPAddress)
                .IsRequired()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("ZiyaretciIPLog");
            this.Property(t => t.IPAddress).HasColumnName("IPAddress");
            this.Property(t => t.Tarih).HasColumnName("Tarih");
        }
    }
}
