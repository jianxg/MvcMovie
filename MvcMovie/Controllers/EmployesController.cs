﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class EmployesController : Controller
    {
        private readonly MvcMovieContext _context;

        public EmployesController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Employes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employes.ToListAsync());
        }

        // GET: Employes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employes = await _context.Employes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employes == null)
            {
                return NotFound();
            }

            return View(employes);
        }

        // GET: Employes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Employes employes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employes);
        }

        // GET: Employes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employes = await _context.Employes.FindAsync(id);
            if (employes == null)
            {
                return NotFound();
            }
            return View(employes);
        }

        // POST: Employes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Employes employes)
        {
            if (id != employes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployesExists(employes.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employes);
        }

        // GET: Employes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employes = await _context.Employes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employes == null)
            {
                return NotFound();
            }

            return View(employes);
        }

        // POST: Employes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employes = await _context.Employes.FindAsync(id);
            _context.Employes.Remove(employes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployesExists(int id)
        {
            return _context.Employes.Any(e => e.Id == id);
        }
    }
}
