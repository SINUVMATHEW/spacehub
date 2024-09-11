using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpaceHub.DataAccess.Data;
using SpaceHub.DataAccess.Repository.IRepository;
using SpaceHub.Models;

namespace SpaceHub.DataAccess.Repository
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        private  ApplicationDBContext _db;
        public BookingRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;          
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Booking obj)
        {
            _db.Update(obj);
        }
       
    }
}
