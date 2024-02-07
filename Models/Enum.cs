using System.ComponentModel.DataAnnotations;

namespace DnDV4.Models
{
    public enum RangeSkillEnum
    {
        [Display(Name = "Vůbec")]
        vubec,
        [Display(Name = "Velmi špatně")]
        vSpatne,
        [Display(Name = "Špatně")]
        spatne,
        [Display(Name = "Půměrně")]
        prumerne,
        [Display(Name = "Dobře")]
        dobre,
        [Display(Name = "Velmi dobře")]
        vDobre,
        [Display(Name = "Dokonale")]
        dokonale
    }

    public enum SeriousnessEnum
    {
        [Display(Name = "lehká")]
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
        mobility,
    }

    public enum WeaponClassEnum
    {
        [Display(Name = "Jednoruční")]  //0
        oneHanded,
        [Display(Name = "Obouruční")]   //1
        twoHanded,
        [Display(Name = "Vrhací")]      //2
        throwing,
        [Display(Name = "Střelná")]     //3
        firearm,
        [Display(Name = "Kontaktní")]   //4
        contact,

    }

    public enum WeaponTypeEnum
    {
        [Display(Name = "Úderná")]  //0
        striking,
        [Display(Name = "Drtivá")]  //1
        crushing,
        [Display(Name = "Bodná")]   //2
        stab,
        [Display(Name = "Sečná")]   //3
        cut,
    }

    public enum WeaponSizeEnum
    {
        [Display(Name = "Lehká")]   //0
        light,
        [Display(Name = "Střední")] //1
        medium,
        [Display(Name = "Těžká")]   //2
        heavy,
        
    }


    static class Enum
    {
    }
}
