using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TelefonRehberiBusinessLayer;
using TelefonRehberiEntities.Models;
using TelefonRehberiUI.Filters;

namespace TelefonRehberiUI.Controllers
{
    public class HomeController : Controller
    {
        ManagerPersonnel managerPersonnel = new ManagerPersonnel();
        ManagerDepartment managerDepartment = new ManagerDepartment();

        public ActionResult Index()
        {
            var personnels = managerPersonnel.ListQueryable().Include(p => p.Department);
            return View(personnels.ToList());
        }

        //public ActionResult Login()
        //{

        //}

        public PartialViewResult Details(int id)
        {
           
            Personnel personnel = managerPersonnel.Find(x=>x.Id==id);
           
            return PartialView("_PartialPersonnelDetails",personnel);
        }

        [Auth]
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(managerDepartment.List(), "Id", "Name");
            ViewBag.ManagerId = managerPersonnel.List();
            return View();
        }

        [Auth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Personnel personnel)
        {
            if (ModelState.IsValid)
            {
                managerPersonnel.Insert(personnel);
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(managerDepartment.List(), "Id", "Name", personnel.DepartmentId);
            ViewBag.ManagerId = managerPersonnel.List();
            return View(personnel);
        }

        [Auth]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personnel personnel = managerPersonnel.Find(x=>x.Id==id.Value);
            if (personnel == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(managerDepartment.List(), "Id", "Name",personnel.DepartmentId);
            ViewBag.ManagerId = managerPersonnel.List();

            
            return View(personnel);
        }

        [Auth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Personnel personnel)
        {
            if (ModelState.IsValid)
            {
                Personnel p = managerPersonnel.Find(x => x.Id == personnel.Id);
                p.Name = personnel.Name;
                p.Surname = personnel.Surname;
                p.Phone = personnel.Phone;
               
                p.ManagerId = personnel.ManagerId;
                p.DepartmentId = personnel.DepartmentId;

                managerPersonnel.Update(p);
                
                return RedirectToAction("Index");
               
               
            }
            ViewBag.DepartmentId = new SelectList(managerDepartment.List(), "Id", "Name", personnel.DepartmentId);
            ViewBag.ManagerId = managerPersonnel.List();
            return View(personnel);
        }


        [Auth]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            BusinessLayerResult<Personnel> res = managerPersonnel.Delete(id);

            if(res.Errors.Count>0)
            {

                return Json(new { result = false,error=res.Errors});
            }

            return Json(new { result = true });
        }

      
    }
}
