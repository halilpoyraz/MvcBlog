using System;
using System.Collections.Generic;

namespace MvcBlog.Models
{
    public partial class SiteTakip
    {
        public string MailAdress { get; set; }
        public Nullable<System.Guid> YazarID { get; set; }
        public Nullable<int> KategoriID { get; set; }
        public virtual Kategori Kategori { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}
