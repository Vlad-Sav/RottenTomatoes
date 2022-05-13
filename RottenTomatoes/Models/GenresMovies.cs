using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RottenTomatoes.Models
{
    public class GenresMovies: BaseEntity
    {
      
        [Column("GMId")]
        public override int Id { get; set; }
        public int GenreId { get; set; }

        public int MovieId { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
