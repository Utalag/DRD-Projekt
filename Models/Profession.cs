using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Text;
namespace DnDV4.Models
{

    

    public class Profession : IAtribut
    {
        // PROFESSION => SubProfession => Character => Deník

        //Dictionary<int,int> bonusAtributu = new Dictionary<int,int>();




        public int Id { get; set; }

        //Navigace
        //public virtual ICollection<SubProfession>? SubProfessions { get; set; }
        public virtual ICollection<Character>? Characters { get; set; }

        public string Name { get; set; } = "";  // [Display (Name = "Základní povolání")]
        public string Description{ get; set; } = "";  // [Display (Name = "Popis")]

        public int Mana     { get; set; }
        public int Hp       { get; set; }
        public int HpBonus  { get; set; }





        //Atribury------------------------------------------------------------------------------------------
        [Display(Name ="Síla")]
        public int Strength     { get; set; }
		[Display(Name = "Obratnost")]
		public int Agility    { get; set; }
		[Display(Name = "Odolnost")]
		public int Constitution { get; set; }
		[Display(Name = "Inteligence")]
		public int Intelligence { get; set; }
		[Display(Name = "Charsisma")]
		public int Charisma     { get; set; }


        //implementace AtributuMAx
        public int Strength_Max       { get => AtributMax(Strength    ,Strength_DiceRoll);     set { } }
        public int Agility_Max        { get => AtributMax(Agility   ,Dexterity_DiceRoll);    set { } }
        public int Constitution_Max   { get => AtributMax(Constitution,Constitution_DiceRoll); set { } }
        public int Intelligence_Max   { get => AtributMax(Intelligence,Intelligence_DiceRoll); set { } }
        public int Charisma_Max       { get => AtributMax(Charisma    ,Charisma_DiceRoll);     set { } }
        
        /// <summary>
        /// výpočet Max síly
        /// </summary>
        /// <param name="min"></param>
        /// <param name="diceroll"></param>
        /// <returns></returns>
        private int AtributMax(int min, int diceroll)
        {
            return (min != 0) ? (min + diceroll*5) : 0;
        }

        // přiřazené hodnoty
        public int Strength_DiceRoll     { get; set; } = 1;
        public int Dexterity_DiceRoll    { get; set; } = 1;
        public int Constitution_DiceRoll { get; set; } = 1;
        public int Intelligence_DiceRoll { get; set; } = 1;
        public int Charisma_DiceRoll     { get; set; } = 1;

        // nepotřebné atributy
        [NotMapped]
        public  int Strength_Corection     { get; set; }
        [NotMapped]
        public  int Agility_Corection    { get; set; }
        [NotMapped]
        public  int Constitution_Corection { get; set; }
        [NotMapped]
        public  int Intelligence_Correction{ get; set; }
        [NotMapped]
        public  int Charisma_Correction    { get; set; }

       
    }
}


