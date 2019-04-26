using SuperHerosProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHerosProject.Controllers
{  
    public class SuperherosController : Controller
    {   
        ApplicationDbContext db;
      
        public SuperherosController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Superheros
        public ActionResult Index() 
        {
            //display list of superheros
            var listOfSuperHeros = db.Heros.ToList();
            return View(listOfSuperHeros);
        }

    // GET: Superheros/Details/5
    public ActionResult Details(int id) //READ. DONE maybe?
        {
            //display all names but be able to click on one and display all of their properties 
            var displaySuperHeros = db.Heros.Where(h => h.Id == id);  
            return View(displaySuperHeros);
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
                db.Heros.Add(superheros); //adds the superheros object to the hereos table in the database
                db.SaveChanges();
                return RedirectToAction("Index"); //After i create a superhero go to index page that displays list of superheros when i finish that logic
            }
            catch
            {
                return View();
            }
        }

        // GET: Superheros/Edit/5
        public ActionResult Edit(int id)//DONE maybe?
        {
            //query db by id(pk) so the user can pick which superhero to update/edit. var superheroById = context.Heros.Find(id); 2nd way to do it  

            var superheroToEdit = db.Heros.Where(h => h.Id == id).FirstOrDefault();      
            return View(superheroToEdit);//then pass to the view, that one superhero and all of their info
        }


        // POST: Superheros/Edit/5
        [HttpPost]
        public ActionResult Edit(Superheros superheros) 
        {
            try
            {
                //query by id (primary key) again to grab all of that superhero info
                var superheroToEdit = db.Heros.Where(h => h.Id == superheros.Id).SingleOrDefault();

                superheroToEdit.name = superheros.name;
                superheroToEdit.alterEgo = superheros.alterEgo;
                superheroToEdit.primarySuperheroAbility = superheros.primarySuperheroAbility;
                superheroToEdit.secondarySuperHeroAbility = superheros.secondarySuperHeroAbility;
                superheroToEdit.catchPhrase = superheros.catchPhrase;
                db.SaveChanges();          
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
            var superheroToDelete = db.Heros.Where(h => h.Id == id).FirstOrDefault();
            return View(superheroToDelete);
        }

        // POST: Superheros/Delete/5
        [HttpPost]
        public ActionResult Delete(Superheros superheros)
        {
            try
            {
                var superheroToDelete = db.Heros.Where(h => h.Id == superheros.Id).SingleOrDefault();

                db.Heros.Remove(superheroToDelete); //adds the superheros object to the hereos table in the database
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Read()
        {
            Superheros superheros = new Superheros();

            db.Heros.Where(s => s.name == superheros.name);
            db.Heros.Where(s => s.alterEgo == superheros.alterEgo);
            db.Heros.Where(s => s.primarySuperheroAbility == superheros.primarySuperheroAbility);
            db.Heros.Where(s => s.secondarySuperHeroAbility == superheros.secondarySuperHeroAbility);
            db.Heros.Where(s => s.catchPhrase == superheros.catchPhrase);
            return View();
        }


    }
}
