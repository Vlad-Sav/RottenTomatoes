using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RottenTomatoes.Models
{
    public class Director: BaseEntity
    {
        public Director()
        {
            DirectorsMovies = new HashSet<DirectorsMovies>();
 
        }
        [Column("DirectorId")]
        public override int Id { get; set; }
        public string DirectorName { get; set; }

        public string DirectorSurname { get; set; }
        public virtual ICollection<DirectorsMovies> DirectorsMovies { get; set; }
      
    }
}
