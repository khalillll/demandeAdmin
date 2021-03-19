using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DPAContext;

namespace demandeAdmin.Controllers
{
    public class UserController : Controller
    {
        private readonly DPAContextModels context = new DPAContextModels();

        // GET: User
        public ActionResult Index()
        {
            var users = context.Users.Include(u => u.Role);
            return View(users.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            ViewBag.roleId = new SelectList(context.Roles, "id", "name");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,firstName,lastName,email,password,state,roleId")] User user)
        {
            if (ModelState.IsValid)
            {
                user.createdAt = DateTime.Now;
                user.updatedAt = DateTime.Now;
                context.Users.Add(user);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.roleId = new SelectList(context.Roles, "id", "name", user.roleId);
            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.roleId = new SelectList(context.Roles, "id", "name", user.roleId);
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection)
        {
            User user = context.Users.Find(id);
            if (ModelState.IsValid)
            {
               
                user.email = collection["email"];
                user.firstName = collection["firstName"];
                user.lastName = collection["lastName"];
                user.state = byte.Parse(collection["state"]);
                user.roleId = Int32.Parse(collection["roleId"]);
                user.updatedAt = DateTime.Now;

                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.roleId = new SelectList(context.Roles, "id", "name", user.roleId);
            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = context.Users.Find(id);
            context.Users.Remove(user);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
