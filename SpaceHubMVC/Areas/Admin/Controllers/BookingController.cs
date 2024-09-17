using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SpaceHub.DataAccess.Data;
using SpaceHub.DataAccess.Repository;
using SpaceHub.DataAccess.Repository.IRepository;
using SpaceHub.Models;
using SpaceHub.Models.ViewModel;

namespace SpaceHubMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookingController : Controller
    {
        private readonly IBookingRepository _BookingRepository;
        private readonly IUserRepository _UserRepository;
        private readonly IAppUserRepository _AppUserRepository;
        private readonly IWorkspaceRepository _WorkspaceRepository;
        public BookingController(IBookingRepository db, IUserRepository Userdb, IWorkspaceRepository Workspacedb, IAppUserRepository appUserdb)
        {
            _BookingRepository = db;
            _UserRepository = Userdb;
            _WorkspaceRepository = Workspacedb;
            _AppUserRepository = appUserdb;
        }
        public IActionResult Index()
        {
            List<Booking> objBookingList = _BookingRepository.GetAll(includeProperties:"User").ToList();

            return View(objBookingList);
        }
        public IActionResult Upsert(int? id)
        {

            BookingVM bookingVM = new()
            {
                WorkspaceList = _WorkspaceRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.SeatNo.ToString(),
                    Value = u.Id.ToString()
                }),
                UserList = _AppUserRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.UserName,
                    Value = u.Id.ToString()
                }),
                Booking = new Booking()

            };
            if (id == null|| id==0)
            { 
                return View(bookingVM); 
            }
            else
            {
                bookingVM.Booking=_BookingRepository.Get(u=>u.Id==id);
                return View(bookingVM);
            }
            
        }

        [HttpPost]
        public IActionResult Upsert(BookingVM obj)
        {
            if (ModelState.IsValid)
            {
               
                    if(obj.Booking.Id==0)
                {
                    _BookingRepository.Add(obj.Booking);
                    TempData["success"] = "Booking made Successfully";
                }
                else
                {
                    _BookingRepository.Update(obj.Booking);
                    TempData["success"] = "Booking updated Successfully";
                }

                _BookingRepository.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        
       /* public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Booking? currentBooking = _BookingRepository.Get(u => u.Id == id);
            if (currentBooking == null)
            {
                return NotFound();
            }
            return View(currentBooking);

        }*/

        
        #region

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Booking> objBookingList = _BookingRepository.GetAll(includeProperties: "User").ToList();

            return Json(new { data = objBookingList });

        }

       
        public IActionResult Delete(int? id)
        {
            var DeleteObj = _BookingRepository.Get(u => u.Id == id);
            if (DeleteObj == null)
            {
                return Json(new {Success = false,Message="Delete failed"});

            }
            _BookingRepository.Remove(DeleteObj);
            _BookingRepository.Save();
            return Json(new { Success = false, Message = "Delete Sucess" });

        }




        #endregion
    }
}
