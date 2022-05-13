using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RottenTomatoes.Models
{
    public class Tomatoe: BaseEntity
    {
        public Tomatoe()
        {
            Comments = new HashSet<Comment>();

        }
        [Column("TomatoeId")]
        public override int Id { get; set; }
        public string TomatoeName { get; set; }

        public string Password { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
