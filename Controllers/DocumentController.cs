using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DPAContext;

namespace demandeAdmin.Controllers
{
    public class DocumentController : Controller
    {
        private readonly DPAContextModels context = new DPAContextModels();
        // GET: Document
        public ActionResult Index()
        {
            var documents = context.Documents.ToList();
            return View(documents);
        }

        // GET: Document/Details/5
        public ActionResult Details(int id)
        {
            var document = context.Documents.Find(id);
            return View(document);
        }

        // GET: Document/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Document/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
           
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var document = new Document();
                    document.type = collection["type"];
                    document.description = collection["description"];
                    document.state = collection["state"];
                    document.createdAt = DateTime.Now;
                    document.updatedAt = DateTime.Now;
                    context.Documents.Add(document);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
        }

        // GET: Document/Edit/5
        public ActionResult Edit(int id)
        {
            var document = context.Documents.Find(id);
            return View(document);
        }

        // POST: Document/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var document = context.Documents.Find(id);
                document.type = collection["type"];
                document.description = collection["description"];
                document.state = collection["state"];
                document.updatedAt = DateTime.Now;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Document/Delete/5
        public ActionResult Delete(int id)
        {
            var document = context.Documents.Find(id);
            return View(document);
        }

        // POST: Document/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var document = context.Documents.Find(id);
                context.Documents.Remove(document);
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
