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
using TelefonRehberiUI.Models;

namespace TelefonRehberiUI.Controllers
{
    public class AdminController : Controller
    {
        ManagerAdmin managerAdmin = new ManagerAdmin();

        [Auth]
        public ActionResult Index()
        {
            return View(managerAdmin.List());
        }

        [Auth]
        public ActionResult Create()
        {
            return View();
        }

        [Auth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Admin admin)
        {
            if (ModelState.IsValid)
            {
                BusinessLayerResult<Admin> res = managerAdmin.Insert(admin);
                if(res.Errors.Count>0)
                {
                    foreach (string item in res.Errors)
                    {
                        ModelState.AddModelError("", item);
                    }
                    
                    return View(admin);
                }
                
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        [Auth]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = managerAdmin.Find(x=>x.Id==id.Value);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        [HttpPost]
        [Auth]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Admin admin)
        {
            if (ModelState.IsValid)
            {
                Admin a = managerAdmin.Find(x => x.Id == admin.Id);
                a.UserName = admin.UserName;
                a.Password = admin.Password;
                managerAdmin.Update(a);
                return RedirectToAction("Index");
            }
            return View(admin);
        }

      

        [HttpPost]
        [Auth]
        public ActionResult Delete(int id)
        {
            Admin a = managerAdmin.Find(x => x.Id == id);
            if (managerAdmin.Delete(a) > 0)
            {
                return Json(new { result = true });
            }
            else
                return Json(new { result = false });
            
        }

        public ActionResult Login(Admin admin)
        {
            if(ModelState.IsValid)
            {
                BusinessLayerResult<Admin> res = managerAdmin.Login(admin);
                if(res.Errors.Count>0)
                {
                    foreach (string item in res.Errors)
                    {
                        ModelState.AddModelError("", item);
                    }
                    return View(admin);
                }
                else
                {
                    CurrentSession.Set<Admin>("Admin",res.result);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(admin);
        }
        public ActionResult Singout()
        {
            CurrentSession.Remove("Admin");
            return RedirectToAction("Index", "Home");
        }

       
    }
}
