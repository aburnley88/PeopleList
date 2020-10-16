using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTA422Exercise.Data.Data.Models;
using ISTA422Exercise.Data.Repository.IRepository;
using ISTA422Exercise.Models;
using Microsoft.AspNetCore.Mvc;

namespace ISTA422Exercise.Controllers
{
    public class PersonController : Controller
    {
        //create a private readonly IUnitOfWork
        private readonly IUnitOfWork _unitOfWork;
        public PersonController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            Person person = new Person();
            if (id == null)
            {
                //this is for create
                return View(person);
            }
            //this is for edit
            person = _unitOfWork.People.Get(id.GetValueOrDefault());
            if (person == null)
            {
                return NotFound();
            }
            return View(person);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Person person)
        {
            if (ModelState.IsValid)
            {
                if (person.Id == 0)
                {
                    _unitOfWork.People.Add(person);

                }
                else
                {
                    _unitOfWork.People.Update(person);

                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.People.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.People.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.People.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}

