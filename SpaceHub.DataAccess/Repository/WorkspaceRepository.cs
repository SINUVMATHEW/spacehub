using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceHub.DataAccess.Data;
using SpaceHub.DataAccess.Repository.IRepository;
using SpaceHub.Models;

namespace SpaceHub.DataAccess.Repository
{
    public class WorkspaceRepository : Repository<Workspace>, IWorkspaceRepository
    {
        private  ApplicationDBContext _db;
        public WorkspaceRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
           
        }

        public void Save()
        {
            _db.SaveChanges();


        }

        public void Update(Workspace obj)
        {
            _db.Update(obj);
        }
    }
}
