using System;
using System.Collections.Generic;

namespace MvcBlog.Models
{
    public partial class Kategori
    {
        public Kategori()
        {
            this.Makales = new List<Makale>();
            this.SiteTakips = new List<SiteTakip>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }
        public virtual ICollection<Makale> Makales { get; set; }
        public virtual ICollection<SiteTakip> SiteTakips { get; set; }
    }
}
