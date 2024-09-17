using Microsoft.AspNetCore.Identity;
using SpaceHub.DataAccess.Data;
using SpaceHub.DataAccess.Repository.IRepository;
using SpaceHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceHub.DataAccess.Repository
{
    public class AppUserRepository : Repository<ApplicationUser>, IAppUserRepository
    {
        private ApplicationDBContext _db;
        public AppUserRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;

        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(ApplicationUser obj)
        {
            _db.ApplicationUsers.Update(obj);
        }
    }
}
