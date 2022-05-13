using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RottenTomatoes.Models
{
    public class DirectorsMovies: BaseEntity
    {
       
        [Column("DMId")]
        public override int Id { get; set; }
        public int DirectorId { get; set; }

        public int MovieId{ get; set; }
        public virtual Director Director { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
