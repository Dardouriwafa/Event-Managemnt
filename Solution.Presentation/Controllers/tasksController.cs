using Solution.Domain.Entities;
using Solution.Presentation.Models;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{
    public class tasksController : Controller
    {
        ServiceTask tt = new ServiceTask();
        IServiceOrganizer so = new ServiceOrganizer();
        // GET: tasks
        public ActionResult Index()
        {
            List<TaskVM> ts = new List<TaskVM>();
            foreach(tasks t in tt.GetMany())
            {
                ts.Add(new TaskVM() {
                    deadline=t.deadline,
                    description=t.description,
                    id=t.id,
                    idOrganizer=t.idOrganizer,
                    nom=t.nom
                });
            }
            return View(ts);
        }

        // GET: tasks/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var t = tt.GetById(id);
            TaskVM s = new TaskVM()
            {
                deadline = t.deadline,
                description = t.description,
                id = t.id,
                idOrganizer=t.idOrganizer,
                nom=t.nom
            };
            return View(s);
        }

        // GET: tasks/Create
        public ActionResult Create()
        {
            var organizers = so.GetMany();
            ViewBag.ListOrg = new SelectList(organizers, "Id", "prenom");
            return View();
        }

        // POST: tasks/Create
        [HttpPost]
        
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskVM t)
        {
            tasks f = new tasks()
            {
                deadline=t.deadline,
                description=t.description,
               
                idOrganizer=t.idOrganizer,
                nom=t.nom,
                
            };
            tt.Add(f);
            tt.Commit();

            return RedirectToAction("Index");
        }


        // GET: tasks/Edit/5
        public ActionResult Edit(int id)
        {
            tasks aa = tt.GetById(id);
            TaskVM tm = new TaskVM();

            tm.nom = aa.nom;
            tm.deadline = aa.deadline;
            tm.description = aa.description;
            return View(tm);
           
        }

        // POST: tasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaskVM tm)
        {
            try
            {
                tasks aa = tt.GetById(id);
                aa.nom = tm.nom;
                aa.description = tm.description;
                aa.deadline = tm.deadline;

                tt.Update(aa);
                tt.Commit();
                return RedirectToAction("index");

            }
            catch (Exception ex)
            {
                return View(tm);
            }
           
        }

        // GET: tasks/Delete/5
        public ActionResult Delete()
        {
          
            return View();
        }

        // POST: tasks/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            tasks task = tt.GetById((int)id);
            tt.Delete(task);
            tt.Commit();
            return RedirectToAction("Index");
        }
    }
}
