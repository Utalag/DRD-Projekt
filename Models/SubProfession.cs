using System.ComponentModel.DataAnnotations;

namespace DRD.Models
{
    // Profession => SUBPROFESSION => Character => Deník

    public class SubProfession
    {
        public int Id { get; set; }


        public int ProfessionId { get; set; }                   // záislost na Profesi
        //public Profession? Profession { get; set; }          // záislost na Profesi

        //public ICollection<Character>? Characters { get; set; } // (parent) reference na character

        //[Display(Name = "Název Subpovolání")]
        public string NazevSubPovolani { get; set; } = "";

        //[Display(Name = "Popis")]
        public string? PopisSubPovolani { get; set; } = "";

        
        public int HpIncrement { get; set; } // přírůstek životů na 9. úroveň

        // doplnit schopnosti daného povolání

    }
}
