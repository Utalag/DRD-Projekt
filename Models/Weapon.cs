using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;

namespace DnDV4.Models
{
    public class Weapon
    {
        

        public int Id { get; set; }

        public List<CharacterWeapon> CharacterWeapon { get; set; } = new();

        [Required]
        [MaxLength(50)]
        [Display(Name = "Zbraň:")]
        public string NameWeapon { get; set; } = "";

        [Display(Name = "Přezdívka:")]
        [MaxLength(50)]
        public string? NickName { get; set; } = "";

        [Required]
        [Range(-5,40,ErrorMessage = "Maximální rozsah je -5 až 40")]
        [Display(Name = "Síla zbraně:")]
        public int SZ { get; set; }

        [Required]
        [Range(-5,40,ErrorMessage = "Maximální rozsah je -5 až 40")]
        [Display(Name = "Útočnost:")]
        public int UT { get; set; }

        [Required]
        [Range(-5,40,ErrorMessage = "Maximální rozsah je -5 až 40")]
        [Display(Name = "Obrana zbraně:")]
        public int OZ { get; set; }

        [Required]
        [Display(Name = "Třída:")]
        public WeaponClassEnum ClassWeapon { get; set; }

        [Required]
        [Display(Name = "Velikost:")]
        public WeaponSizeEnum SizeWeapon { get; set; }

        [Required]
        [Display(Name = "Typ zbraně:")]
        public WeaponTypeEnum TypeWeapon { get; set; }

        [Display(Name = "Výrobce:")]
        [MaxLength(50)]
        public string? Manufacturer { get; set; } = "";

        [Display(Name = "Bonus od výrobce:")]
        [Range(-2,3,ErrorMessage = "Maximální rozsah je -2 až 3")]
        public int? ManufacturerBonus { get; set; }

        [Display(Name = "Kov:")]
        public string? Metal { get; set; } = "";

        [Display(Name = "Bonus od demona:")]
        [Range(-10,10,ErrorMessage = "Maximální rozsah je -10 až 10")]
        public int? Demon { get; set; }

        [Required]
        [Range(1,30,ErrorMessage = "1 až 30")]
        [Display(Name = "Minimální ovladatelnost od:")]
        public int MinimalControllability { get; set; }

        [Required]
        [Display(Name = "Atribut pro ovládání:")]
        public AtributEnum ControlAttribute { get; set; }

        [Required]
        [Range(0,3,ErrorMessage = "0 až 3")]
        [Display(Name = "Délka zbraně:")]
        public int LengthWeapon { get; set; }

        [Display(Name = "Cena")]
        public int? Price { get; set; }

        [Display(Name = "Váha v mincích:")]
        [Range(1,500,ErrorMessage = "1 až 500 mincí (0,05-25kg)")]
        public int? WeightWeapon { get; set; }

        [Display(Name = "Bonus k iniciativě:")]
        [Range(-6,6,ErrorMessage = "-6 až 6")]
        public int InitiativeWeapon { get; set; }

        //-- střelné --
        [Display(Name = "Minimální dostřel:")]
        [Range(0,50,ErrorMessage = "0 až 50")]
        public int? MinGunshot { get; set; }

        [Display(Name = "Střední dostřel:")]
        [Range(0,100,ErrorMessage = "0 až 100")]
        public int? MiddleGunshot { get; set; }

        [Display(Name = "Maximální dostřel:")]
        [Range(0,200,ErrorMessage = "0 až 200")]
        public int? MaxGunshot { get; set; }


    }


    public class CharacterWeapon()
    {
        public int Id { get; set; }
        public int CharacterID { get; set; }
        public int WeaponId { get; set; }

        public Weapon? Weapon { get; set; }
        public Character? Character { get; set; }
    }
}
