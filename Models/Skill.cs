﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace DnDV4.Models
{
    public enum SeriousnessEnum 
    {
        [Display(Name ="lehká")]
        easy,
        [Display(Name = "střední")]
        middle,
        [Display(Name = "těžká")]
        hard,
        [Display(Name = "velmi těžká")]
        veryHard 
    }
    public enum AtributEnum
    {
        [Display(Name = "Síla")]
        strength,
        [Display(Name = "Obratnost")]
        agility,
        [Display(Name = "Odolnost")]
        constitution,
        [Display(Name = "Inteligence")]
        intelligence,
        [Display(Name = "Charisma")]
        charisma,
        [Display(Name = "Pohyblivost")]
        mobility
    }


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


