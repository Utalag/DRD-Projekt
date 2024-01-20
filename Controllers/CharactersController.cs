using DnDV4.Data;
using DnDV4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DnDV4.Controllers
{
    public class CharactersController(ApplicationDbContext context) : Controller
    {






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

            var rasa = context.Races.Find(id);

            // porovnání atributú rasy a povolání
            foreach(var item in context.Profession)
            {
                int SilProfMin = item.Strength + rasa.Strength_Corection;
                int ObrProfMin = item.Agility + rasa.Agility_Corection;
                int OdolProfMin = item.Constitution + rasa.Constitution_Corection;
                int IntProfMin = item.Intelligence + rasa.Intelligence_Correction;
                int ChProfMin = item.Charisma + rasa.Charisma_Correction;

                item.Strength = (rasa.Strength < SilProfMin) ? SilProfMin : rasa.Strength;
                item.Agility = (rasa.Agility < ObrProfMin) ? ObrProfMin : rasa.Agility;
                item.Constitution = (rasa.Constitution < OdolProfMin) ? OdolProfMin : rasa.Constitution;
                item.Intelligence = (rasa.Intelligence < IntProfMin) ? IntProfMin : rasa.Intelligence;
                item.Charisma = (rasa.Charisma < ChProfMin) ? ChProfMin : rasa.Charisma;

                int SilProfMax = item.Strength_Max + rasa.Strength_Corection;
                int ObrProfMax = item.Agility_Max + rasa.Agility_Corection;
                int OdolProfMax = item.Constitution_Max + rasa.Constitution_Corection;
                int IntProfMax = item.Intelligence_Max + rasa.Intelligence_Correction;
                int ChProfMax = item.Charisma_Max + rasa.Charisma_Correction;

                item.Strength_Max = (rasa.Strength_Max < SilProfMax) ? SilProfMax : rasa.Strength_Max;
                item.Agility_Max = (rasa.Agility_Max < ObrProfMax) ? ObrProfMax : rasa.Agility_Max;
                item.Constitution_Max = (rasa.Constitution_Max < OdolProfMax) ? OdolProfMax : rasa.Constitution_Max;
                item.Intelligence_Max = (rasa.Intelligence_Max < IntProfMax) ? IntProfMax : rasa.Intelligence_Max;
                item.Charisma_Max = (rasa.Charisma_Max < ChProfMax) ? ChProfMax : rasa.Charisma_Max;
            }

            return View(await context.Profession.ToListAsync());

        }


        // GET: Create
        public IActionResult Create(int? idRace,int? idProfession)
        {

            var valueProfession = context.Profession.Find(idProfession); // Finf -> vybírá jedne záznam podle primárního klíče
            var valueRace = context.Races.Find(idRace);

            int SilProfMin = valueProfession.Strength + valueRace.Strength_Corection;
            int ObrProfMin = valueProfession.Agility + valueRace.Agility_Corection;
            int OdolProfMin = valueProfession.Constitution + valueRace.Constitution_Corection;
            int IntProfMin = valueProfession.Intelligence + valueRace.Intelligence_Correction;
            int ChProfMin = valueProfession.Charisma + valueRace.Charisma_Correction;

            int SilProfMax = valueProfession.Strength_Max + valueRace.Strength_Corection;
            int ObrProfMax = valueProfession.Agility_Max + valueRace.Agility_Corection;
            int OdolProfMax = valueProfession.Constitution_Max + valueRace.Constitution_Corection;
            int IntProfMax = valueProfession.Intelligence_Max + valueRace.Intelligence_Correction;
            int ChProfMax = valueProfession.Charisma_Max + valueRace.Charisma_Correction;

            ViewBag.RaceId = idRace;
            ViewBag.ProfessionId = idProfession;
            ViewBag.Race = valueRace.RaceName;
            ViewBag.Profession = valueProfession.Name;

            ViewBag.Sila = (valueRace.Strength < SilProfMin) ? SilProfMin : valueRace.Strength;
            ViewBag.Obratnost = (valueRace.Agility < ObrProfMin) ? ObrProfMin : valueRace.Agility;
            ViewBag.Odolnost = (valueRace.Constitution < OdolProfMin) ? OdolProfMin : valueRace.Constitution;
            ViewBag.Inteligence = (valueRace.Intelligence < IntProfMin) ? IntProfMin : valueRace.Intelligence;
            ViewBag.Charisma = (valueRace.Charisma < ChProfMin) ? ChProfMin : valueRace.Charisma;

            ViewBag.SilaMax = (valueRace.Strength_Max < SilProfMax) ? SilProfMax : valueRace.Strength_Max;
            ViewBag.ObratnostMax = (valueRace.Agility_Max < ObrProfMax) ? ObrProfMax : valueRace.Agility_Max;
            ViewBag.OdolnostMax = (valueRace.Constitution_Max < OdolProfMax) ? OdolProfMax : valueRace.Constitution_Max;
            ViewBag.InteligenceMax = (valueRace.Intelligence_Max < IntProfMax) ? IntProfMax : valueRace.Intelligence_Max;
            ViewBag.CharismaMax = (valueRace.Charisma_Max < ChProfMax) ? ChProfMax : valueRace.Charisma_Max;

            return View();
        }


        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProfessionId,RaceId,CharacterName,CharacterLevel,CharacterOrigin," +
            "Strength_current,Agility_current,Constitution_current,Intelligence_current,Charisma_current")] Character character)
        {
            if(ModelState.IsValid)
            {

                var valueProfession = context.Profession.Find(character.ProfessionId); // Finf -> vybírá jedne záznam podle primárního klíče
                var valueRace = context.Races.Find(character.RaceId);

                int SilProfMin = valueProfession.Strength + valueRace.Strength_Corection;
                int ObrProfMin = valueProfession.Agility + valueRace.Agility_Corection;
                int OdolProfMin = valueProfession.Constitution + valueRace.Constitution_Corection;
                int IntProfMin = valueProfession.Intelligence + valueRace.Intelligence_Correction;
                int ChProfMin = valueProfession.Charisma + valueRace.Charisma_Correction;

                int SilProfMax = valueProfession.Strength_Max + valueRace.Strength_Corection;
                int ObrProfMax = valueProfession.Agility_Max + valueRace.Agility_Corection;
                int OdolProfMax = valueProfession.Constitution_Max + valueRace.Constitution_Corection;
                int IntProfMax = valueProfession.Intelligence_Max + valueRace.Intelligence_Correction;
                int ChProfMax = valueProfession.Charisma_Max + valueRace.Charisma_Correction;

                //atributy min
                character.Strength = (valueRace.Strength < SilProfMin) ? SilProfMin : valueRace.Strength;
                character.Agility = (valueRace.Agility < ObrProfMin) ? ObrProfMin : valueRace.Agility;
                character.Constitution = (valueRace.Constitution < OdolProfMin) ? OdolProfMin : valueRace.Constitution;
                character.Intelligence = (valueRace.Intelligence < IntProfMin) ? IntProfMin : valueRace.Intelligence;
                character.Charisma = (valueRace.Charisma < ChProfMin) ? ChProfMin : valueRace.Charisma;
                //atributy max
                character.Strength_Max = (valueRace.Strength_Max < SilProfMax) ? SilProfMax : valueRace.Strength_Max;
                character.Agility_Max = (valueRace.Agility_Max < ObrProfMax) ? ObrProfMax : valueRace.Agility_Max;
                character.Constitution_Max = (valueRace.Constitution_Max < OdolProfMax) ? OdolProfMax : valueRace.Constitution_Max;
                character.Intelligence_Max = (valueRace.Intelligence_Max < IntProfMax) ? IntProfMax : valueRace.Intelligence_Max;
                character.Charisma_Max = (valueRace.Charisma_Max < ChProfMax) ? ChProfMax : valueRace.Charisma_Max;
                // Hp
                character.Hp = valueProfession.Hp + valueProfession.HpBonus + character.Constitution_bonus;
                //pohyblivost
                character.Mobility = valueRace.Mobility + character.Strength_bonus * 2 + character.Agility_bonus;



                context.Add(character);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            return View(character);

        }


        // GET: Deník
        public async Task<IActionResult> Denik(int? id)
        {
            List<CharacterSkill> DangerousnessSkill( AtributEnum atribut)
            {
                return  context.CharacterSkill
                        .Include(x => x.Skill)
                        .Where(x => x.CharacterId == id).ToList()
                        .Where(x => x.Atribut == atribut).ToList(); 
            }

           

            if(id == null)
            {
                return NotFound();
            }

            var character = await context.Character
                .Include(c => c.Race)
                .Include(c => c.Profession)
                .Include(c => c.CharacterSkill)
                .FirstOrDefaultAsync(m => m.Id == id);

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


        // GET: Výběr dovednosti
        public async Task<IActionResult> IndexSkills(AtributEnum atribut,int? Id,int? skillPoint)
        {




            var skillContext = context.Skill.Include(c => c.SkillTable)
                .Where(x => x.Atribut == atribut);                    // vypíše skilly podle předaného atributu


            int sumSkillPointForAtribute = 0;    // součet bodů u dané dovednosti


            foreach(var skill in skillContext)  // prohledání všech skillů v dané dovednosti a jejich součet 
            {
                var sumCurrent = context.CharacterSkill.
                    Where(x => x.SkillId == skill.Id)   // id skilu == 
                    .Sum(x => x.SkillPoint_curentValue);
                sumSkillPointForAtribute += sumCurrent;

                ViewBag.CurrentSkillPoint = sumCurrent;
            }


            int sumSkillPoint = sumSkillPointForAtribute; // mezikrok - součet do čistého int 

            ViewBag.CharacterId = Id;                           // 
            ViewBag.SkillPoint = skillPoint - sumSkillPoint;
            ViewBag.Test = sumSkillPoint;




            return View(await skillContext.ToListAsync());
        }




        // GET: Characters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var character = await context.Character.FindAsync(id);
            if(character == null)
            {
                return NotFound();
            }
            //ViewData["RaceId"] = new SelectList(_context.Races, "Id","RaceName", character.RaceId);
            //ViewData["RaceId"] = _context.Races.Where(r => r.Id == idRasy).Select(x=>x.RaceName).ToList();
            //ViewData["SubProfessionId"] = new SelectList(_context.SubProfession, "Id","NazevSubPovolani", character.ProfessionId);
            return View(character);
        }

        // POST: Characters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,[Bind("Id,SubProfessionId,RaceId,CharacterName,CharacterLevel,PuvodPostavy,Sila,Obratnost,Odolnost,Inteligence,Charisma")] Character character)
        {
            if(id != character.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    context.Update(character);
                    await context.SaveChangesAsync();
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
            ViewData["RaceId"] = new SelectList(context.Races,"Id","Id",character.RaceId);

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
