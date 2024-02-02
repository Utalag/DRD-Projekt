using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace DnDV4.Models
{
    public class BodyAttribute
    {
        // TODO: implementovat

        public int ID { get; set; }

        // zvolená atribut
        [Required]
        [Display(Name = "Fyzický atribut")]
        public AtributEnum Atribut { get; set; }

        // minimílní rozsah atributu
        [Range(1,16,ErrorMessage = "Zadej 1 až 16")]
        public int? Min {  get; set; }

        // maximální rozsah atributu
        [Range(6,21,ErrorMessage = "Zadej 6 až 21")]
        public int? Max { get; set; }

        //Konečná hodnota atributu u characteru
        [Display(Name = "")]
        [Range(1,23,ErrorMessage = "Zadej 1 až 23")]
        public int? FinalAtribut { get; set; }

        // výsledný bonus k FinalAtribut
        [Display(Name = "Bonus")]
        [Range(-10,10,ErrorMessage = "Zadej -10 až 10")]
        public int? Bonus { get; set; }

        // počet hodů k6 kostkou 
        [Display(Name ="hod k6")]
        [Range(0,3,ErrorMessage = "Zadej 0 až 3")]
        public int? DiceRoll { get; set; }

        // opravná hodnota k povolání
        [Display(Name = "Korekce")]
        [Range(0,8,ErrorMessage = "Zadej 0 až 8")]
        public int? Corection { get; set; }

        // obacý popis atibutu k čemu je
        [Display(Name = "Popis tělesného atributu")]
        public string DescriptionAtribute { get; set; } = string.Empty;

    } 
}
