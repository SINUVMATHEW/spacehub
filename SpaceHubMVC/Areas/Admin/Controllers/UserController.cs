using Microsoft.AspNetCore.Mvc;
using SpaceHub.DataAccess.Data;
using SpaceHub.DataAccess.Repository.IRepository;
using SpaceHub.Models;


namespace SpaceHubMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserRepository _UserRepository;
        public UserController(IUserRepository db)
        {
            _UserRepository = db;

        }
        public IActionResult Index()
        {
            List<User> objUsersList = _UserRepository.GetAll().ToList();
            return View(objUsersList);

        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(User obj)
        {
            if (ModelState.IsValid)
            {
                _UserRepository.Add(obj);
                _UserRepository.Save();
                TempData["success"] = "User Created Successfully";
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            User? editingUser = _UserRepository.Get(u => u.Id == id);
            if (editingUser == null)
            {
                return NotFound();
            }
            return View(editingUser);

        }

        [HttpPost]
        public IActionResult Edit(User obj)
        {
            if (ModelState.IsValid)
            {
                _UserRepository.Update(obj);
                _UserRepository.Save();
                TempData["success"] = "User Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            User? currentUser = _UserRepository.Get(u => u.Id == id);
            if (currentUser == null)
            {
                return NotFound();
            }
            return View(currentUser);

        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeletePOST(int? id)
        {
            User? obj = _UserRepository.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();

            }
            _UserRepository.Remove(obj);
            _UserRepository.Save();
            TempData["success"] = "User Deleted Successfully";
            return RedirectToAction("Index");

        }
    }
}
