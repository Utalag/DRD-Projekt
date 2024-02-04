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
        [Display(Name = "Síla+Obratnost")]
        strengthANDagility = strength|agility
    }

    public enum WeaponClassEnum
    {
        [Display(Name = "Jednoruční")]
        oneHanded,
        [Display(Name = "Obouruční")]
        twoHanded,
        [Display(Name = "Vrhací")]
        throwing,
        [Display(Name = "Střelná")]
        firearm,
        
    }

    public enum WeaponTypeEnum
    {
        [Display(Name = "Úderná")]
        striking,
        [Display(Name = "Drtivá")]
        crushing,
        [Display(Name = "Bodná")]
        stab,
        [Display(Name = "Sečná")]
        cut,
    }

    public enum WeaponSizeEnum
    {
        [Display(Name = "Lehká")]
        light,
        [Display(Name = "Střední")]
        medium,
        [Display(Name = "Těžká")]
        heavy,
        
    }

    static class Enum
    {
    }
}
