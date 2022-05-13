using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RottenTomatoes.Models
{
    public class Comment: BaseEntity
    {
       
        [Column("CommentId")]
        public override int Id { get; set; }
        public int TomatoeId { get; set; }

        public int MovieId { get; set; }
        public string Text { get; set; }
        public virtual Tomatoe Tomatoe { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
