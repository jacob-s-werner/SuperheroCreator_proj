using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperheroCreator_proj.Data;
using SuperheroCreator_proj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperheroCreator_proj.Controllers
{
    public class SuperheroesController : Controller
    {
        private ApplicationDbContext _context;
        public SuperheroesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: SuperheroesController
        public ActionResult Index()
        {
            return View(_context.Superheroes);
        }

        // GET: SuperheroesController/Details/5
        public ActionResult Details(int id)
        {
            return View(_context.Superheroes.Where(superhero => superhero.Id == id).Select(superhero => superhero).ToList()[0]);
        }

        // GET: SuperheroesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperheroesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                _context.Superheroes.Add(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperheroesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.Superheroes.Where(superhero => superhero.Id == id).Select(superhero => superhero).ToList()[0]);
        }

        // POST: SuperheroesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Superhero superhero)
        {
            try
            {
                _context.Superheroes.Update(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperheroesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_context.Superheroes.Where(superhero => superhero.Id == id).Select(superhero => superhero).ToList()[0]);

        }

        // POST: SuperheroesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Superhero superhero)
        {
            try
            {
                _context.Superheroes.Remove(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
