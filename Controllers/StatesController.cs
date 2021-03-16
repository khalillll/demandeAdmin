using DPAContext;
using System;
using System.Linq;
using System.Web.Mvc;

namespace demandeAdmin.Controllers
{
    public class StatesController : Controller
    {
        private readonly DPAContextModels context;
        public StatesController()
        {
            context = new DPAContextModels();
        }
        // GET: States
        public ActionResult Index()
        {
            var states = context.States.ToList();
            return View(states);
        }

        // GET: States/Details/5
        public ActionResult Details(int id)
        {
            State state = context.States.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        // GET: States/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: States/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var state = new State
                    {
                        name = collection["name"],
                        description = collection["description"],
                        createdAt = DateTime.Now,
                        updatedAt = DateTime.Now
                    };
                    context.States.Add(state);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
           
                return View();
        }

        // GET: States/Edit/5
        public ActionResult Edit(int id)
        {
            State state = context.States.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        // POST: States/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                var state = context.States.Find(id);

                state.name = collection["name"];
                state.description = collection["description"];
                //state.createdAt = Convert.ToDateTime(collection["createdAt"]);
                state.updatedAt = DateTime.Now;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: States/Delete/5
        public ActionResult Delete(int id)
        {
            State state = context.States.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        // POST: States/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            State state = context.States.Find(id);
            context.States.Remove(state);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
