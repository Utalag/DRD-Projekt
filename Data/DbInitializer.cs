using DnDV4.Models;
using System.Security.Cryptography;

namespace DnDV4.Data
{
    public sealed class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)

        {
            // Hledejte nějaké Rasy.
            if(context.Races.Any())  // Any = žádný
            {
                return;   // DB byla nasazena
            }

            var race = new Race[]
            {
                new() {
                RaceName       ="Hobbit",
                RaceDescription="xxx",
                RaceSize       ="A",
                Mobility       =10,
                SpecialAbilities="Hobití čich",
                Strength     = 3, Strength_Max    = 8, Strength_Corection     =-5, Strength_DiceRoll    =1,
                Agility    =11, Agility_Max   =16, Agility_Corection    = 2, Dexterity_DiceRoll   =1,
                Constitution = 8, Constitution_Max=13, Constitution_Corection = 0, Constitution_DiceRoll=1,
                Intelligence =10, Intelligence_Max=15, Intelligence_Correction=-2, Intelligence_DiceRoll=1,
                Charisma     = 8, Charisma_Max    =18, Charisma_Correction    = 3, Charisma_DiceRoll    =2  },

                new (){
                RaceName       ="Gnom",
                RaceDescription="xxx",
                RaceSize       ="A",
                Mobility       =9,
                SpecialAbilities="",
                Strength     = 5, Strength_Max    = 10, Strength_Corection    =-3, Strength_DiceRoll    =1,
                Agility    =10, Agility_Max   =15, Agility_Corection    = 1, Dexterity_DiceRoll   =1,
                Constitution =10, Constitution_Max=15, Constitution_Corection = 1, Constitution_DiceRoll=1,
                Intelligence = 9, Intelligence_Max=14, Intelligence_Correction=-2, Intelligence_DiceRoll=1,
                Charisma     = 7, Charisma_Max    =12, Charisma_Correction    = 0, Charisma_DiceRoll    =1  },

                new (){
                RaceName       ="Trpaslík",
                RaceDescription="xxx",
                RaceSize       ="A",
                Mobility       =8,
                SpecialAbilities="Hobití čich",
                Strength     = 7, Strength_Max    =12, Strength_Corection     = 1, Strength_DiceRoll    =1,
                Agility    = 7, Agility_Max   =12, Agility_Corection    =-2, Dexterity_DiceRoll   =1,
                Constitution =12, Constitution_Max=17, Constitution_Corection = 3, Constitution_DiceRoll=1,
                Intelligence = 8, Intelligence_Max=13, Intelligence_Correction=-3, Intelligence_DiceRoll=1,
                Charisma     = 7, Charisma_Max    =12, Charisma_Correction    =-2, Charisma_DiceRoll    =1  },

                new (){
                RaceName       ="Elf",
                RaceDescription="xxx",
                RaceSize       ="B",
                Mobility       =12,
                SpecialAbilities="Dlouhověkost",
                Strength     = 6, Strength_Max    =11, Strength_Corection     = 0, Strength_DiceRoll    =1,
                Agility    =10, Agility_Max   =15, Agility_Corection    = 1, Dexterity_DiceRoll   =1,
                Constitution = 6, Constitution_Max=11, Constitution_Corection =-4, Constitution_DiceRoll=1,
                Intelligence =12, Intelligence_Max=17, Intelligence_Correction= 2, Intelligence_DiceRoll=1,
                Charisma     = 8, Charisma_Max    =18, Charisma_Correction    = 2, Charisma_DiceRoll    =2  },

                new (){
                RaceName       ="Člověk",
                RaceDescription="xxx",
                RaceSize       ="B",
                Mobility       =11,
                SpecialAbilities="",
                Strength     = 6, Strength_Max    =16, Strength_Corection     = 0, Strength_DiceRoll    =2,
                Agility    = 9, Agility_Max   =14, Agility_Corection    = 0, Dexterity_DiceRoll   =1,
                Constitution = 9, Constitution_Max=14, Constitution_Corection = 0, Constitution_DiceRoll=1,
                Intelligence =10, Intelligence_Max=15, Intelligence_Correction= 0, Intelligence_DiceRoll=1,
                Charisma     = 2, Charisma_Max    =17, Charisma_Correction    = 0, Charisma_DiceRoll    =3  },

                new (){
                RaceName       ="Barbar",
                RaceDescription="xxx",
                RaceSize       ="B",
                Mobility       =12,
                SpecialAbilities="",
                Strength     =10, Strength_Max    =15, Strength_Corection     = 1, Strength_DiceRoll    =1,
                Agility    = 8, Agility_Max   =13, Agility_Corection    =-1, Dexterity_DiceRoll   =1,
                Constitution =11, Constitution_Max=16, Constitution_Corection = 1, Constitution_DiceRoll=1,
                Intelligence = 6, Intelligence_Max=11, Intelligence_Correction= 0, Intelligence_DiceRoll=1,
                Charisma     = 1, Charisma_Max    =16, Charisma_Correction    =-2, Charisma_DiceRoll    =3  },

                new (){
                RaceName       ="Kroll",
                RaceDescription="xxx",
                RaceSize       ="C",
                Mobility       =11,
                SpecialAbilities="Ultrasluch",
                Strength     =11, Strength_Max    =16, Strength_Corection     = 3, Strength_DiceRoll    =1,
                Agility    = 5, Agility_Max   =10, Agility_Corection    =-4, Dexterity_DiceRoll   =1,
                Constitution =13, Constitution_Max=18, Constitution_Corection = 3, Constitution_DiceRoll=1,
                Intelligence = 2, Intelligence_Max= 7, Intelligence_Correction=-6, Intelligence_DiceRoll=1,
                Charisma     = 1, Charisma_Max    =11, Charisma_Correction    =-5, Charisma_DiceRoll    =2  },
            };

            context.Races.AddRange(race);
            context.SaveChanges();

            var profession = new Profession[]
            {
                new (){
                Name       ="Válečník",
                Description="Neohrožený bojovník, který se nelekne žádného boje.",
                Hp         =10,
                HpBonus    =0,
                Mana       =0,
                Strength     =13, Strength_Max    =18, Strength_DiceRoll    =1,
                Agility    = 0, Agility_Max   = 0, Dexterity_DiceRoll   =1,
                Constitution =13, Constitution_Max=18, Constitution_DiceRoll=1,
                Intelligence = 0, Intelligence_Max= 0, Intelligence_DiceRoll=1,
                Charisma     = 0, Charisma_Max    = 0, Charisma_DiceRoll    =1  },

                new (){
                Name       ="Hraničář",
                Description="Lovec, který se v přírodě jistě neztratí, pro své přežití zná pár i jednoduchých kouzel.",
                Hp         =6,
                HpBonus    =2,
                Mana       =0,
                Strength     =11, Strength_Max    =16, Strength_DiceRoll    =1,
                Agility    = 0, Agility_Max   = 0, Dexterity_DiceRoll   =1,
                Constitution = 0, Constitution_Max= 0, Constitution_DiceRoll=1,
                Intelligence =12, Intelligence_Max=17, Intelligence_DiceRoll=1,
                Charisma     = 0, Charisma_Max    = 0, Charisma_DiceRoll    =1  },

                new (){
                Name       ="Alchymista",
                Description="Alchymista je hlavně badatel který vytváří předměty a míchá rozličné lektvary.",
                Hp         =6,
                HpBonus    =1,
                Mana       =0,
                Strength     = 0, Strength_Max    = 0, Strength_DiceRoll    =1,
                Agility    =13, Agility_Max   =18, Dexterity_DiceRoll   =1,
                Constitution =12, Constitution_Max=17, Constitution_DiceRoll=1,
                Intelligence = 0, Intelligence_Max= 0, Intelligence_DiceRoll=1,
                Charisma     = 0, Charisma_Max    = 0, Charisma_DiceRoll    =1  },

                new (){
                Name       ="Kouzelník",
                Description="Kouzlníci se zabývají materií ze které vytvářejí kouzla všeho druhu.",
                Hp         =6,
                HpBonus    =0,
                Mana       =10,
                Strength     = 0, Strength_Max    = 0, Strength_DiceRoll    =1,
                Agility    = 0, Agility_Max   = 0, Dexterity_DiceRoll   =1,
                Constitution = 0, Constitution_Max= 0, Constitution_DiceRoll=1,
                Intelligence =14, Intelligence_Max=19, Intelligence_DiceRoll=1,
                Charisma     =13, Charisma_Max    =18, Charisma_DiceRoll    =1  },

                new (){
                Name       ="Zloděj",
                Description="Nenechavé ruce a bysté oči, tím se vyznačují zloději.",
                Hp         =6,
                HpBonus    =0,
                Mana       =0,
                Strength     = 0, Strength_Max    = 0, Strength_DiceRoll    =1,
                Agility    =14, Agility_Max   =19, Dexterity_DiceRoll   =1,
                Constitution = 0, Constitution_Max= 0, Constitution_DiceRoll=1,
                Intelligence = 0, Intelligence_Max= 0, Intelligence_DiceRoll=1,
                Charisma     =12, Charisma_Max    =17, Charisma_DiceRoll    =1  },

            };

            context.Profession.AddRange(profession);
            context.SaveChanges();

            var skill = new Skill[]
            {
                new ()
                {
                    Name ="Šplh",
                    Atribut = AtributEnum.strength,
                    Seriousness = SeriousnessEnum.easy,
                    Verification = "jednou za 5 sáhů",
                    TotalSuccess= "Nemusí se vůbec ověřovat, postava vyšplhala s poloviční únavou a časem.",
                    Success= "Postava vyšplhala pět sáhů.",
                    Failure= "Sklouznutí o pět sáhů, popřípadě postava nevyšplhala ani prvních pět.",
                    FatalFailure= "Pád, zranění podle pravidel.",
                    Description= "Tato dovednost je používána pouze na tyče, stromy, lana a podobně. Šplh po zdech není součástí této dovednosti. 5 sáhů šplhání stojí postavu 1 bod únavy, každých 5 sáhůse šplhá 2 kola.",
                },

                 new ()
                {
                    Name ="Kamenictví",
                    Atribut = AtributEnum.strength,
                    Seriousness = SeriousnessEnum.middle,
                    Verification = "jednou za výrobek",
                    TotalSuccess= "Perfektní dílo, pokud bylo na zakázku, zvedne se jeho cena.",
                    Success= "Dílo se povedlo.",
                    Failure= "Zmařený materiál.",
                    FatalFailure= "Stojí to, při prvním pokusu o použití se rozpadne.",
                    Description= "Kamenictví se používá k např. opracování ozdobných sloupů, bran,…",
                },

                 new ()
                {
                    Name ="Udržování ohně",
                    Atribut = AtributEnum.agility,
                    Seriousness = SeriousnessEnum.easy,
                    Verification = "jednou za den / změnu počasí k horšímu",
                    TotalSuccess= "Oheň je skvěle udržován, při dalším hodu bonus +3, síla ohně naprosto dle potřeby.",
                    Success= "Oheň zatím hoří (tzn. nezhasnul).",
                    Failure= "Oheň zhasl.",
                    FatalFailure= "Oheň zhasl a postava je navíc popálená za 1k6 životů.",
                    Description= "Postava ovládající toto umění alespoň velmi dobře je nositelem titulu Strážce ohně. Navíc se tato vlastnost hodí v horách při sněhové vánici, když celá družina klepe zubama.",
                },

                  new ()
                {
                    Name ="Získávání jedů",
                    Atribut = AtributEnum.agility,
                    Seriousness = SeriousnessEnum.middle,
                    Verification = "jednou za pokus",
                    TotalSuccess= "Jed má poloviční nebezpečnost i sílu.",
                    Success= "Jed má čtvrtinovou sílu, nebezpečnost -2.",
                    Failure= "Nezíská žádný jed.",
                    FatalFailure= "Otráví se jedem sám!",
                    Description= "Dovednost získávání jedů pomůže získat jed z přírodních látek, zvířat, hub apod. Je ho jen na jeden útok mečem nebo 3 útoky střelnou zbraní (síla se však zmenšuje dle pravidel DrD). Postava musela o daném jedu slyšet nebo musela vědět, že v určené věci je.",
                },

                  new ()
                {
                    Name ="Praní",
                    Atribut = AtributEnum.constitution,
                    Seriousness = SeriousnessEnum.easy,
                    Verification = "jednou za pokus",
                    TotalSuccess= "Prádlo je krásně vyprané, zdá se, jakoby vůbec někdy bylo zašpiněné.",
                    Success= "Prádlo je jakž takž čisté",
                    Failure= "Prádlo je mokré, jinak se nic nezměnilo",
                    FatalFailure= "Prádlo je špinavější než předtím nebo se spralo, pokud byly skvrny velké,je 45% schopnost, že už nepůjdou nikdy oprat.",
                    Description= "Praní prádla nepatří zrovna k oblíbeným druhům zábavy, nicméně postava, která je schopna a ochotna ostatním něco vyprat, je v družině vítána. Aby to nebylo na újmu její stavovské cti, může za to žádat peníze nebo protislužbu. Prát se dá i bez mýdla, ale výsledek je potom o stupeň nižší.",
                },

                  new ()
                {
                    Name ="Vinařství a paličství ",
                    Atribut = AtributEnum.constitution,
                    Seriousness = SeriousnessEnum.hard,
                    Verification = "každá dávka",
                    TotalSuccess= "Delikatesní výrobek. / Znalecký posudek.",
                    Success= "Dobré pití.. / Správné určení moku.",
                    Failure= "Chuťově velmi slabý nápoj. / Postava určí nápoj špatně.",
                    FatalFailure= "Vynikající nápoj, po kterém nastupuje zhoršování zraku i jiné radosti./ Postava odhadne nápoj naprosto špatně, urazí svým posudkem všechny okolo,…",
                    Description= "Tato dovednost se užívá nejen k vytváření přírodních nápojů jako je víno nebo pálenka, ale lze také využít pro rozpoznávání druhů těchto moků.",
                },

                   new ()
                {
                    Name ="Orientace podle hvězd",
                    Atribut = AtributEnum.intelligence,
                    Seriousness = SeriousnessEnum.easy,
                    Verification = "jednou za pokus",
                    TotalSuccess= "Postava skvěle určí světové strany i s nejmenším vodítkem či zataženou oblohou.",
                    Success= "Postava dobře určí světové strany.",
                    Failure= "Chybné určení světových stran.",
                    FatalFailure= "Postava bloudí.",
                    Description= "Orientaci podle hvězd ocení jistě každý, kdo se ocitne ve volné přírodě bez mapy a mimo značené cesty. Podotýkám, že Slunce je také hvězda, orientace podle slunce je tedy také možná.",
                },

                      new ()
                {
                    Name ="Mineralogie",
                    Atribut = AtributEnum.intelligence,
                    Seriousness = SeriousnessEnum.hard,
                    Verification = "jednou za pokus",
                    TotalSuccess= "Postava odhadne druh i pravděpodobnou cenu.",
                    Success= "Postava odhadne druh nerostu.",
                    Failure= "Postava neurčí nic.",
                    FatalFailure= "Chybné určení druhu i ceny nerostu (to není diamant ale obyčejný šutr).",
                    Description= "Tato dovednost se používá k určení druhu nerostu. Nerosty se obvykle nevání po zemi, hledáme-li nějaký, je třeba kutat, dolovat ...",
                },

                         new ()
                {
                    Name ="Herectví",
                    Atribut = AtributEnum.charisma,
                    Seriousness = SeriousnessEnum.middle,
                    Verification = "každých 5 kol",
                    TotalSuccess= "Postava dokonale sehrála určitou situaci. Další ověřování je až další směnu. V případě hraní scény postava vzbudila nadšení, bouřlivý ohlas všech.",
                    Success= "Postava situaci zahrála věrohodně. Pouze bystrý pozorovatel, který celou dobu dával pozor může odhalit, že to postava hraje.",
                    Failure= "Postava zahrála, ale to že to byla hra pozná každý. Obecenstvo je zklamané.",
                    FatalFailure= "Postava zkazila co se dalo. Následuje rozhořčení, přihlížejících, atd.",
                    Description= "Herectvím se dá zahrát scéna (třeba divadelní) nebo předstírat před někým pravdu (např. předstírat opilectví, bláznovství, atd.) Na past na objevení si háže pouze ten, který se snažil odhalit herectví po celou dobu vystoupení, nepodařilo-li se mu to jednou, už si dále nehází, má automatický neúspěch.",
                },

                            new ()
                {
                    Name ="Eskamotérství",
                    Atribut = AtributEnum.charisma,
                    Seriousness = SeriousnessEnum.hard,
                    Verification = "každý výstup",
                    TotalSuccess= "Publikum  je uchváceno, má neuvěřitelný zážitek z vystoupení.",
                    Success= "Vystoupení se líbí, potlesk.",
                    Failure= "Publikum mrmlá, vystoupení zklamalo, případný potlesk jen ze slušnosti.",
                    FatalFailure= "Totální katastrofa - létající ovoce, pískot, výsměch.",
                    Description= "Zahrnuje různé iluzionistické triky a plivání ohně. PJ může popřípadě dát postavám s velmi vysokou inteligencí šanci, že vystoupení prokouknou, ale při totálním úspěchu a úspěchu jim to vadit nebude a příjemně se při vystoupení odreagují a pobaví – asi jako každá postava.",
                }
            };

            context.Skill.AddRange(skill);
            context.SaveChanges();


            var skilltable = new SkillTable[]
            {
                new ()
                {
                   Rank = RangeSkillEnum.vubec,
                   Dangerousness=14,
                   Easy = 0,
                   Medium = 0,
                   Hard = 0,
                   VeryHard = 0,
                },
                new ()
                {
                   Rank = RangeSkillEnum.vSpatne,
                   Dangerousness=11,
                   Easy = 3,
                   Medium = 5,
                   Hard = 7,
                   VeryHard = 9,
                },
                new ()
                {
                   Rank = RangeSkillEnum.spatne,
                   Dangerousness=8,
                   Easy = 9,
                   Medium = 15,
                   Hard = 21,
                   VeryHard = 27,
                },
                new ()
                {
                   Rank = RangeSkillEnum.prumerne,
                   Dangerousness=5,
                   Easy = 18,
                   Medium = 30,
                   Hard = 42,
                   VeryHard = 54,
                },
                new ()
                {
                   Rank = RangeSkillEnum.dobre,
                   Dangerousness=2,
                   Easy = 30,
                   Medium = 50,
                   Hard = 70,
                   VeryHard = 90,
                },
                new ()
                {
                   Rank = RangeSkillEnum.vDobre,
                   Dangerousness=-1,
                   Easy = 45,
                   Medium = 75,
                   Hard = 105,
                   VeryHard = 135,
                },
                new ()
                {
                   Rank = RangeSkillEnum.dokonale,
                   Dangerousness=-4,
                   Easy = 63,
                   Medium = 105,
                   Hard = 147,
                   VeryHard = 189,
                },
            };
            context.SkillTable.AddRange(skilltable);
            context.SaveChanges();
        }
    }
}
