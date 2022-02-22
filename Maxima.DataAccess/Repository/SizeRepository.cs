using Maxima.DataAccess.Data;
using Maxima.DataAccess.Repository.IRepository;
using Maxima.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxima.DataAccess.Repository
{
    public class SizeRepository : Repository<Size>, ISizeRepository
    {
        private ApplicationDbContext _db;
        public SizeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Size obj)
        {
            _db.Size.Update(obj);
        }
    }
}

