using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DnDV4.Models
{
    //  RACE => Character => Deník


    public class Race:IAtribut
    {
        
        public int Id { get; set; }
        [Display(Name = "Název rasy")]
        public string RaceName { get; set; } = string.Empty;
        [Display(Name = "Popis rasy")]
        public string RaceDescription { get; set; } = string.Empty;
        [Display(Name = "Velikost")]
        public string RaceSize { get; set; } = string.Empty;
        [Display(Name = "Pohyblivost")]
        public int    Mobility { get; set; }
        [Display(Name = "Specíální dovednost")]
        public string? SpecialAbilities { get; set; }

        
        // NAVIGACE
         public ICollection<Character>? Characters { get; set; }

        [Display(Name = "Síla")]
        public int Strength                 { get;set;}
        [Display(Name = "Síla Max")]
        public int Strength_Max             { get;set;}
        [Display(Name = "Oprava")]
        public int Strength_Corection       { get;set;}

        [Display(Name = "Obratnost")]
        public int Agility                { get;set;}
        [Display(Name = "Obratnost Max")]
        public int Agility_Max            { get;set;}
        [Display(Name = "Oprava")]
        public int Agility_Corection      { get;set;}

        [Display(Name = "Odolnost")]
        public int Constitution             { get;set;}
        [Display(Name = "Odolnost Max")]
        public int Constitution_Max         { get;set;}
        [Display(Name = "Oprava")]
        public int Constitution_Corection   { get;set;}

        [Display(Name = "Inteligence")]
        public int Intelligence             { get;set;}
        [Display(Name = "Inteligence Max")]
        public int Intelligence_Max         { get;set;}
        [Display(Name = "Oprava")]
        public int Intelligence_Correction  { get;set;}

        [Display(Name = "Charisma")]
        public int Charisma                 { get;set;}
        [Display(Name = "Charisma Max")]
        public int Charisma_Max             { get;set;}
        [Display(Name = "Oprava")]
        public int Charisma_Correction      { get;set;}
        public int Strength_DiceRoll        { get { return DiceRoll(Strength,     Strength_Max         ); } set { } }
        public int Dexterity_DiceRoll       { get { return DiceRoll(Agility,      Agility_Max    ); } set { } }
        public int Constitution_DiceRoll    { get { return DiceRoll(Constitution, Constitution_Max     ); } set { } }
        public int Intelligence_DiceRoll    { get { return DiceRoll(Intelligence, Intelligence_Max  ); } set { } }
        public int Charisma_DiceRoll        { get { return DiceRoll(Charisma,     Charisma_Max     ); } set { } }


        protected int DiceRoll(int min,int max)
        {
            int roll = (max - min) / 5;

            return roll;
        }



    }

    

}