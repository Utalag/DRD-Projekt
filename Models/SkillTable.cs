using System.ComponentModel.DataAnnotations;

namespace DnDV4.Models
{
    public class SkillTable
    {
        //SKILL TABLE => Skill => Character => Denik

        public int Id { get; set; }

        public ICollection<Skill>? Skills { get; set; }     //navigace na Skill


        [MaxLength(20)]
        [Display(Name = "Stupeň")]
        public RangeSkillEnum Rank { get; set; }

        [Display(Name = "Nebezpečnost")]
        public int Dangerousness { get; set; }

        [Display(Name = "Lehká")]
        public int Easy { get; set; }
        //public SeriousnessEnum Easy { get; set; } // zápis pře enum

        [Display(Name = "Střední")]
        public int Medium { get; set; }

        [Display(Name = "Těžká")]
        public int Hard { get; set; }

        [Display(Name = "Velmi Těžká")]
        public int VeryHard { get; set; }



    }
}
