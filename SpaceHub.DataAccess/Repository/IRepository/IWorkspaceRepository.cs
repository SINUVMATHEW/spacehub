using SpaceHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceHub.DataAccess.Repository.IRepository
{
    public interface IWorkspaceRepository :IRepository<Workspace>
    {
        void Update(Workspace workspace);
        void Save();
        
    }
}
