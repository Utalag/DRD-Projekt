using System.ComponentModel.DataAnnotations;

namespace DnDV4.Models
{
    // vazební tabulka
    public class CharacterWeapon()
    {
        public int Id { get; set; }
        public int CharacterID { get; set; }
        public int WeaponId { get; set; }

        [Display(Name ="Zbraň")]
        public Weapon? Weapon { get; set; }
        public Character? Character { get; set; }



        [Display(Name = "Uč")]
        public int AtackNr { get; set; }

        [Display(Name = "ut")]
        public int DemageNr { get; set; }

        [Display(Name = "Oč")]
        public int DefenseNr { get; set; }


        public int FightValue(int strength,int agility,int weaponAtribut)
        {
            int baseCalculation = (strength + agility) / 2;
            int baseBonus = Character.AtributBonus[baseCalculation];
            baseBonus += weaponAtribut; // SZ/UT/OZ
            return baseBonus;
        }

        public int FightValue(int bodyAtribut,int weaponAtribut)
        {
            int baseBonus = Character.AtributBonus[bodyAtribut];
            baseBonus += weaponAtribut; // SZ/UT/OZ
            return baseBonus;
        }



    }
}
