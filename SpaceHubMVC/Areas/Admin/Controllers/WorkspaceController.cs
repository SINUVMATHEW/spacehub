using Microsoft.AspNetCore.Mvc;
using SpaceHub.DataAccess.Data;
using SpaceHub.DataAccess.Repository.IRepository;
using SpaceHub.Models;

namespace SpaceHubMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WorkspaceController : Controller
    {
        private readonly IWorkspaceRepository _WorkspaceRepository;
        public WorkspaceController(IWorkspaceRepository db)
        {
            _WorkspaceRepository = db;
        }
        public IActionResult Index()
        {
            List<Workspace> objWorkspacesList = _WorkspaceRepository.GetAll().ToList();
            return View(objWorkspacesList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Workspace obj)
        {
            if (ModelState.IsValid)
            {
                _WorkspaceRepository.Add(obj);
                _WorkspaceRepository.Save();
                TempData["success"] = "Workspace Created Successfully";
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
            Workspace? editingWorkspace = _WorkspaceRepository.Get(u => u.Id == id);
            if (editingWorkspace == null)
            {
                return NotFound();
            }
            return View(editingWorkspace);

        }

        [HttpPost]
        public IActionResult Edit(Workspace obj)
        {
            if (ModelState.IsValid)
            {
                _WorkspaceRepository.Update(obj);
                _WorkspaceRepository.Save();
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
            Workspace? currentWorkspace = _WorkspaceRepository.Get(u => u.Id == id);
            if (currentWorkspace == null)
            {
                return NotFound();
            }
            return View(currentWorkspace);

        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeletePOST(int? id)
        {
            Workspace? obj = _WorkspaceRepository.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();

            }
            _WorkspaceRepository.Remove(obj);
            _WorkspaceRepository.Save();
            TempData["success"] = "User Deleted Successfully";
            return RedirectToAction("Index");

        }
    }
}
