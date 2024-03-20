using DnDV4.Data;
using DnDV4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;

namespace DnDV4.Controllers
{
    public class CharacterSkillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CharacterSkillsController(ApplicationDbContext context)
        {
            _context = context;
        }


        //--------------METODY-------------
        //metoda pro stanovení maximálních hodnot dovdností
        int MaxSkillPoint(AtributEnum atribut,int? CharacterId)
        {
            var serchCharacterValues = _context.Character.Where(x => x.Id == CharacterId);
            _context.CharacterSkill.Include(x => x.Skill);

            // výchozí hodnota profibodů dané vlastnosti
            int baseSkillPoint = 0;
            // vypíše u vybrané postavy body pro vybranou vlastnost
            switch(atribut)
            {
                case AtributEnum.strength:
                baseSkillPoint = serchCharacterValues.Select(x => x.Strength_Skill_Points).Sum();
                break;
                case AtributEnum.agility:
                baseSkillPoint = serchCharacterValues.Select(x => x.Agility_Skill_Points).Sum();
                break;
                case AtributEnum.constitution:
                baseSkillPoint = serchCharacterValues.Select(x => x.Constitution_Skill_Points).Sum();
                break;
                case AtributEnum.intelligence:
                baseSkillPoint = serchCharacterValues.Select(x => x.Intelligence_Skill_Points).Sum();
                break;
                case AtributEnum.charisma:
                baseSkillPoint = serchCharacterValues.Select(x => x.Charisma_Skill_Points).Sum();
                break;
                case AtributEnum.mobility:
				//baseSkillPoint = serchCharacterValues.Select(x => x.Mobility_Skill_Points).Sum();
				break;
                default:
                baseSkillPoint = 0;
                break;
            }
            return baseSkillPoint;
        }
        //metoda pro filtrovýní hodnot ze skillTable podle obtížnosti skillu
        List<System.Collections.ICollection> ValuePointsGet(Skill currentSkill,int maxPoint,int currentPoint)
        {
            //currentSkill  = konkrétní skill(dovednost)
            //maxPoint      = maximum použitelných profibodů pro omezení maxiálního stupně dovednosti

            int points;
            if(maxPoint <= currentPoint)
                points = currentPoint;
            else
            { points = maxPoint; }

            List<System.Collections.ICollection> skillValue = new List<System.Collections.ICollection>();

            switch(currentSkill.Seriousness)
            {
                case SeriousnessEnum.easy:
                {
                    var value = _context.SkillTable
                        .Where(x => x.Easy < points && x.Easy > 0)
                        .Select(x => new { Value = x.Easy,IdTable = x.Id,EnumRank = x.Rank }).ToList();
                    skillValue.Add(value);

                    break;
                }
                case SeriousnessEnum.middle:
                {
                    var value = _context.SkillTable
                        .Where(x => x.Medium < points && x.Medium > 0)
                        .Select(x => new { Value = x.Medium,IdTable = x.Id,EnumRank = x.Rank }).ToList();
                    skillValue.Add(value);
                    break;
                }
                case SeriousnessEnum.hard:
                {
                    var value = _context.SkillTable
                        .Where(x => x.Hard < points && x.Hard > 0)
                        .Select(x => new { Value = x.Hard,IdTable = x.Id,EnumRank = x.Rank }).ToList();
                    skillValue.Add(value);
                    break;
                }
                case SeriousnessEnum.veryHard:
                {
                    var value = _context.SkillTable
                        .Where(x => x.VeryHard < points && x.VeryHard > 0)
                        .Select(x => new { Value = x.VeryHard,IdTable = x.Id,EnumRank = x.Rank }).ToList();
                    skillValue.Add(value);
                    break;
                }
            }


            return skillValue;
        }
        //výpis aktuálních bodů
        int AssignPoints(CharacterSkill characterSkill,int? skillId)
        {
            //var valueSkill = _context.Skill.Find(SkillId);
            var valueSkill = _context.Skill
                            .Where(x => x.Id == skillId)
                            .Select(x => x.Seriousness).First();

            // vytvoří list hodnot profibodů podle obřížnosti

            int points = 0;

            switch(valueSkill)
            {
                case SeriousnessEnum.easy:
                {
                    points = _context.SkillTable
                        .Where(x => x.Rank == characterSkill.Rank)
                        .Select(x => x.Easy).First();
                    break;
                }
                case SeriousnessEnum.middle:
                {
                    points = _context.SkillTable
                        .Where(x => x.Rank == characterSkill.Rank)
                        .Select(x => x.Medium).First();
                    break;
                }
                case SeriousnessEnum.hard:
                {
                    points = _context.SkillTable
                        .Where(x => x.Rank == characterSkill.Rank)
                        .Select(x => x.Hard).First();
                    break;
                }
                case SeriousnessEnum.veryHard:
                {
                    points = _context.SkillTable
                        .Where(x => x.Rank == characterSkill.Rank)
                        .Select(x => x.VeryHard).First();
                    break;
                }

            }
            return points;
        }

        //List hodnot vyplněných skylů
        List<int> ListPoints(AtributEnum atribut,int? characterId)
        {
            var skillContext = _context.Skill.Include(c => c.SkillTable)
           .Where(x => x.Atribut == atribut);

            List<int> ListPoints = new List<int>();
            foreach(var skill in skillContext) // součet bodů u dovedností
            {
                var values = _context.CharacterSkill
                    .Where(x => x.SkillId == skill.Id)
                    .Where(x=>x.CharacterId== characterId)
                    .Sum(x => x.SkillPoint_curentValue);

                ListPoints.Add(values);
            }
            return ListPoints;
        }
        //-------------METODY---------------


        // GET: Index
        public async Task<IActionResult> Index(AtributEnum atribut,int? CharacterId)                                          
        {

			var skillContext = _context.Skill.Include(c => c.SkillTable)
                .Where(x => x.Atribut == atribut); // vypíše skilly podle předaného atributu

            ViewData["Atribut"] = atribut;
            ViewData["CharacterId"] = CharacterId;
            ViewData["SkillPoint"] = MaxSkillPoint(atribut,CharacterId);
            ViewData["Count"] = ListPoints(atribut,CharacterId).Sum();
            ViewData["ListPoints"] = ListPoints(atribut,CharacterId);
            return View(await skillContext.ToListAsync());
        }

        // GET: Create
        public IActionResult Create(int? CharacterId,int? SkillId,int SkillPoint,AtributEnum atribut) 
        {

                if(SkillId == null)
                {
                Console.WriteLine("SkillId je null");
                return NotFound(); }
				

			if(CharacterId == null)
			{
				Console.WriteLine("CharacterId je null");
				return NotFound();
			}

			if(SkillPoint == null)
			{
				Console.WriteLine("SkillPoint je null");
				return NotFound();
			}


			var valueSkill = _context.Skill.Find(SkillId);
            ViewData["ValuePoints"] = ValuePointsGet(valueSkill,SkillPoint,0)[0];
            ViewData["SkillPoints"] = SkillPoint; // předá ve View data do "characterSkill.SkillPoint_curentValue"
            ViewData["CaracterId"] = CharacterId;
            ViewData["Atribut"] = atribut;
            ViewData["SkillName"] = valueSkill.Name;
            ViewData["SkillId"] = SkillId;

            return View();
        }


        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? CharacterId,int? SkillId,AtributEnum atribut,[Bind("Id,Rank,SkillPoint_curentValue,CharacterId,Atribut,SkillId")] CharacterSkill characterSkill)
        {
            if(ModelState.IsValid)
            {
                characterSkill.Dangerousness = _context.SkillTable.Where(x => x.Rank == characterSkill.Rank).Select(x=>x.Dangerousness).First();
                characterSkill.SkillPoint_curentValue = AssignPoints(characterSkill,SkillId);
                characterSkill.Atribut= atribut;
                characterSkill.CharacterId = CharacterId.Value;
                characterSkill.SkillId = SkillId.Value;

                _context.Add(characterSkill);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index",new {atribut = atribut,CharacterId=CharacterId.Value });
            }
            return View(characterSkill);
        }


		// GET: CharacterSkills/Edit/5
		public async Task<IActionResult> Edit( int CharacterId,int SkillId)
        {
			var characterSkill = await _context.CharacterSkill
				.Where(x => x.CharacterId == CharacterId)
				.Where(x => x.SkillId == SkillId)
                .Include(x=>x.Skill)
				.FirstAsync();

			//              maximální počet bodů u dovednosti - součet přiřazených bodů   
			int freePoints = MaxSkillPoint(characterSkill.Atribut,CharacterId) - ListPoints(characterSkill.Atribut,CharacterId).Sum();

			

			ViewData["ValuePoints"] = ValuePointsGet(characterSkill.Skill,freePoints,characterSkill.SkillPoint_curentValue+freePoints)[0];
            //hodnota dané dovednosti
			ViewData["SkillPoint_current"] = characterSkill.SkillPoint_curentValue;

			return View(characterSkill);

		}


        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Rank,SkillPoint_curentValue,CharacterId,Atribut,SkillId")] CharacterSkill characterSkill)
        {
            if(ModelState.IsValid)
            {
                characterSkill.Dangerousness = _context.SkillTable.Where(x => x.Rank == characterSkill.Rank).Select(x => x.Dangerousness).First();
                characterSkill.SkillPoint_curentValue = AssignPoints(characterSkill,characterSkill.SkillId);

                _context.Update(characterSkill);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index",new { atribut = characterSkill.Atribut,CharacterId = characterSkill.CharacterId });   
            }
            return View(characterSkill);
        }

        // GET: CharacterSkills/Details/5
        public async Task<IActionResult> Details(int? CharacterId,int? SkillId)
        {

            var Skill = await _context.Skill
                .FirstOrDefaultAsync(m => m.Id == SkillId); // vypíše skilly podle předaného atributu

            ViewData["CharacterId"] = CharacterId;
            ViewData["SkillId"] = SkillId;

            return View(Skill);

        }


        // GET: CharacterSkills/Delete/5
        public async Task<IActionResult> Delete(int? CharacterId,int? SkillId)
        {
            var ID = await _context.CharacterSkill
                .Where(x => x.CharacterId == CharacterId)
                .Where(x => x.SkillId == SkillId)
                .FirstAsync();

            return View(ID);
        }


        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var characterSkill = await _context.CharacterSkill.FindAsync(id);
            AtributEnum atribut = characterSkill.Atribut;
            int CharacterId = characterSkill.CharacterId;
            if(characterSkill != null)
            {
                _context.CharacterSkill.Remove(characterSkill);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index",new { atribut = atribut,CharacterId = CharacterId });
        }
    }
}
