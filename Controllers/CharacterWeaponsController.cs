using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DnDV4.Data;
using DnDV4.Models;
using System.Diagnostics;
using Microsoft.IdentityModel.Tokens;

namespace DnDV4.Controllers
{
    public class CharacterWeaponsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CharacterWeaponsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CharacterWeapons
        public async Task<IActionResult> Index(int? CharacterId)
        {
            if(CharacterId == null)
            {
                return NotFound();
            }


            var applicationDbContext = _context.CharacterWeapon
           .Include(c => c.Character)
           .Include(c => c.Weapon)
           .Where(c => c.CharacterID == CharacterId);

            ViewData["CharacterId"] = CharacterId;
            
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: CharacterWeapons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterWeapon = await _context.CharacterWeapon
                .Include(c => c.Character)
                .Include(c => c.Weapon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (characterWeapon == null)
            {
                return NotFound();
            }

            return View(characterWeapon);
        }



        // GET: CharacterWeapons/Create
        public IActionResult Create(int? CharacterId)
        {
            if(CharacterId == null)
            {
                return NotFound();
            }

            
           
            ViewData["WeaponId"] = new SelectList(_context.Weapon, "Id", "NameWeapon");
            return View();
        }

        // POST: CharacterWeapons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CharacterID,WeaponId")] CharacterWeapon characterWeapon)
        {
            var characterValue = _context.Character
             .Where(x => x.Id == characterWeapon.CharacterID).First();

            var weaponValue = _context.Weapon
            .Where(x => x.Id == characterWeapon.WeaponId).First();

            if (ModelState.IsValid)
            {

                //characterWeapon.AtackNr   = FightValue(); //vyhledat v databazich a doplnit do metody
                characterWeapon.AtackNr = characterWeapon.FightValue(characterValue.Strength_current,characterValue.Agility_current,
                    weaponValue.SZ);

                characterWeapon.DemageNr = characterWeapon.FightValue(characterValue.Strength_current,
                    weaponValue.UT);

                characterWeapon.DefenseNr = characterWeapon.FightValue(characterValue.Agility_current,
                    weaponValue.OZ);


                _context.Add(characterWeapon);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index",new { CharacterId = characterWeapon.CharacterID });
            }
           
            ViewData["WeaponId"] = new SelectList(_context.Weapon, "Id", "NameWeapon", characterWeapon.WeaponId);
            return View(characterWeapon);
        }







        // GET: CharacterWeapons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterWeapon = await _context.CharacterWeapon.FindAsync(id);
            if (characterWeapon == null)
            {
                return NotFound();
            }
            ViewData["CharacterID"] = new SelectList(_context.Character, "Id", "Id", characterWeapon.CharacterID);
            ViewData["WeaponId"] = new SelectList(_context.Weapon, "Id", "NameWeapon", characterWeapon.WeaponId);
            return View(characterWeapon);
        }

        // POST: CharacterWeapons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CharacterID,WeaponId")] CharacterWeapon characterWeapon)
        {
            if (id != characterWeapon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(characterWeapon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterWeaponExists(characterWeapon.Id))
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
            ViewData["CharacterID"] = new SelectList(_context.Character, "Id", "Id", characterWeapon.CharacterID);
            ViewData["WeaponId"] = new SelectList(_context.Weapon, "Id", "NameWeapon", characterWeapon.WeaponId);
            return View(characterWeapon);
        }

        // GET: CharacterWeapons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterWeapon = await _context.CharacterWeapon
                .Include(c => c.Character)
                .Include(c => c.Weapon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (characterWeapon == null)
            {
                return NotFound();
            }

            return View(characterWeapon);
        }

        // POST: CharacterWeapons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var characterWeapon = await _context.CharacterWeapon.FindAsync(id);
            if (characterWeapon != null)
            {
                _context.CharacterWeapon.Remove(characterWeapon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterWeaponExists(int id)
        {
            return _context.CharacterWeapon.Any(e => e.Id == id);
        }
    }
}
