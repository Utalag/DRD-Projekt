using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnDV4.Models
{
    // Profession                   => CHARACTER    => Deník
    //               Race           => CHARACTER    => Deník
    // Profibod   -  Skill         <=> CHARACTER    => Deník
    //               Weapon         => CHARACTER    => Deník

    public class Character : IAtribut
    {


        public int Id { get; set; }

        [Display(Name = "Povolání")]
        public int ProfessionId { get; set; }
        public Profession? Profession { get; set; }

        [Display(Name = "Rasa")]
        public int RaceId { get; set; }
        public Race? Race { get; set; }         //Vazba 1:N

        public List<CharacterSkill> CharacterSkill { get; set; } = new();       //vazba M:N
        public List<CharacterWeapon> CharacterWeapon { get; set; } = new();     //vazba M:N

        [Display(Name = "Jméno tvé postavy")]
        public string CharacterName { get; set; } = string.Empty;
        [Display(Name = "Úroveň")]
        public int CharacterLevel { get; set; } = 1;
        [Display(Name = "Původ")]
        public string CharacterOrigin { get; set; } = string.Empty;

        
        public int Strength { get; set; }           // <- nastaví konroller
        public int Strength_Max { get; set; }       // <- nastaví konroller
        [Display(Name = "Síla")]
        public int Strength_current { get; set; }
        public int Strength_bonus { get { return AtributBonus[Strength_current]; } set { } }

        
        public int Agility { get; set; }            // <- nastaví konroller
        public int Agility_Max { get; set; }        // <- nastaví konroller
        [Display(Name = "Obratnost")]
        public int Agility_current {  get; set; }
        public int Agility_bonus { get { return AtributBonus[Agility_current]; } set { } }

        
        public int Constitution { get; set; }       // <- nastaví konroller
        public int Constitution_Max { get; set; }   // <- nastaví konroller
        [Display(Name = "Odolnost")]
        public int Constitution_current {  get; set; }
        public int Constitution_bonus { get { return AtributBonus[Constitution_current]; } set { } }

        
        public int Intelligence { get; set; }       // <- nastaví konroller
        public int Intelligence_Max { get; set; }   // <- nastaví konroller
        [Display(Name = "Inteligence")]
        public int Intelligence_current {  get; set; }
        public int Intelligence_bonus { get { return AtributBonus[Intelligence_current]; } set { } }

       
        public int Charisma { get; set; }           // <- nastaví konroller
        public int Charisma_Max { get; set; }       // <- nastaví konroller
        [Display(Name = "Charisma")]
        public int Charisma_current {  get; set; }
        public int Charisma_bonus {get { return AtributBonus[Charisma_current]; }set { } }

        // vypočítané hodnoty

        //pohyblivost
        [Display(Name = "Pohyblivost")]
        public int Mobility { get; set; }
        public int Mobility_bonus { get { return AtributBonus[Mobility]; } set { } }
        //dovednostní body
        public int Strength_Skill_Points { get { return (5+(CharacterLevel/2))*Strength_current; } set { } }
        public int Agility_Skill_Points { get { return (5 + (CharacterLevel / 2)) * Agility_current; } set { } }
        public int Constitution_Skill_Points { get { return (5 + (CharacterLevel / 2)) * Constitution_current; } set { } }
        public int Intelligence_Skill_Points { get { return (5 + (CharacterLevel / 2)) * Intelligence_current; } set { } }
        public int Charisma_Skill_Points { get { return (5 + (CharacterLevel / 2)) * Charisma_current; } set { } }
        //
        public int Strength_Skill_Points_cureent     { get; set; } 
        public int Agility_Skill_Points_current      { get; set; }
        public int Constitution_Skill_Points_current { get; set; }
        public int Intelligence_Skill_Points_current { get; set; }
        public int Charisma_Skill_Points_current     { get; set; }
        //životy na 1. urovni
        [Display(Name ="Životy")]
        public int Hp { get; set; }                 // !!!doplnit logiku











        public int Strength_DiceRoll { get; set; }
        public int Dexterity_DiceRoll { get; set; }
        public int Constitution_DiceRoll { get; set; }
        public int Intelligence_DiceRoll { get; set; }
        public int Charisma_DiceRoll { get; set; }


        //bonusy k atributem
        [NotMapped]
        public static Dictionary<int,int> AtributBonus { get; set; } = new()
        {
            [0] = 0,
            [1] = 5,
            [2] = -4,
            [3] = -4,
            [4] = -3,
            [5] = -3,
            [6] = -2,
            [7] = -2,
            [8] = -1,
            [9] = -1,
            [10] = 0,
            [11] = 0,
            [12] = 0,
            [13] = 1,
            [14] = 1,
            [15] = 2,
            [16] = 2,
            [17] = 3,
            [18] = 3,
            [19] = 4,
            [20] = 4,
            [21] = 5,
            [22] = 5,
            [23] = 6,
            [24] = 6
        };

        [NotMapped]
        public int Strength_Corection { get; set; }
        [NotMapped]
        public int Agility_Corection { get; set; }
        [NotMapped]
        public int Constitution_Corection { get; set; }
        [NotMapped]
        public int Intelligence_Correction { get; set; }
        [NotMapped]
        public int Charisma_Correction { get; set; }

    }
}

