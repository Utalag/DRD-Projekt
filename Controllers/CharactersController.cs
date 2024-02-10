using DnDV4.Data;
using DnDV4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DnDV4.Controllers
{
    public class CharactersController(ApplicationDbContext context) : Controller
    {
        //---METODY--
        public int AtributValue(int rasaAtribut,int atributProfession,int raceCorrection)
        {
            if(atributProfession.Equals(null))
                atributProfession = 0;
            if(rasaAtribut.Equals(null))
                rasaAtribut = 0;
            if(raceCorrection.Equals(null))
                rasaAtribut = 0;

            return (rasaAtribut < atributProfession + raceCorrection) ? atributProfession + raceCorrection : rasaAtribut;
        }
        //----------

        // GET: výpis všech postav
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = context.Character.Include(c => c.Race).Include(c => c.Profession);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: vyber Rasy
        public async Task<IActionResult> IndexRasy()
        {
            return View(await context.Races.ToListAsync());
        }

        // GET: vyber Povolani
        public async Task<IActionResult> IndexPovolani(int? id)
        {
            ViewBag.idRasy = id; // pro vložení do dalšího parametru
            return View(await context.Profession.ToListAsync());
        }

        // GET: Create
        public IActionResult Create(int idRace,int idProfession)
        {
            var profession = context.Profession.Find(idProfession); // Find -> vybírá jeden záznam podle primárního klíče
            var race = context.Races.Find(idRace);
            if(race == null)
            {
                return NotFound();
            }
            if(profession == null)
            {
                return NotFound();
            }

            Character character = new Character()
            {
                RaceId = idRace,
                ProfessionId = idProfession,
                Race = race,
                Profession = profession,
                Strength = AtributValue(race.Strength,profession.Strength,race.Strength_Corection),
                Agility = AtributValue(race.Agility,profession.Agility,race.Agility_Corection),
                Constitution = AtributValue(race.Constitution,profession.Constitution,race.Constitution_Corection),
                Intelligence = AtributValue(race.Intelligence,profession.Intelligence,race.Intelligence_Correction),
                Charisma = AtributValue(race.Charisma,profession.Charisma,race.Charisma_Correction),
                Strength_Max = AtributValue(race.Strength_Max,profession.Strength_Max,race.Strength_Corection),
                Agility_Max = AtributValue(race.Agility_Max,profession.Agility_Max,race.Agility_Corection),
                Constitution_Max = AtributValue(race.Constitution_Max,profession.Constitution_Max,race.Constitution_Corection),
                Intelligence_Max = AtributValue(race.Intelligence_Max,profession.Intelligence_Max,race.Intelligence_Correction),
                Charisma_Max = AtributValue(race.Charisma_Max,profession.Charisma_Max,race.Charisma_Correction)
            };

            int AtributValue(int rasaAtribut,int atributProfession,int raceCorrection)
            {
                if(atributProfession.Equals(null))
                    atributProfession = 0;
                if(rasaAtribut.Equals(null))
                    rasaAtribut = 0;
                if(raceCorrection.Equals(null))
                    rasaAtribut = 0;

                return (rasaAtribut < atributProfession + raceCorrection) ? atributProfession + raceCorrection : rasaAtribut;
            }

            return View(character);
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProfessionId,RaceId,CharacterName,CharacterLevel,CharacterOrigin,Strength_current,Agility_current,Constitution_current,Intelligence_current,Charisma_current")] Character character)
        {
            if(ModelState.IsValid)
            {
                var profession = context.Profession.Find(character.ProfessionId); // Finf -> vybírá jedne záznam podle primárního klíče
                var race = context.Races.Find(character.RaceId);
                if(race == null)
                {
                    return NotFound();
                }
                if(profession == null)
                {
                    return NotFound();
                }
                // min hodnoty
                character.Strength = AtributValue(race.Strength,profession.Strength,race.Strength_Corection);
                character.Agility = AtributValue(race.Agility,profession.Agility,race.Agility_Corection);
                character.Constitution = AtributValue(race.Constitution,profession.Constitution,race.Constitution_Corection);
                character.Intelligence = AtributValue(race.Intelligence,profession.Intelligence,race.Intelligence_Correction);
                character.Charisma = AtributValue(race.Charisma,profession.Charisma,race.Charisma_Correction);
                // max hodnoty
                character.Strength_Max = AtributValue(race.Strength_Max,profession.Strength_Max,race.Strength_Corection);
                character.Agility_Max = AtributValue(race.Agility_Max,profession.Agility_Max,race.Agility_Corection);
                character.Constitution_Max = AtributValue(race.Constitution_Max,profession.Constitution_Max,race.Constitution_Corection);
                character.Intelligence_Max = AtributValue(race.Intelligence_Max,profession.Intelligence_Max,race.Intelligence_Correction);
                character.Charisma_Max = AtributValue(race.Charisma_Max,profession.Charisma_Max,race.Charisma_Correction);
                // Hp
                character.Hp = profession.Hp + profession.HpBonus + character.Constitution_bonus;
                //pohyblivost
                character.Mobility = race.Mobility + character.Strength_bonus * 2 + character.Agility_bonus;

                context.Add(character);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(character);
        }


        // GET: Deník
        public async Task<IActionResult> Denik(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var character = await context.Character
                .Include(c => c.Race)
                .Include(c => c.Profession)
                .Include(c => c.CharacterSkill)
                .Include(c => c.CharacterWeapon)
                .FirstOrDefaultAsync(m => m.Id == id);

            List<CharacterSkill> DangerousnessSkill(AtributEnum atribut)
            {
                return context.CharacterSkill
                        .Include(x => x.Skill)
                        .Where(x => x.CharacterId == id).ToList()
                        .Where(x => x.Atribut == atribut).ToList();
            }
            //--- testovani---
            var xxx = context.CharacterWeapon.Include(x => x.Weapon).Where(x => x.CharacterID == id).ToList();
            foreach(var item in xxx)
            {
                string ccc = item.Weapon.NameWeapon;
                int? sz = item.Weapon.MinGunshot;
                int ut = item.DemageNr;
                int oc = item.DefenseNr;
                int delka = item.Weapon.InitiativeWeapon;
            }
            //-------
            ViewData["WeaponsList"] = context.CharacterWeapon.Where(x => x.CharacterID == id).ToList();
            ViewData["WeaponsFilterClass"] = context.CharacterWeapon.Where(x => x.CharacterID == id).Select(x => x.Weapon.ClassWeapon).OrderBy(x => x).ToList().Distinct();

            ViewData["Dengerousness_Strength"] = DangerousnessSkill(AtributEnum.strength);
            ViewData["Dengerousness_Agility"] = DangerousnessSkill(AtributEnum.agility);
            ViewData["Dengerousness_Constitution"] = DangerousnessSkill(AtributEnum.constitution);
            ViewData["Dengerousness_Intelligence"] = DangerousnessSkill(AtributEnum.intelligence);
            ViewData["Dengerousness_Charisma"] = DangerousnessSkill(AtributEnum.charisma);
            ViewData["Dengerousness_Mobility"] = DangerousnessSkill(AtributEnum.mobility);


            if(character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // GET: Characters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var character = await context.Character.FindAsync(id);
            ViewData["RacePatch"] = context.Races.Where(x => x.Id == character.RaceId).Select(i => i.ImagePath).First();
            if(character == null)
            {
                return NotFound();
            }
            return View(character);
        }

        // POST: Characters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,ProfessionId,RaceId,CharacterName,CharacterLevel,CharacterOrigin,Strength_current,Agility_current,Constitution_current,Intelligence_current,Charisma_current,Strength,Strength_Max,Agility,Agility_Max,Constitution,Constitution_Max,Intelligence,Intelligence_Max,Charisma,Charisma_Max,Mobility,Mobility_Max,Hp")] Character character)
        {


            if(ModelState.IsValid)
            {
                try
                {
                    context.Update(character);
                    context.SaveChanges();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!CharacterExists(character.Id))
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

            return View(character);
        }


        // GET: Characters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var character = await context.Character
                .Include(c => c.Race)
                .Include(c => c.Profession)
                .FirstOrDefaultAsync(m => m.Id == id);
            if(character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var character = await context.Character.FindAsync(id);
            if(character != null)
            {
                context.Character.Remove(character);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(int id)
        {
            return context.Character.Any(e => e.Id == id);
        }
    }
}
