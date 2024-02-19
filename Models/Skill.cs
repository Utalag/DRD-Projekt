using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace DRD.Models
{

    public class Skill
    {

        public int Id { get; set; }

        [Display(Name = "Název dovednosti")]
        public string Name                       { get; set; } = string.Empty;

        [Display(Name = "Použitá vlastnost")]
        public AtributEnum Atribut               { get; set; }

        [Display(Name = "Obtížnost")]
        public SeriousnessEnum Seriousness       { get; set; }

        [Display(Name = "Ověření")]
        public string? Verification              { get; set; } = string.Empty;

        [Display(Name = "Totální úspěch")]
        public string? TotalSuccess              { get; set; } = string.Empty;

        [Display(Name = "Úspěch")]
        public string? Success                   { get; set; } = string.Empty;

        [Display(Name = "Neúspěch")]
        public string? Failure                   { get; set; } = string.Empty;

        [Display(Name = "Fatální neúspěch")]
        public string? FatalFailure              { get; set; } = string.Empty;

        [Display(Name = "Poznámka")]
        public string Description                { get; set; } = string.Empty;



        public SkillTable? SkillTable { get; set; }

        //public ICollection<Character>? Character { get; set; } //NAVIGACE
        public List<CharacterSkill> CharacterSkill { get; set; } = new();



    }
}


