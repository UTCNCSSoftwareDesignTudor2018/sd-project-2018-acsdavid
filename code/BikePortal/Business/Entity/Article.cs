using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePortal.Business.Entity
{
    public abstract class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual User Uploader { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
