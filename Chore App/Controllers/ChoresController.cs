using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chore_App.DB;
using Chore_App.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Chore_App.Controllers
{
    public class ChoresController : Controller
    {
        private readonly ChoresContext context;

        public ChoresController(ChoresContext context)
        {
            this.context = context;
        }

        //GET list of chores
        public async Task<ActionResult> Index()
        {
            IQueryable<ChoresList> chores = from i in context.Chorelist orderby i.Id select i;

            List<ChoresList> chorelist = await chores.ToListAsync();

            return View(chorelist);
        }

        //GET /chores/create
        public IActionResult Create() => View();

        //POST /chores/create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ChoresList item)
        {
            //check to see if model is valid.
            if(ModelState.IsValid)
            {
                context.Add(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "Chore has been added to list!";
                //send the back to home page if successfully added to list.
                return RedirectToAction("Index");
            }
            return View(item);
        }
        //PUT /chores/edit/{id}
        public async Task<ActionResult> Edit(int id)
        {
            ChoresList item = await context.Chorelist.FindAsync(id);
            if(item == null)
            {
                return NotFound("Chore not found");
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ChoresList item)
        {
            //check to see if model is valid.
            if (ModelState.IsValid)
            {
                context.Update(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "Chore has been updated!";
                //send the back to home page if successfully added to list.
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public async Task<ActionResult> Delete(int id)
        {
            ChoresList item = await context.Chorelist.FindAsync(id);
            if (item == null)
            {
                TempData["Error"] = "The chore does not exist!";
            }
            else
            {
                context.Chorelist.Remove(item);
                await context.SaveChangesAsync(); 
                TempData["Success"] = "Chore has been deleted!";
            }
            return RedirectToAction("Index");
        }

        //DELETE
       
    }
}
