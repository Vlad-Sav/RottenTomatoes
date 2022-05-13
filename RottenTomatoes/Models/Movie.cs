using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RottenTomatoes.Models
{
    public class Movie: BaseEntity
    {
        public Movie()
        {
            DirectorsMovies = new HashSet<DirectorsMovies>();
            GenresMovies = new HashSet<GenresMovies>();
            Comments = new HashSet<Comment>();
        }
        [Column("MovieId")]
        public override int Id { get; set; }
        public string MovieName { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan Time { get; set; }
        public string BannerUrl { get; set; }
        public int Year { get; set; }
        public virtual ICollection<DirectorsMovies> DirectorsMovies { get; set; }
        public virtual ICollection<GenresMovies> GenresMovies { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
