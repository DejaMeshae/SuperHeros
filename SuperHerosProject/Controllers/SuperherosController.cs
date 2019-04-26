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
        ApplicationDbContext db;

        //constructor
        public SuperherosController()
        {
            db = new ApplicationDbContext();
        }


        // GET: Superheros**method/actions
        public ActionResult Index()
        {
            return View();

    }

    // GET: Superheros/Details/5
    public ActionResult Details()
        {
            //var superheroList = db.Heros.Where(h => h.Id == id).FirstOrDefault(); //?Only returns 1
            Superheros superheros = new Superheros();

            db.Heros.Where(s => s.name == superheros.name);
            db.Heros.Where(s => s.alterEgo == superheros.alterEgo);
            db.Heros.Where(s => s.primarySuperheroAbility == superheros.primarySuperheroAbility);
            db.Heros.Where(s => s.secondarySuperHeroAbility == superheros.secondarySuperHeroAbility);
            db.Heros.Where(s => s.catchPhrase == superheros.catchPhrase);
            return View(superheros);
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
        public ActionResult Edit(Superheros superhero) //DONE maybe?
        {
            try
            {
                //query by id (primary key) again to grab all of that superhero info
                db.Heros.Where(h => h.Id == superhero.Id).SingleOrDefault();
                
                //then update it
                db.Heros.Where(s => s.name == superhero.name);
                db.Heros.Where(s => s.alterEgo == superhero.alterEgo);
                db.Heros.Where(s => s.primarySuperheroAbility == superhero.primarySuperheroAbility);
                db.Heros.Where(s => s.secondarySuperHeroAbility == superhero.secondarySuperHeroAbility);
                db.Heros.Where(s => s.catchPhrase == superhero.catchPhrase);        
                db.SaveChanges(); //or submitOnChanges?           
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
            var superheroById = db.Heros.Where(h => h.Id == id).FirstOrDefault();
            return View();
        }

        // POST: Superheros/Delete/5
        [HttpPost]
        public ActionResult Delete(Superheros superhero)
        {
            try
            {
                // TODO: Add delete logic here
                db.Heros.Where(s => s.name == superhero.name);
                db.Heros.Where(s => s.alterEgo == superhero.alterEgo);
                db.Heros.Where(s => s.primarySuperheroAbility == superhero.primarySuperheroAbility);
                db.Heros.Where(s => s.secondarySuperHeroAbility == superhero.secondarySuperHeroAbility);
                db.Heros.Where(s => s.catchPhrase == superhero.catchPhrase);
                db.SaveChanges(); //or submitOnChanges?           
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
