using RottenTomatoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RottenTomatoes.Data.Repos
{
    public class TomatoesRepo: BaseRepo<Tomatoe>
    {
        public override int Delete(int id)
        {
            var a = GetAll().Where(m => m.Id == id).First();
            _db.Tomatoes.Remove(a);
            return _db.SaveChanges();
        }
    }
}
