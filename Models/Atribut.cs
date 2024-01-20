using System.ComponentModel.DataAnnotations;

namespace DnDV4.Models
{

    interface IAtribut
    {
         
         int Strength           { get; set; }
         int Strength_Max        { get; set; }
         int Strength_Corection    { get; set; }

         int Agility        { get; set; }
         int Agility_Max     { get; set; }
         int Agility_Corection { get; set; }

         int Constitution        { get; set; }
         int Constitution_Max     { get; set; }
         int Constitution_Corection { get; set; }

         int Intelligence        { get; set; }
         int Intelligence_Max     { get; set; }
         int Intelligence_Correction { get; set; }

         int Charisma        { get; set; }
         int Charisma_Max     { get; set; }
         int Charisma_Correction { get; set; }


         int Strength_DiceRoll        { get; set; }
         int Dexterity_DiceRoll   { get; set; }
         int Constitution_DiceRoll    { get; set; }
         int Intelligence_DiceRoll { get; set; }
         int Charisma_DiceRoll    { get; set; }



    }

}
