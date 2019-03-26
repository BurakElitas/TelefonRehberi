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
    public class DepartmentController : Controller
    {
        ManagerDepartment managerDepartment = new ManagerDepartment();

        [Auth]
        public ActionResult Index()
        {
            return View(managerDepartment.List());
        }

        [Auth]
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Auth]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                managerDepartment.Insert(department);
                return RedirectToAction("Index");
            }

            return View(department);
        }

        [Auth]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = managerDepartment.Find(x => x.Id == id.Value);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

      
        [HttpPost]
        [Auth]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                Department d= managerDepartment.Find(x => x.Id == department.Id);
                d.Name = department.Name;
                managerDepartment.Update(d);
               
                return RedirectToAction("Index");
            }
            return View(department);
        }

        
      

        [HttpPost]
        [Auth]
        public ActionResult Delete(int id)
        {
            BusinessLayerResult<Department> res = managerDepartment.Delete(id);

            if (res.Errors.Count > 0)
            {

                return Json(new { result = false, error = res.Errors });
            }

            return Json(new { result = true });
        }

        
    }
}
