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
    public class AdditionalImgRepository : Repository<AdditionalImg>, IAdditionalImgRepository
    {
        private ApplicationDbContext _db;
        public AdditionalImgRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(AdditionalImg obj)
        {
            _db.AdditionalImg.Update(obj);
        }

    }
}

