using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DRD.Models
{

    public class CharacterSkill
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }        // id postavy
        public int SkillId { get; set; }            // id skilu

        public Character? Character { get; set; } 
        public Skill? Skill { get; set; }

        public int Dangerousness { get; set; }

        public AtributEnum Atribut { get; set; }

        [Display(Name ="Úroveň dovednosti")]
        public RangeSkillEnum Rank { get; set;} // rozsah naučené dovednotu

        [Display(Name ="Aktuální počt profibodů")]
        public int SkillPoint_curentValue { get; set; } // 

        [NotMapped]
        [Display(Name = "Pokračovat na další stránku?")]
        public bool RepeatView {  get; set; } // proměná pro View
    }
}
