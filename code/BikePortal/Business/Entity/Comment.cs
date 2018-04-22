using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePortal.Business.Entity
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public DateTime Date { get; set; }
        public User Commenter { get; set; }
    }
}
