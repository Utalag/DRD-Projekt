﻿// <auto-generated />
using System;
using DnDV4.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DnDV4.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240205022640_FightValue")]
    partial class FightValue
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DnDV4.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Agility")
                        .HasColumnType("int");

                    b.Property<int>("Agility_Max")
                        .HasColumnType("int");

                    b.Property<int>("Agility_Skill_Points")
                        .HasColumnType("int");

                    b.Property<int>("Agility_Skill_Points_current")
                        .HasColumnType("int");

                    b.Property<int>("Agility_bonus")
                        .HasColumnType("int");

                    b.Property<int>("Agility_current")
                        .HasColumnType("int");

                    b.Property<int>("CharacterLevel")
                        .HasColumnType("int");

                    b.Property<string>("CharacterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CharacterOrigin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Charisma")
                        .HasColumnType("int");

                    b.Property<int>("Charisma_DiceRoll")
                        .HasColumnType("int");

                    b.Property<int>("Charisma_Max")
                        .HasColumnType("int");

                    b.Property<int>("Charisma_Skill_Points")
                        .HasColumnType("int");

                    b.Property<int>("Charisma_Skill_Points_current")
                        .HasColumnType("int");

                    b.Property<int>("Charisma_bonus")
                        .HasColumnType("int");

                    b.Property<int>("Charisma_current")
                        .HasColumnType("int");

                    b.Property<int>("Constitution")
                        .HasColumnType("int");

                    b.Property<int>("Constitution_DiceRoll")
                        .HasColumnType("int");

                    b.Property<int>("Constitution_Max")
                        .HasColumnType("int");

                    b.Property<int>("Constitution_Skill_Points")
                        .HasColumnType("int");

                    b.Property<int>("Constitution_Skill_Points_current")
                        .HasColumnType("int");

                    b.Property<int>("Constitution_bonus")
                        .HasColumnType("int");

                    b.Property<int>("Constitution_current")
                        .HasColumnType("int");

                    b.Property<int>("Dexterity_DiceRoll")
                        .HasColumnType("int");

                    b.Property<int>("Hp")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence_DiceRoll")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence_Max")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence_Skill_Points")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence_Skill_Points_current")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence_bonus")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence_current")
                        .HasColumnType("int");

                    b.Property<int>("Mobility")
                        .HasColumnType("int");

                    b.Property<int>("Mobility_bonus")
                        .HasColumnType("int");

                    b.Property<int>("ProfessionId")
                        .HasColumnType("int");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int>("Strength_DiceRoll")
                        .HasColumnType("int");

                    b.Property<int>("Strength_Max")
                        .HasColumnType("int");

                    b.Property<int>("Strength_Skill_Points")
                        .HasColumnType("int");

                    b.Property<int>("Strength_Skill_Points_cureent")
                        .HasColumnType("int");

                    b.Property<int>("Strength_bonus")
                        .HasColumnType("int");

                    b.Property<int>("Strength_current")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfessionId");

                    b.HasIndex("RaceId");

                    b.ToTable("Character");
                });

            modelBuilder.Entity("DnDV4.Models.CharacterSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Atribut")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("Dangerousness")
                        .HasColumnType("int");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.Property<int>("SkillPoint_curentValue")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("SkillId");

                    b.ToTable("CharacterSkill");
                });

            modelBuilder.Entity("DnDV4.Models.CharacterWeapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AtackNr")
                        .HasColumnType("int");

                    b.Property<int>("CharacterID")
                        .HasColumnType("int");

                    b.Property<int>("DefenseNr")
                        .HasColumnType("int");

                    b.Property<int>("DemageNr")
                        .HasColumnType("int");

                    b.Property<int>("WeaponId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterID");

                    b.HasIndex("WeaponId");

                    b.ToTable("CharacterWeapon");
                });

            modelBuilder.Entity("DnDV4.Models.Profession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Agility")
                        .HasColumnType("int");

                    b.Property<int>("Agility_Max")
                        .HasColumnType("int");

                    b.Property<int>("Charisma")
                        .HasColumnType("int");

                    b.Property<int>("Charisma_DiceRoll")
                        .HasColumnType("int");

                    b.Property<int>("Charisma_Max")
                        .HasColumnType("int");

                    b.Property<int>("Constitution")
                        .HasColumnType("int");

                    b.Property<int>("Constitution_DiceRoll")
                        .HasColumnType("int");

                    b.Property<int>("Constitution_Max")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dexterity_DiceRoll")
                        .HasColumnType("int");

                    b.Property<int>("Hp")
                        .HasColumnType("int");

                    b.Property<int>("HpBonus")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence_DiceRoll")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence_Max")
                        .HasColumnType("int");

                    b.Property<int>("Mana")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int>("Strength_DiceRoll")
                        .HasColumnType("int");

                    b.Property<int>("Strength_Max")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Profession");
                });

            modelBuilder.Entity("DnDV4.Models.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Agility")
                        .HasColumnType("int");

                    b.Property<int>("Agility_Corection")
                        .HasColumnType("int");

                    b.Property<int>("Agility_Max")
                        .HasColumnType("int");

                    b.Property<int>("Charisma")
                        .HasColumnType("int");

                    b.Property<int>("Charisma_Correction")
                        .HasColumnType("int");

                    b.Property<int>("Charisma_DiceRoll")
                        .HasColumnType("int");

                    b.Property<int>("Charisma_Max")
                        .HasColumnType("int");

                    b.Property<int>("Constitution")
                        .HasColumnType("int");

                    b.Property<int>("Constitution_Corection")
                        .HasColumnType("int");

                    b.Property<int>("Constitution_DiceRoll")
                        .HasColumnType("int");

                    b.Property<int>("Constitution_Max")
                        .HasColumnType("int");

                    b.Property<int>("Dexterity_DiceRoll")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence_Correction")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence_DiceRoll")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence_Max")
                        .HasColumnType("int");

                    b.Property<int>("Mobility")
                        .HasColumnType("int");

                    b.Property<string>("RaceDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RaceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RaceSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialAbilities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int>("Strength_Corection")
                        .HasColumnType("int");

                    b.Property<int>("Strength_DiceRoll")
                        .HasColumnType("int");

                    b.Property<int>("Strength_Max")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("DnDV4.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Atribut")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Failure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatalFailure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Seriousness")
                        .HasColumnType("int");

                    b.Property<int?>("SkillTableId")
                        .HasColumnType("int");

                    b.Property<string>("Success")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TotalSuccess")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Verification")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SkillTableId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("DnDV4.Models.SkillTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Dangerousness")
                        .HasColumnType("int");

                    b.Property<int>("Easy")
                        .HasColumnType("int");

                    b.Property<int>("Hard")
                        .HasColumnType("int");

                    b.Property<int>("Medium")
                        .HasColumnType("int");

                    b.Property<int>("Rank")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<int>("VeryHard")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SkillTable");
                });

            modelBuilder.Entity("DnDV4.Models.SubProfession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HpIncrement")
                        .HasColumnType("int");

                    b.Property<string>("NazevSubPovolani")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PopisSubPovolani")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfessionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SubProfession");
                });

            modelBuilder.Entity("DnDV4.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassWeapon")
                        .HasColumnType("int");

                    b.Property<int>("ControlAttribute")
                        .HasColumnType("int");

                    b.Property<int?>("Demon")
                        .HasColumnType("int");

                    b.Property<int>("InitiativeWeapon")
                        .HasColumnType("int");

                    b.Property<int>("LengthWeapon")
                        .HasColumnType("int");

                    b.Property<string>("Manufacturer")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ManufacturerBonus")
                        .HasColumnType("int");

                    b.Property<int?>("MaxGunshot")
                        .HasColumnType("int");

                    b.Property<string>("Metal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MiddleGunshot")
                        .HasColumnType("int");

                    b.Property<int?>("MinGunshot")
                        .HasColumnType("int");

                    b.Property<int>("MinimalControllability")
                        .HasColumnType("int");

                    b.Property<string>("NameWeapon")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NickName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OZ")
                        .HasColumnType("int");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<int>("SZ")
                        .HasColumnType("int");

                    b.Property<int>("SizeWeapon")
                        .HasColumnType("int");

                    b.Property<int>("TypeWeapon")
                        .HasColumnType("int");

                    b.Property<int>("UT")
                        .HasColumnType("int");

                    b.Property<int?>("WeightWeapon")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Weapon");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DnDV4.Models.Character", b =>
                {
                    b.HasOne("DnDV4.Models.Profession", "Profession")
                        .WithMany("Characters")
                        .HasForeignKey("ProfessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DnDV4.Models.Race", "Race")
                        .WithMany("Characters")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profession");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("DnDV4.Models.CharacterSkill", b =>
                {
                    b.HasOne("DnDV4.Models.Character", "Character")
                        .WithMany("CharacterSkill")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DnDV4.Models.Skill", "Skill")
                        .WithMany("CharacterSkill")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("DnDV4.Models.CharacterWeapon", b =>
                {
                    b.HasOne("DnDV4.Models.Character", "Character")
                        .WithMany("CharacterWeapon")
                        .HasForeignKey("CharacterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DnDV4.Models.Weapon", "Weapon")
                        .WithMany("CharacterWeapon")
                        .HasForeignKey("WeaponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("DnDV4.Models.Skill", b =>
                {
                    b.HasOne("DnDV4.Models.SkillTable", "SkillTable")
                        .WithMany("Skills")
                        .HasForeignKey("SkillTableId");

                    b.Navigation("SkillTable");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DnDV4.Models.Character", b =>
                {
                    b.Navigation("CharacterSkill");

                    b.Navigation("CharacterWeapon");
                });

            modelBuilder.Entity("DnDV4.Models.Profession", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("DnDV4.Models.Race", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("DnDV4.Models.Skill", b =>
                {
                    b.Navigation("CharacterSkill");
                });

            modelBuilder.Entity("DnDV4.Models.SkillTable", b =>
                {
                    b.Navigation("Skills");
                });

            modelBuilder.Entity("DnDV4.Models.Weapon", b =>
                {
                    b.Navigation("CharacterWeapon");
                });
#pragma warning restore 612, 618
        }
    }
}
