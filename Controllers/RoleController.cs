using DPAContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demandeAdmin.Controllers
{
    public class RoleController : Controller
    {
        private readonly DPAContextModels context = new DPAContextModels();

        // GET: Role
        public ActionResult Index()
        {
            var roles = context.Roles.ToList();
            return View(roles);
        }

        // GET: Role/Details/5
        public ActionResult Details(int id)
        {
            var role = context.Roles.Find(id);
            return View(role);
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
           
                if (ModelState.IsValid)
                {
                    var role = new Role();
                    role.name = collection["name"];
                    role.description = collection["description"];
                    role.createdAt = DateTime.Now;
                    role.updatedAt = DateTime.Now;
                    context.Roles.Add(role);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View();
        }

        // GET: Role/Edit/5
        public ActionResult Edit(int id)
        {
            var role = context.Roles.Find(id);
            return View(role);
        }

        // POST: Role/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                var role = context.Roles.Find(id);
                // TODO: Add update logic here
                role.name = collection["name"];
                role.description = collection["description"];
                role.updatedAt = DateTime.Now;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View();
            
        }

        // GET: Role/Delete/5
        public ActionResult Delete(int id)
        {
            var role = context.Roles.Find(id);
            return View(role);
        }

        // POST: Role/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var role = context.Roles.Find(id);
                context.Roles.Remove(role);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
