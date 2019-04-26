using SuperHerosProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHerosProject.Controllers
{   //think of these as class
    public class SuperherosController : Controller
    {   //member variable
        ApplicationDbContext context;
        //constructor
        public SuperherosController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Superheros**method/actions
        public ActionResult Index()
        {
            return View(); 
        }

        // GET: Superheros/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Superheros/Create
        public ActionResult Create()
        {
            Superheros superheros = new Superheros(); 
            return View(superheros);
        }

        // POST: Superheros/Create
        [HttpPost]
        public ActionResult Create(Superheros superheros)
        {
            try
            {
                // TODO: Add insert logic here that add this object to the database
                context.Heros.Add(superheros); //adds the superheros object to the hereos table in the database
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superheros/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Superheros/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superheros/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Superheros/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
