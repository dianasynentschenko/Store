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
    public class TestRepository : Repository<Test>, ITestRepository
    {
        private ApplicationDbContext _db;
        public TestRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Test obj)
        {
            _db.Test.Update(obj);
        }
    }
}

