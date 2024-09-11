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
    public class UserRepository : Repository<User>, IUserRepository
    {
        private  ApplicationDBContext _db;
        public UserRepository(ApplicationDBContext db) : base(db) 
        {
            _db = db;
            
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(User obj)
        {
            _db.Users.Update(obj);
        }
    }
}
