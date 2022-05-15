using RottenTomatoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RottenTomatoes.Data.Repos
{
    public class DirectorsMoviesRepo: BaseRepo<DirectorsMovies>
    {
        public override int Delete(int id)
        {
            var a = GetAll().Where(m => m.Id == id).First();
            _db.DirectorsMovies.Remove(a);
            return _db.SaveChanges();
        }
    }
}
