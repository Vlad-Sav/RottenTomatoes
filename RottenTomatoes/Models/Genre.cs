using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RottenTomatoes.Models
{
    public class Genre: BaseEntity
    {
        public Genre()
        {
            GenresMovies = new HashSet<GenresMovies>();

        }
        [Column("GenreId")]
        public override int Id { get; set; }
        public string GenreName { get; set; }
        public virtual ICollection<GenresMovies> GenresMovies { get; set; }
    }
}
