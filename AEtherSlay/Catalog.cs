using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;

/*
 * MAIN DnD CATALOG CLASS
 * 
 * STATS FOLLOW ORDER [STR, CON, DEX, INT, WIS, CHA]
 * DON'T ASK WHY, I WAS HAVING A FUNNY MOMENT...
 */

namespace AEtherSlay
{
    public class Catalog
    {
        #region Enums
        public enum CharacterClass
        {
            Barbarian = 0,
            Bard = 1,
            Cleric = 2,
            Druid = 3,
            Fighter = 4,
            Monk = 5,
            Paladin = 6,
            Ranger = 7,
            Rogue = 8,
            Sorcerer = 9,
            Warlock = 10,
            Wizard = 11
        }

        public enum SpellSchools
        {
            Abjuration = 0,
            Conjuration = 1,
            Divination = 2,
            Enchantment = 3,
            Evocation = 4,
            Illusion = 5,
            Necromancy = 6,
            Transmutation = 7,
            Other = 8
        }
        #endregion

        //YES THIS WAS MANUALLY COPIED
        //NO I CAN'T THINK OF A BETTER WAY
        //YES MY WRISTS HURT
        #region Variables
        public Random rand = new Random();
        public List<Weapon> simpleMelee = new List<Weapon>() {
                            new Weapon("Club", 4, 1, new List<string>() { "Light" }, "Bludgeoning"),
                            new Weapon("Dagger", 4, 1, new List<string>() { "Light", "Finesse", "Thrown (20/60)" }, "Piercing"),
                            new Weapon("Greatclub", 8, 1, new List<string>() { "Light", "Two-Handed" }, "Bludgeoning"),
                            new Weapon("Handaxe", 6, 1, new List<string>() { "Light", "Thrown" }, "Slashing"),
                            new Weapon("Javelin", 6, 1, new List<string>() { "Thrown (30/120)" }, "Piercing"),
                            new Weapon("Light Hammer", 4, 1, new List<string>() { "Light", "Thrown (20/60)" }, "Bludgeoning"),
                            new Weapon("Mace", 6, 1, new List<string>() { }, "Bludgeoning"),
                            new Weapon("Quarterstaff", 6, 1, new List<string>() { "Versatile (1d8)" }, "Bludgeoning"),
                            new Weapon("Sickle", 4, 1, new List<string>() { "Light" }, "Slashing"),
                            new Weapon("Spear", 6, 1, new List<string>() { "Versatile (1d8)", "Thrown (20/60)" }, "Piercing"),
                            new Weapon("Unarmed Strike", 1, 1, new List<string>() { "Light", "Thrown (20/60)" }, "Bludgeoning"),
                    },
                    simpleRanged = new List<Weapon>() {
                            new Weapon("Crossbow [Light]", 8, 1, new List<string>() { "Ammunition (80/320)", "Loading", "Two-Handed" }, "Piercing"),
                            new Weapon("Dart", 4, 1, new List<string>() { "Thrown (20/60)", "Finesse" }, "Piercing"),
                            new Weapon("Shortbow", 6, 1, new List<string>() { "Ammunition (80/320)", "Two-Handed" }, "Piercing"),
                            new Weapon("Sling", 4, 1, new List<string>() { "Ammunition (30/120)" }, "Bludgeoning")
                    },
                    martialMelee = new List<Weapon>() {
                            new Weapon("Battleaxe", 8, 1, new List<string>() { "Versatile (1d10)" }, "Slashing"),
                            new Weapon("Flail", 8, 1, new List<string>() { }, "Bludgeoning"),
                            new Weapon("Glaive", 10, 1, new List<string>() { "Heavy", "Reach", "Two-Handed" }, "Slashing"),
                            new Weapon("Greataxe", 12, 1, new List<string>() { "Heavy", "Two-Handed" }, "Slashing"),
                            new Weapon("Greatsword", 6, 2, new List<string>() { "Heavy", "Two-Handed" }, "Slashing"),
                            new Weapon("Halberd", 10, 1, new List<string>() { "Heavy", "Two-Handed", "Reach" }, "Slashing"),
                            new Weapon("Lance", 12, 1, new List<string>() { "Reach", "Special" }, "Bludgeoning"),
                            new Weapon("Longsword", 8, 1, new List<string>() { "Versatile (1d10)" }, "Slashing"),
                            new Weapon("Maul", 6, 2, new List<string>() { "Heavy", "Two-Handed" }, "Bludgeoning"),
                            new Weapon("Morningstar", 8, 1, new List<string>() { }, "Piercing"),
                            new Weapon("Pike", 10, 1, new List<string>() { "Heavy", "Reach", "Two-Handed" }, "Piercing"),
                            new Weapon("Rapier", 8, 1, new List<string>() { "Finesse" }, "Piercing"),
                            new Weapon("Scimitar", 6, 1, new List<string>() { "Finesse", "Light" }, "Slashing"),
                            new Weapon("Shortsword", 6, 1, new List<string>() { "Finesse", "Light" }, "Piercing"),
                            new Weapon("Trident", 6, 1, new List<string>() { "Thrown (20/60)", "Versatile" }, "Piercing"),
                            new Weapon("War Pick", 8, 1, new List<string>() { }, "Piercing"),
                            new Weapon("Warhammer", 8, 1, new List<string>() { "Versatile (1d10)" }, "Bludgeoning"),
                            new Weapon("Whip", 4, 1, new List<string>() { "Finesse", "Reach" }, "Slashing"),
                    },
                    martialRanged = new List<Weapon>()
                    {
                            new Weapon("Blowgun", 1, 1, new List<string>(){ "Ammunition (25/100)", "Loading" }, "Piercing" ),
                            new Weapon("Crossbow [Hand]", 6, 1, new List<string>(){ "Ammunition (30/120)", "Loading" }, "Piercing" ),
                            new Weapon("Crossbow [Heavy]", 10, 1, new List<string>(){ "Ammunition (100/400)", "Loading" }, "Piercing" ),
                            new Weapon("Longbow", 8, 1, new List<string>(){ "Ammunition (150/600)", "Loading" }, "Piercing" ),
                            new Weapon("Net", 0, 0, new List<string>(){ "Thrown (5/15)", "Special" }, "" )
                    },
                    simple,
                    martial,
                    weapons = new List<Weapon>();
        List<Armor> lightArmor = new List<Armor>()
                    {
                            new Armor("Padded", 100, 11, true),
                            new Armor("Leather", 100, 11, false),
                            new Armor("Studded Leather", 100, 12, false)
                    },
                    mediumArmor = new List<Armor>()
                    {
                            new Armor("Hide", 2, 12, false),
                            new Armor("Chain Shirt", 2, 13, false),
                            new Armor("Scale Mail", 2, 14, true),
                            new Armor("Breastplate", 2, 14, false),
                            new Armor("Half Plate", 2, 15, true)
                    },
                    heavyArmor = new List<Armor>()
                    {
                            new Armor("Ring Mail", 0, 14, true),
                            new Armor("Chain Mail", 0, 16, true),
                            new Armor("Splint", 0, 17, true),
                            new Armor("Plate", 0, 18, true)
                    },
                    armorList;
        public static List<string> languages = new List<string>()
                    {
                            "Common",
                            "Elvish",
                            "Dwarvish",
                            "Giant",
                            "Gnomish",
                            "Goblin",
                            "Halfling",
                            "Orc",
                            "Abyssal",
                            "Celestial",
                            "Draconic",
                            "Deep Speech",
                            "Infernal",
                            "Primordial",
                            "Sylvan",
                            "Undercommon"
                    };
        JArray storedCreatures, storedSpells;
        #endregion

        public Catalog() { catalogInit(); }

        /// <summary>
        ///  MUST BE INVOKED BEFORE USING CATALOG
        /// </summary>
        public void catalogInit()
        {
            armorList = lightArmor;
            armorList.AddRange(mediumArmor);
            armorList.AddRange(heavyArmor);

            simple = simpleMelee;
            simple.AddRange(simpleRanged);

            martial = martialMelee;
            martial.AddRange(martialRanged);

            weapons.AddRange(simple);
            weapons.AddRange(martial);

            storedCreatures = (JArray)JsonConvert.DeserializeObject<object>(File.ReadAllText(@"..\Monsters.json"));
            storedSpells = (JArray)JsonConvert.DeserializeObject<object>(File.ReadAllText(@"..\Spells.json"));
        }

        public void populateCreatureList()
        {
            foreach (JToken creature in storedCreatures)
            {
                if (creature.SelectToken("license") == null)
                {
                    CreatureCharacter currentCreature = new CreatureCharacter();
                    currentCreature.name = (string)creature.SelectToken("name");
                    currentCreature.size = (string)creature.SelectToken("size");
                    currentCreature.type = (string)creature.SelectToken("type");
                    currentCreature.subtype = (string)creature.SelectToken("subtype") ?? "NONE";
                    currentCreature.armorClass = (short)creature.SelectToken("armor_class");
                    currentCreature.hitPoints = (short)creature.SelectToken("hit_points");
                    currentCreature.alignment = (string)creature.SelectToken("alignment");
                    currentCreature.speed = (string)creature.SelectToken("speed") ?? "NONE";
                    currentCreature.rawStr = (short)creature.SelectToken("strength");
                    currentCreature.rawCon = (short)creature.SelectToken("constitution");
                    currentCreature.rawDex = (short)creature.SelectToken("dexterity");
                    currentCreature.rawInt = (short)creature.SelectToken("intelligence");
                    currentCreature.rawWis = (short)creature.SelectToken("wisdom");
                    currentCreature.rawCha = (short)creature.SelectToken("charisma");
                    currentCreature.strSave = (short?)creature.SelectToken("strength_save") ?? Program.catalog.calcModifier(currentCreature.rawStr);
                    currentCreature.conSave = (short?)creature.SelectToken("constitution_save") ?? Program.catalog.calcModifier(currentCreature.rawCon);
                    currentCreature.dexSave = (short?)creature.SelectToken("dexterity_save") ?? Program.catalog.calcModifier(currentCreature.rawDex);
                    currentCreature.intSave = (short?)creature.SelectToken("intelligence_save") ?? Program.catalog.calcModifier(currentCreature.rawInt);
                    currentCreature.wisSave = (short?)creature.SelectToken("wisdom_save") ?? Program.catalog.calcModifier(currentCreature.rawWis);
                    currentCreature.chaSave = (short?)creature.SelectToken("charisma_save") ?? Program.catalog.calcModifier(currentCreature.rawCha);
                    currentCreature.skills.Add(getStatMod("acrobatics", Program.catalog.calcModifier(currentCreature.rawDex), (short?)creature.SelectToken("acrobatics")));
                    currentCreature.skills.Add(getStatMod("animal_handling", Program.catalog.calcModifier(currentCreature.rawWis), (short?)creature.SelectToken("animal_handling")));
                    currentCreature.skills.Add(getStatMod("arcana", Program.catalog.calcModifier(currentCreature.rawInt), (short?)creature.SelectToken("arcana")));
                    currentCreature.skills.Add(getStatMod("athletics", Program.catalog.calcModifier(currentCreature.rawStr), (short?)creature.SelectToken("athletics")));
                    currentCreature.skills.Add(getStatMod("deception", Program.catalog.calcModifier(currentCreature.rawCha), (short?)creature.SelectToken("deception")));
                    currentCreature.skills.Add(getStatMod("history", Program.catalog.calcModifier(currentCreature.rawInt), (short?)creature.SelectToken("history")));
                    currentCreature.skills.Add(getStatMod("insight", Program.catalog.calcModifier(currentCreature.rawWis), (short?)creature.SelectToken("insight")));
                    currentCreature.skills.Add(getStatMod("intimidation", Program.catalog.calcModifier(currentCreature.rawCha), (short?)creature.SelectToken("intimidation")));
                    currentCreature.skills.Add(getStatMod("investigation", Program.catalog.calcModifier(currentCreature.rawInt), (short?)creature.SelectToken("investigation")));
                    currentCreature.skills.Add(getStatMod("medicine", Program.catalog.calcModifier(currentCreature.rawWis), (short?)creature.SelectToken("medicine")));
                    currentCreature.skills.Add(getStatMod("nature", Program.catalog.calcModifier(currentCreature.rawInt), (short?)creature.SelectToken("nature")));
                    currentCreature.skills.Add(getStatMod("perception", Program.catalog.calcModifier(currentCreature.rawWis), (short?)creature.SelectToken("perception")));
                    currentCreature.skills.Add(getStatMod("performance", Program.catalog.calcModifier(currentCreature.rawCha), (short?)creature.SelectToken("performance")));
                    currentCreature.skills.Add(getStatMod("persuasion", Program.catalog.calcModifier(currentCreature.rawCha), (short?)creature.SelectToken("persuasion")));
                    currentCreature.skills.Add(getStatMod("religion", Program.catalog.calcModifier(currentCreature.rawInt), (short?)creature.SelectToken("religion")));
                    currentCreature.skills.Add(getStatMod("sleight_of_hand", Program.catalog.calcModifier(currentCreature.rawDex), (short?)creature.SelectToken("sleight_of_hand")));
                    currentCreature.skills.Add(getStatMod("stealth", Program.catalog.calcModifier(currentCreature.rawDex), (short?)creature.SelectToken("stealth")));
                    currentCreature.skills.Add(getStatMod("survival", Program.catalog.calcModifier(currentCreature.rawWis), (short?)creature.SelectToken("survival")));
                    currentCreature.damageVulns.AddRange(splitString((string)creature.SelectToken("damage_vulnerabilities")));
                    currentCreature.damageRes.AddRange(splitString((string)creature.SelectToken("damage_resistances")));
                    currentCreature.damageImm.AddRange(splitString((string)creature.SelectToken("damage_immunities")));
                    currentCreature.conditionImm.AddRange(splitString((string)creature.SelectToken("condition_immunities")));
                    currentCreature.languages.AddRange(splitString((string)creature.SelectToken("languages")));
                    currentCreature.senses.AddRange(splitString((string)creature.SelectToken("senses")));
                    currentCreature.challengeRating = handleCR(creature.SelectToken("challenge_rating").ToString());
                    currentCreature.passivePerception = (short?)(10 + currentCreature.skills[11].mod);
                    try
                    {
                        foreach (JToken attack in (JArray)creature.SelectToken("actions"))
                        {
                            Attack atkToAdd = new Attack();
                            atkToAdd.name = (string)attack.SelectToken("name");
                            atkToAdd.desc = (string)attack.SelectToken("desc");
                            atkToAdd.dice = (string)attack.SelectToken("damage_dice") ?? "NONE";
                            atkToAdd.atkBonus = (short?)attack.SelectToken("attack_bonus") ?? 0;
                            atkToAdd.dmgBonus = (short?)attack.SelectToken("damage_bonus") ?? 0;
                            currentCreature.attacks.Add(atkToAdd);
                        }
                    }
                    catch { }
                    try
                    {
                        foreach (JToken legAct in (JArray)creature.SelectToken("legendary_actions"))
                        {
                            SpecialAbility action = new SpecialAbility();
                            action.name = (string)legAct.SelectToken("name");
                            action.desc = (string)legAct.SelectToken("desc");
                            currentCreature.legendaryActions.Add(action);
                        }
                    }
                    catch { }
                    try
                    {
                        foreach (JToken abi in (JArray)creature.SelectToken("special_abilities"))
                        {
                            SpecialAbility action = new SpecialAbility();
                            action.name = (string)abi.SelectToken("name");
                            action.desc = (string)abi.SelectToken("desc");
                            currentCreature.specialAbilities.Add(action);
                        }
                    }
                    catch { }
                    Program.storage.storedCreatures.Add(currentCreature);
                }
            }
        }

        public void populateSpellList()
        {
            foreach (JToken s in storedSpells)
            {
                Spell spell = JsonConvert.DeserializeObject<Spell>(JsonConvert.SerializeObject(s));
                Program.storage.spellList.Add(spell);
            }
        }

        #region Utility Functions
        public decimal handleCR(string crString)
        {
            decimal outCR;
            try { outCR = decimal.Parse(crString); }
            catch
            {
                string[] crElems = crString.Split('/');
                outCR = decimal.Parse(crElems[0]) / decimal.Parse(crElems[1]);
            };
            return outCR;
        }

        private string[] splitString(string input)
        {
            string[] output = input.Split(",".ToCharArray()[0]);
            foreach (string thing in output)
            {
                thing.Trim();
            }
            return output;
        }

        public short[] rollStats()
        {
            // STR CON DEX INT WIS CHA
            // 0   1   2   3   4   5
            short[] statRolls = new short[6];

            for (short stat = 0; stat < 6; stat++)
            {
                Int32[] rolls = new Int32[3];
                for (short roll = 0; roll < 4; roll++)
                {
                    Int32 rolled = rand.Next(1, 7);
                    if ((roll == 3) && (rolled > rolls.Min()))
                    {
                        rolls[Array.IndexOf(rolls, rolls.Min())] = rolled;
                    }
                    else
                    {
                        if (roll != 3)
                        {
                            rolls[roll] = rolled;
                        }
                    }
                }
                statRolls[stat] = Convert.ToInt16(rolls.Sum());
            }
            return statRolls;
        }

        public short[] calcModifiers(short[] stats)
        {
            short[] statModifiers = new short[6];
            for (short i = 0; i < stats.Count(); i++)
            {
                if (stats[i] < 10 && (stats[i] % 2) == 1)
                {
                    statModifiers[i] = Convert.ToInt16((double)((stats[i] - 10) / 2) - 1);
                }
                else
                {
                    statModifiers[i] = Convert.ToInt16((double)((stats[i] - 10) / 2));
                }

            }
            return statModifiers;
        }

        public short calcModifier(short? stat)
        {
            if (stat < 10 && (stat % 2) == 1)
            {
                return Convert.ToInt16((double)((stat - 10) / 2) - 1);
            }
            else
            {
                return Convert.ToInt16((double)((stat - 10) / 2));
            }
        }

        public Skill getStatMod(string name, short coreStat, short? mod = 0)
        {
            if (mod != 0 && mod != null)
            {
                return new Skill(mod, name);
            }
            else
            {
                return new Skill(coreStat, name);
            }
        }

        public static List<Spell> getValidSpellsByClass(string className)
        {
            List<Spell> outSpells = new List<Spell>();
            foreach (Spell currentSpell in Program.storage.spellList)
            {
                if (currentSpell.class_list.Contains(className.ToLower()))
                {
                    outSpells.Add(currentSpell);
                }
            }
            return outSpells;
        }

        public Spell getSpellByName(string name)
        {
            foreach(Spell s in Program.storage.spellList)
            {
                if(s.name == name) { return s; }
            }
            throw new Exception("Spell not found");
        }
        #endregion

        public abstract class Character
        {
            public String       name
                               ,alignment
                               ,spellcastingStat
                               ,misc
                               ,equipment
                               ,proficiencies
                               ,traits
                               ,speed;
            public List<String> savingThrows
                               ,immunities     
                               ,resistances    
                               ,vulnerabilities
                               ,languages;
            public List<Weapon> weapons;
            public Armor        armor;
            public short[]      stats
                               ,statMods;  
            public Boolean      hasShield;
            public short ac
                               , health
                               , hitDiceSides
                               , hitDice;

            protected Character(string speed, string spellcastingStat, string proficiencies, List<String> savingThrows, short hitDiceSides)
            {
                this.spellcastingStat = spellcastingStat;
                this.proficiencies = proficiencies;
                this.savingThrows = savingThrows;
                this.hitDiceSides = hitDiceSides;
                this.speed = speed;
            }

            protected Character()
            {

            }

            protected Character(string name, short[] statRolls, string speed, List<Weapon> weapons, Armor armor, string alignment, string equipment, List<string> languages, List<string> resistances, string spellcastingStat, string proficiencies, short hitDiceSides, List<string> savingThrows, string traits)
            {
                this.name = name;
                stats = statRolls;
                statMods = Program.catalog.calcModifiers(stats);
                this.speed = speed;
                this.weapons = weapons;
                this.armor = armor;
                this.alignment = alignment;
                this.equipment = equipment;
                this.languages = languages;
                this.resistances = resistances;
                this.spellcastingStat = spellcastingStat;
                this.proficiencies = proficiencies;
                this.hitDiceSides = hitDiceSides;
                hitDice = 1;
                this.savingThrows = savingThrows;
                this.traits = traits;
            }
        }
    
        public class PlayerCharacter : Character
        {
            public List<Spell> validSpells, knownSpells = new List<Spell>();
            public string className, raceName, notes = "None Set";
            public short level = 1;
            public short[] money = new short[5];

            public PlayerCharacter(string name, short[] statRolls, string className, string raceName, string speed, List<Weapon> weapons, Armor armor, string alignment, string equipment, List<string> languages, List<string> resistances, string spellcastingStat, string proficiencies, short hitDiceSides, List<string> savingThrows, string traits)
                             : base(name, statRolls, speed, weapons, armor, alignment, equipment, languages, resistances, spellcastingStat, proficiencies, hitDiceSides, savingThrows, traits)
            {
                stats = statRolls;
                this.className = className;
                this.raceName = raceName;
                this.speed = speed;
                this.name = name;
                this.weapons = weapons;
                this.armor = armor;
                this.alignment = alignment;
                this.equipment = equipment;
                this.languages = languages;
                this.resistances = resistances;
                this.traits = traits;
                calcAC();
                calcHealth();
            }

            private void calcAC()
            {
                // Check this.armor exists
                if (!(armor == null))
                {
                    ac = armor.getAC(stats[1]);
                }
                else
                {
                    ac = Convert.ToInt16(10 + statMods[1]);
                }
                if (hasShield)
                {
                    ac += 2;
                }
            }

            private void calcHealth()
            {
                health = Convert.ToInt16(hitDiceSides + (((hitDiceSides / 2) + 1) * (level - 1)) + statMods[2]);
            }

            public void setKnownSpells(List<Spell> newSpells)
            {
                knownSpells = newSpells;
            }

            public void addSpell(Spell spell)
            {
                knownSpells.Add(spell);
            }
        }

        public class CreatureCharacter : Character
        {
            public short? hitPoints, armorClass, initiative, passivePerception, rawStr, rawCon, rawDex, rawInt, rawWis, rawCha, strSave, conSave, dexSave, intSave, wisSave, chaSave;
            public decimal challengeRating;
            public List<string> damageVulns, damageRes, damageImm, conditionImm, senses;
            public string type, subtype, size;
            public List<Attack> attacks;
            public List<SpecialAbility> legendaryActions, specialAbilities;
            public List<Skill> skills;

            public CreatureCharacter(): base()
            {
                damageImm = new List<string>();
                conditionImm = new List<string>();
                damageRes = new List<string>();
                damageVulns = new List<string>();
                senses = new List<string>();
                attacks = new List<Attack>();
                legendaryActions = new List<SpecialAbility>();
                specialAbilities = new List<SpecialAbility>();
                skills = new List<Skill>();
                languages = new List<string>();
            }
        }

        public class Attack
        {
            public string name, desc, dice;
            public short? atkBonus, dmgBonus;

            public Attack()
            {

            }

            public Attack(string name, string desc, string dice, short atkBonus, short dmgBonus)
            {
                this.name = name;
                this.desc = desc;
                this.dice = dice;
                this.atkBonus = atkBonus;
                this.dmgBonus = dmgBonus;
            }
        }

        public class SpecialAbility
        {
            public string name, desc;

            public SpecialAbility()
            {

            }

            public SpecialAbility(string name, string desc)
            {
                this.name = name;
                this.desc = desc;
            }
        }

        public class Skill
        {
            public short? mod;
            public string skill;

            public Skill(short? mod, string skill)
            {
                this.mod = mod;
                this.skill = skill;
            }
        }

        public class Weapon
        {
            public short damageDiceSides, numDamageDice, quantity;
            public List<String> propertyList = new List<string>();
            public String damageType, name;

            public Weapon(String name, short damageDiceSides, short numDamageDice, List<string> propertyList, string damageType)
            {
                this.name = name;
                this.damageDiceSides = damageDiceSides;
                this.numDamageDice = numDamageDice;
                this.propertyList = propertyList;
                this.damageType = damageType;
                quantity = 1;
            }

            public string getDmgString()
            {
                return $"{numDamageDice}d{damageDiceSides} {damageType}";
            }
        }
    
        public class Armor
        {
            public string name;
            public short baseAC, dexLimit;
            public bool givesStealthDisadvantage;

            public Armor(string name, short dexLimit, short baseAC, bool givesStealthDisadvantage)
            {
                this.name = name;
                this.dexLimit = dexLimit;
                this.baseAC = baseAC;
                this.givesStealthDisadvantage = givesStealthDisadvantage;
            }

            public short getAC(short dex)
            {
                return Convert.ToInt16(baseAC + Math.Min(dex, dexLimit));
            }
        }
    
        public class Spell
        {
            public short level;
            public string name, casting_time, components, description, duration, range, school;
            public List<string> class_list;
            public bool ritual;

            public Spell() { }
        }

        public Weapon findWeapon(String name)
        {
            foreach(Weapon weap in weapons)
            {
                if(weap.name == name) { return weap; }
            }
            return null;
        }

        public Armor findArmor(String name)
        {
            foreach (Armor arm in armorList)
            {
                if (arm.name == name) { return arm; }
            }
            return null;
        }
    }
}
