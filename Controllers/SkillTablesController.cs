using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DRD.Data;
using DRD.Models;

namespace DRD.Controllers
{
    public class SkillTablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SkillTablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SkillTables
        public async Task<IActionResult> Index()
        {
            return View(await _context.SkillTable.ToListAsync());
        }

        // GET: SkillTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillTable = await _context.SkillTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skillTable == null)
            {
                return NotFound();
            }

            return View(skillTable);
        }

        // GET: SkillTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SkillTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rank,Dangerousness,Sogt,Medioum,Hard,VeryHard")] SkillTable skillTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skillTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skillTable);
        }

        // GET: SkillTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillTable = await _context.SkillTable.FindAsync(id);
            if (skillTable == null)
            {
                return NotFound();
            }
            return View(skillTable);
        }

        // POST: SkillTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Rank,Dangerousness,Sogt,Medioum,Hard,VeryHard")] SkillTable skillTable)
        {
            if (id != skillTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skillTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillTableExists(skillTable.Id))
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
            return View(skillTable);
        }

        // GET: SkillTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillTable = await _context.SkillTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skillTable == null)
            {
                return NotFound();
            }

            return View(skillTable);
        }

        // POST: SkillTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skillTable = await _context.SkillTable.FindAsync(id);
            if (skillTable != null)
            {
                _context.SkillTable.Remove(skillTable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkillTableExists(int id)
        {
            return _context.SkillTable.Any(e => e.Id == id);
        }
    }
}
