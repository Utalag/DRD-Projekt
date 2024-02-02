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
        mobility
    }



    static class Enum
    {
    }
}
