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
            //display all superheros in a list 
            //.ToList();
            Superheros superheros = new Superheros();
            //List<Heros> Heros = Heros.ToList();//trying to display a list of superheros
            //list the database not only object
            //THOUGHT IT WOULD BE SIMILAR var superheroById = context.Heros.Where(h => h.Id == id).FirstOrDefault();         
            return View(superheros);

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
            //query db by id(pk) so the user can pick which superhero to update/edit
            //var superheroById = context.Heros.Find(id); //2nd way to do it  
            var superheroById = context.Heros.Where(h => h.Id == id).FirstOrDefault();      
            return View(superheroById);//then pass to the view, that one superhero and all of their info
        }

        // POST: Superheros/Edit/5
        [HttpPost]
        public ActionResult Edit(Superheros superhero)
        {
            try
            {
                // TODO: Add update logic here
                //query by id (primary key) again to grab all of that superhero info
                //var superheroById = context.Heros.Find(superhero.Id);

                var superheroByIdFromDb = context.Heros.Where(h => h.Id == superhero.Id).SingleOrDefault(); //dont have to do h.Superheros.Id        
                //then update it
                superheroByIdFromDb.name = superhero.name;
                superheroByIdFromDb.alterEgo = superhero.alterEgo;
                superheroByIdFromDb.primarySuperheroAbility = superhero.primarySuperheroAbility;
                superheroByIdFromDb.secondarySuperHeroAbility = superhero.secondarySuperHeroAbility;
                superheroByIdFromDb.catchPhrase = superhero.catchPhrase;         
                context.SaveChanges(); //or submitOnChanges?           
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
        public ActionResult Delete(int id, Superheros superhero)
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
