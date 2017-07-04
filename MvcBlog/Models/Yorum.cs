using System;
using System.Collections.Generic;

namespace MvcBlog.Models
{
    public partial class Yorum
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public int MakaleID { get; set; }
        public System.DateTime EklenmeTarihi { get; set; }
        public System.Guid YazarID { get; set; }
        public bool Aktif { get; set; }
        public virtual Kullanici Kullanici { get; set; }
        public virtual Makale Makale { get; set; }
    }
}
