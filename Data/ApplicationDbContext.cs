using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DnDV4.Models;
namespace DnDV4.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Profession>    Profession      { get; set; }
        public DbSet<SubProfession> SubProfession   { get; set; }
        public DbSet<Skill>         Skill           { get; set; }
        public DbSet<SkillTable>    SkillTable      { get; set; }
        public DbSet<Race>          Races           { get; set; }
        public DbSet<Character>     Character       { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<DnDV4.Models.CharacterSkill> CharacterSkill { get; set; } = default!;

    }
}




