using System;
using System.Collections.Generic;

namespace MvcBlog.Models
{
    public partial class MakaleTip
    {
        public MakaleTip()
        {
            this.Makales = new List<Makale>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }
        public virtual ICollection<Makale> Makales { get; set; }
    }
}
