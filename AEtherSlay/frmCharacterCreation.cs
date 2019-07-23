using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AEtherSlay
{

    public partial class frmCharacterCreation : Form
    {
        #region Variable Declarations

        Catalog.PlayerCharacter player;

        Random rand = new Random();
        TextBox[] coreStatBoxes;
        TextBox[] statModifierBoxes;
        bool changedByClick = false, useIRA = true;


        int forcedClass = -1, forcedRace = -1, forcedCategory = -1;

        short[] statRolls = new Int16[6],
                statMods  = new Int16[6];
        short   ac = 0, health = 0, hitDiceSides = 0;
        bool hasShield = false;
        string className, raceName, spellcastingStat, alignment, speed = "30ft.";
        List<Catalog.Armor> possibleArmors = new List<Catalog.Armor>();

        List<String> proficiencies = new List<String>()
                    ,languages = new List<String>()
                    ,savingThrows = new List<String>()
                    ,traits = new List<String>()
                    ,resistances = new List<String>()
                    ,equipment = new List<String>();

        List<Catalog.Weapon> primaryWeaponChoices = new List<Catalog.Weapon>()
                            ,secondaryWeaponChoices = new List<Catalog.Weapon>();
        List<String> preferredStatsIRA = new List<string>() { };
        #endregion

        private void cbArmor1_Click(object sender, EventArgs e)
        {
            changedByClick = true;
        }

        public String chooseFromList(List<String> packChoices)
        {
            return packChoices[rand.Next(0, packChoices.Count)];
        }

        public frmCharacterCreation(int optCategory = -1, int optClass = -1, int optRace = -1, bool optIRA = false)
        {
            InitializeComponent();

            // MessageBox.Show("This form was instantiated with the following parameters\nCategory: " + optCategory + "\nClass: " + optClass + "\nRace: " + optRace);

            coreStatBoxes     = new TextBox[] { txtStr, txtCon, txtDex, txtInt, txtWis, txtCha };
            statModifierBoxes = new TextBox[] { txtStrMod, txtConMod, txtDexMod, txtIntMod, txtWisMod, txtChaMod };

            forcedCategory = optCategory;
            forcedClass = optClass;
            forcedRace = optRace;
            useIRA = optIRA;

            generateCharacter();
        }

        private void generateCharacter()
        {
            #region Generate Class
            int classNum = rand.Next(12);

            #region Overwrite ClassNum
            List<int> classPool = new List<int>() { -1 };
            if (forcedCategory != -1)
            {
                switch (forcedCategory)
                {
                    case 0:
                        classPool = new List<int>() { 7, 9, 10, 11 };
                        break;
                    case 1:
                        classPool = new List<int>() { 0, 2, 3, 4, 5, 6, 8 };
                        break;
                    case 2:
                        classPool = new List<int>() { 9, 10, 11 };
                        break;
                    case 3:
                        classPool = new List<int>() { 1, 2, 6, 7 };
                        break;
                    default:
                        classPool = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
                        break;
                }
                classNum = classPool[rand.Next(0, classPool.Count)];
            }
            else if (forcedClass != -1)
            {
                classNum = forcedClass;
            }
            #endregion

            switch (classNum)
            {
                case 0:
                    className = "Barbarian";
                    spellcastingStat = "NONE";
                    proficiencies.AddRange(new List<string>() { "Light Armor", "Medium Armor", "Shields", "Simple Weapons", "Martial Weapons" });
                    savingThrows.AddRange(new List<string>() { "Strength", "Constitution" });
                    hitDiceSides = 12;
                    preferredStatsIRA = new List<string> { "STR", "DEX", "CON" };
                    break;

                case 1:
                    className = "Bard";
                    spellcastingStat = "Charisma";
                    proficiencies.AddRange(new List<string>() { "Light Armor", "Simple Weapons", "Hand Crossbows", "Longswords", "Rapiers", "Shortswords" });
                    savingThrows.AddRange(new List<string>() { "Dexterity", "Charisma" });
                    hitDiceSides = 8;
                    preferredStatsIRA = new List<string> { "CHA", "WIS" };
                    break;

                case 2:
                    className = "Cleric";
                    spellcastingStat = "Wisdom";
                    proficiencies.AddRange(new List<string>() { "Light Armor", "Medium Armor", "Shields", "Simple Weapons" });
                    savingThrows.AddRange(new List<string>() { "Charisma", "Wisdom" });
                    hitDiceSides = 8;
                    preferredStatsIRA = new List<string> { "WIS", "CHA" };
                    break;

                case 3:
                    className = "Druid";
                    spellcastingStat = "Wisdom";
                    proficiencies.AddRange(new List<string>() { "Light Armor", "Medium Armor (nonmetal)", "Shields (nonmetal)", "Clubs", "Daggers", "Darts", "Javelins", "Maces", "Quarterstaffs", "Scimitars", "Sickles", "Slings", "Spears" });
                    savingThrows.AddRange(new List<string>() { "Intelligence", "Wisdom" });
                    hitDiceSides = 8;
                    preferredStatsIRA = new List<string> { "WIS", "INT" };
                    break;

                case 4:
                    className = "Fighter";
                    spellcastingStat = "Intelligence";
                    proficiencies.AddRange(new List<string>() { "Light Armor", "Medium Armor", "Heavy Armor", "Shields", "Simple Weapons", "Martial Weapons" });
                    savingThrows.AddRange(new List<string>() { "Strength", "Constitution" });
                    hitDiceSides = 10;
                    preferredStatsIRA = new List<string> { "STR", "DEX" };
                    break;

                case 5:
                    className = "Monk";
                    spellcastingStat = "Wisdom";
                    proficiencies.AddRange(new List<string>() { "Simple Weapons", "Shortswords" });
                    savingThrows.AddRange(new List<string>() { "Dexterity", "Strength" });
                    hitDiceSides = 8;
                    preferredStatsIRA = new List<string> { "DEX", "WIS" };
                    break;

                case 6:
                    className = "Paladin";
                    spellcastingStat = "Charisma";
                    proficiencies.AddRange(new List<string>() { "Light Armor", "Medium Armor", "Heavy Armor", "Shields", "Simple Weapons", "Martial Weapons" });
                    savingThrows.AddRange(new List<string>() { "Charisma", "Wisdom" });
                    hitDiceSides = 10;
                    preferredStatsIRA = new List<string> { "STR", "CHA" };
                    break;

                case 7:
                    className = "Ranger";
                    spellcastingStat = "Wisdom";
                    proficiencies.AddRange(new List<string>() { "Light Armor", "Medium Armor", "Shields", "Simple Weapons", "Martial Weapons" });
                    savingThrows.AddRange(new List<string>() { "Strength", "Dexterity" });
                    hitDiceSides = 10;
                    preferredStatsIRA = new List<string> { "DEX", "WIS" };
                    break;

                case 8:
                    className = "Rogue";
                    spellcastingStat = "Intelligence";
                    proficiencies.AddRange(new List<string>() { "Light Armor", "Simple Weapons", "Hand Crossbows", "Longswords", "Rapiers", "Shortswords" });
                    savingThrows.AddRange(new List<string>() { "Dexterity", "Intelligence" });
                    hitDiceSides = 8;
                    preferredStatsIRA = new List<string> { "DEX" };
                    break;

                case 9:
                    className = "Sorcerer";
                    spellcastingStat = "Charisma";
                    proficiencies.AddRange(new List<string>() { "Daggers", "Darts", "Slings", "Quarterstaffs", "Light Crossbows" });
                    savingThrows.AddRange(new List<string>() { "Charisma", "Constitution" });
                    hitDiceSides = 6;
                    preferredStatsIRA = new List<string> { "CHA" };
                    break;

                case 10:
                    className = "Warlock";
                    spellcastingStat = "Charisma";
                    proficiencies.AddRange(new List<string>() { "Light Armor", "Simple Weapons" });
                    savingThrows.AddRange(new List<string>() { "Wisdom", "Charisma" });
                    hitDiceSides = 8;
                    preferredStatsIRA = new List<string> { "CHA" };
                    break;

                case 11:
                    className = "Wizard";
                    spellcastingStat = "Intelligence";
                    proficiencies.AddRange(new List<string>() { "Daggers", "Darts", "Slings", "Quarterstaffs", "Light Crossbows" });
                    savingThrows.AddRange(new List<string>() { "Wisdom", "Intelligence" });
                    hitDiceSides = 8;
                    preferredStatsIRA = new List<string> { "INT" };
                    break;

                default:
                    className = "Barbarian";
                    spellcastingStat = "NONE";
                    proficiencies.AddRange(new List<string>() { "Light Armor", "Medium Armor", "Shields", "Simple Weapons", "Martial Weapons" });
                    savingThrows.AddRange(new List<string>() { "Strength", "Constitution" });
                    hitDiceSides = 12;
                    break;
            }
            #endregion

            #region Core Stats
            // STR CON DEX INT WIS CHA
            // 0   1   2   3   4   5

            statRolls = Program.catalog.rollStats();
            ac = Convert.ToInt16(10 + ((statRolls[2] - 10) / 2));
            #region IRA
            if (useIRA)
            {
                List<short> sortedRolls = statRolls.ToList();
                statRolls = new short[6] { -1, -1, -1, -1, -1, -1 };
                sortedRolls.Sort();
                sortedRolls.Reverse();
                for(int i = 0; i < preferredStatsIRA.Count; i++)
                {
                    switch(preferredStatsIRA[i])
                    {
                        case "STR": statRolls[0] = sortedRolls[0]; break;
                        case "CON": statRolls[1] = sortedRolls[0]; break;
                        case "DEX": statRolls[2] = sortedRolls[0]; break;
                        case "INT": statRolls[3] = sortedRolls[0]; break;
                        case "WIS": statRolls[4] = sortedRolls[0]; break;
                        case "CHA": statRolls[5] = sortedRolls[0]; break;
                        default:    statRolls[i] = sortedRolls[0]; break;
                    }
                    sortedRolls.RemoveAt(0);
                }
                for(int i = 0; i < 6; i++)
                {
                    if(statRolls[i] < 0)
                    {
                        short indexOfStatRollToAssign = (short)rand.Next(0, sortedRolls.Count);
                        statRolls[i] = sortedRolls[indexOfStatRollToAssign];
                        sortedRolls.RemoveAt(indexOfStatRollToAssign);
                    }
                }
            }
            #endregion
            #endregion

            #region Generate Race
            int raceNum = rand.Next(14);

            if (forcedRace != -1)
            {
                raceNum = forcedRace;
            }

            switch (raceNum)
            {
                case 0:
                    raceName = "High Elf";
                    statRolls[2] += 2;
                    statRolls[3] += 1;
                    traits.AddRange(new List<String>() { "Darkvision", "Advantage on Saving Throws [Charm]", "No Magical Sleep", "Trance [4 hour long rest]", "Cantrip", "Additional Language" });
                    proficiencies.AddRange( new List<String>{ "Perception", "Longsword", "Shortsword", "Shortbow", "Longbow" });
                    languages.Add("Elvish");
                    break;

                case 1:
                    raceName = "Wood Elf";
                    statRolls[2] += 2;
                    statRolls[4] += 1;
                    speed = "35ft.";
                    traits.AddRange(new List<String>() { "Darkvision", "Advantage on Saving Throws [Charm]", "No Magical Sleep", "Trance [4 hour long rest]", "Mask Of The Wild" });
                    proficiencies.AddRange(new List<String> { "Perception", "Longsword", "Shortsword", "Shortbow", "Longbow" });
                    languages.Add("Elvish");
                    break;

                case 2:
                    raceName = "Hill Dwarf";
                    statRolls[1] += 2;
                    statRolls[4] += 1;
                    health += 1;
                    speed = "25ft.";
                    traits.AddRange( new List<String>() { "Darkvision", "Advantage on Saving Throws [Poison]", "Dwarven Toughness", "Tool Proficiency", "Stonecunning" });
                    proficiencies.AddRange(new List<String>() { "Battleaxe", "Handaxe", "Throwing Hammer", "Warhammer" });
                    languages.Add("Dwarvish");
                    resistances.Add("Poison");
                    break;

                case 3:
                    raceName = "Mountain Dwarf";
                    statRolls[1] += 2;
                    statRolls[0] += 2;
                    speed = "25ft.";
                    traits.AddRange(new List<String>() { "Darkvision", "Advantage on Saving Throws [Poison]", "Dwarven Toughness", "Tool Proficiency", "Stonecunning" });
                    proficiencies.AddRange(new List<String>() { "Battleaxe", "Handaxe", "Throwing Hammer", "Warhammer" });
                    if (!proficiencies.Contains("Light Armor")) { proficiencies.AddRange(new List<String>() { "Light Armor" }); }
                    if (!proficiencies.Contains("Medium Armor")) { proficiencies.AddRange(new List<String>() { "Medium Armor" }); }
                    languages.Add("Dwarvish");
                    resistances.Add("Poison");
                    break;

                case 4:
                    raceName = "Dark Elf";
                    statRolls[2] += 2;
                    statRolls[5] += 1;
                    traits.AddRange(new List<String>() { "Superior Darkvision", "Advantage on Saving Throws [Charm]", "No Magical Sleep", "Trance [4 hour long rest]", "Sunlight Sensitivity", "Drow Magic" });
                    proficiencies.AddRange(new List<String> { "Perception", "Rapier", "Shortsword", "Hand Crossbow" });
                    languages.Add("Elvish");
                    break;

                case 5:
                    raceName = "Lightfoot Halfling";
                    statRolls[2] += 2;
                    statRolls[5] += 1;
                    speed = "25ft.";
                    traits.AddRange(new List<String>() { "Lucky", "Brave", "Halfling Nimbleness", "Naturally Stealthy" });
                    languages.Add("Halfling");
                    break;

                case 6:
                    raceName = "Stout Halfling";
                    statRolls[2] += 2;
                    statRolls[1] += 1;
                    speed = "25ft.";
                    traits.AddRange(new List<String>() { "Lucky", "Brave", "Halfling Nimbleness", "Poison Resistance", "Advantage Saving Throws Poison" });
                    languages.Add("Halfling");
                    break;

                case 7:
                    raceName = "Human";
                    for (Int16 i = 0; i < 6; i++) { statRolls[i] += 1; }
                    Int32 langNum = rand.Next(Catalog.languages.Count); // TODO: Change to Catalog.languages.Count
                    languages.Add(Catalog.languages[langNum]);
                    break;

                case 8:
                    raceName = "Dragonborn";
                    statRolls[0] += 2;
                    statRolls[5] += 1;
                    #region Determine Ancestry
                    List<String> possibleAncestries = new List<string>() { "Black", "Blue", "Brass", "Bronze", "Copper", "Gold", "Green", "Red", "Silver", "White" };
                    List<String> ancestryElement = new List<string>() { "Acid", "Lightning", "Fire", "Lightning", "Acid", "Fire", "Poison", "Fire", "Cold", "Cold" };
                    Int32 ancestryNum = rand.Next(possibleAncestries.Count);
                    String ancestryType = possibleAncestries[ancestryNum];
                    String breathWeapon;
                    if(new List<String>() { "Black", "Blue", "Brass", "Bronze", "Copper" }.Contains(ancestryType)) { breathWeapon = "5 by 30 ft. line (Dex. save)"; }
                    else if(new List<String>() { "Gold", "Red" }.Contains(ancestryType)) { breathWeapon = "15 ft. cone (Dex. save)"; }
                    else { breathWeapon = "15 ft. cone (Con. save)"; }
                    traits.Add("Draconic Ancestry: " + ancestryType);
                    traits.Add("Breath Weapon: " + breathWeapon + " dealing 2d6");
                    resistances.Add(ancestryElement[ancestryNum]);
                    #endregion
                    languages.Add("Draconic");
                    break;

                case 9:
                    raceName = "Forest Gnome";
                    statRolls[3] += 2;
                    statRolls[2] += 1;
                    languages.Add("Gnomish");
                    traits.AddRange(new List<String>() { "Darkvision", "Gnome Cunning", "Natural Illusionist", "Speak w/Small Beasts" });
                    break;

                case 10:
                    raceName = "Rock Gnome";
                    statRolls[3] += 2;
                    statRolls[1] += 1;
                    languages.Add("Gnomish");
                    traits.AddRange(new List<String>() { "Darkvision", "Gnome Cunning", "Artificer's Lore", "Tinker" });
                    break;

                case 11:
                    raceName = "Half-Elf";
                    statRolls[5] += 2;
                    int a = 0, b = 0;
                    while (a == b) {
                        a = rand.Next(0, 5);
                        b = rand.Next(0, 5);
                    }
                    statRolls[a] += 1;
                    statRolls[b] += 1;
                    languages.Add("Elvish");
                    traits.AddRange(new List<String>() { "Darkvision", "Fey Ancestry", "Skill Versatility" });
                    break;

                case 12:
                    raceName = "Half Orc";
                    statRolls[0] += 2;
                    statRolls[1] += 1;
                    languages.Add("Orc");
                    traits.AddRange(new List<String>() { "Darkvision", "Relentless Endurance", "Savage Attacks" });
                    proficiencies.Add("Intimidation");
                    break;

                case 13:
                    raceName = "Tiefling";
                    statRolls[3] += 1;
                    statRolls[5] += 2;
                    traits.AddRange(new List<String>() { "Darkvision", "Infernal Legacy" });
                    resistances.Add("Fire");
                    languages.Add("Infernal");
                    break;

                default:
                    raceName = "ERROR";
                    break;
            }
            #endregion

            #region Add Class Particulars

            List<String> possiblePacks = new List<string>();
            switch (classNum)
            {
                case 0: //BARBARIAN
                    equipment.Add("4x Javelin");
                    possiblePacks.Add("Explorer's Pack");
                    primaryWeaponChoices.AddRange(Program.catalog.martialMelee);
                    secondaryWeaponChoices.Add(Program.catalog.findWeapon("Handaxe"));
                    secondaryWeaponChoices.AddRange(Program.catalog.simpleMelee);
                    break;
                case 1: //BARD
                    equipment.Add("Lute");
                    possiblePacks.Add("Diplomat's Pack");
                    possiblePacks.Add("Entertainer's Pack");
                    primaryWeaponChoices.AddRange(Program.catalog.simpleMelee);
                    primaryWeaponChoices.Add(Program.catalog.findWeapon("Longsword"));
                    primaryWeaponChoices.Add(Program.catalog.findWeapon("Rapier"));
                    secondaryWeaponChoices.Add(Program.catalog.findWeapon("Dagger"));
                    possibleArmors.Add(Program.catalog.findArmor("Leather"));
                    break;
                case 2: //CLERIC
                    equipment.Add("Holy Symbol");
                    possiblePacks.Add("Priest's Pack");
                    possiblePacks.Add("Explorer's Pack");
                    primaryWeaponChoices.Add(Program.catalog.findWeapon("Mace"));
                    if(proficiencies.Contains("Warhammer"))
                    {
                        primaryWeaponChoices.Add(Program.catalog.findWeapon("Warhammer"));
                    }
                    secondaryWeaponChoices.Add(Program.catalog.findWeapon("Crossbow [Light]"));
                    equipment.Add("20x Bolts");
                    secondaryWeaponChoices.AddRange(Program.catalog.simple);
                    possibleArmors.Add(Program.catalog.findArmor("Leather"));
                    possibleArmors.Add(Program.catalog.findArmor("Scale Mail"));
                    if(proficiencies.Contains("Chain Mail"))
                    {
                        possibleArmors.Add(Program.catalog.findArmor("Chain Mail"));
                    }
                    hasShield = true;
                    break;
                case 3: //DRUID
                    equipment.Add("Druidic Focus" );
                    possiblePacks.Add("Explorer's Pack");
                    possibleArmors.Add(Program.catalog.findArmor("Leather"));
                    hasShield = true;
                    primaryWeaponChoices.AddRange(Program.catalog.simple);
                    secondaryWeaponChoices.Add(Program.catalog.findWeapon("Scimitar"));
                    secondaryWeaponChoices.AddRange(Program.catalog.simpleMelee);
                    break;
                case 4: //FIGHTER
                    if (rand.Next(3) == 2) { possibleArmors.Add(Program.catalog.findArmor("Chain Mail")); }
                    else {
                        possibleArmors.Add(Program.catalog.findArmor("Leather"));
                        // primaryWeaponChoices.Add(Program.catalog.findWeapon("Longbow"));
                        equipment.Add("20 Arrows");
                    }
                    primaryWeaponChoices.AddRange(Program.catalog.martial);
                    if(rand.Next(3) == 2) { secondaryWeaponChoices.AddRange(Program.catalog.martial); }
                    else { hasShield = true;  }
                    if (rand.Next(3) == 2) { equipment.Add("Light Crossbow + 20 Bolts"); }
                    else { equipment.Add("2 x Handaxe"); }
                    possiblePacks.Add("Explorer's Pack");
                    possiblePacks.Add("Dungeoneer's Pack");
                    break;
                case 5: //MONK
                    primaryWeaponChoices.AddRange(Program.catalog.simple);
                    primaryWeaponChoices.Add(Program.catalog.findWeapon("Shortsword"));
                    secondaryWeaponChoices.Add(Program.catalog.findWeapon("Dart"));
                    possiblePacks.Add("Explorer's Pack");
                    possiblePacks.Add("Dungeoneer's Pack");
                    break;
                case 6: //PALADIN
                    primaryWeaponChoices.AddRange(Program.catalog.martial);
                    primaryWeaponChoices.AddRange(Program.catalog.simple);
                    if (rand.Next(1, 3) == 2) { hasShield = true; }
                    else {
                        secondaryWeaponChoices.AddRange(Program.catalog.martial);
                        secondaryWeaponChoices.AddRange(Program.catalog.simple);
                    }
                    possibleArmors.Add(Program.catalog.findArmor("Chain Mail"));
                    equipment.Add("Holy Symbol");
                    equipment.Add("5x Javelin");
                    possiblePacks.Add("Priest's Pack");
                    possiblePacks.Add("Explorer's Pack");
                    break;
                case 7: //RANGER
                    primaryWeaponChoices.Add(Program.catalog.findWeapon("Longbow"));
                    secondaryWeaponChoices.AddRange(Program.catalog.simpleMelee);
                    secondaryWeaponChoices.Add(Program.catalog.findWeapon("Shortsword"));
                    possibleArmors.Add(Program.catalog.findArmor("Scale Mail"));
                    possibleArmors.Add(Program.catalog.findArmor("Leather"));
                    equipment.Add("20x Arrows");
                    possiblePacks.Add("Explorer's Pack");
                    possiblePacks.Add("Dungeoneer's Pack");
                    break;
                case 8: //ROGUE
                    primaryWeaponChoices.Add(Program.catalog.findWeapon("Rapier"));
                    primaryWeaponChoices.Add(Program.catalog.findWeapon("Shortsword"));
                    secondaryWeaponChoices.Add(Program.catalog.findWeapon("Shortbow"));
                    secondaryWeaponChoices.Add(Program.catalog.findWeapon("Shortsword"));
                    int packNum = rand.Next(1, 4);
                    possiblePacks.Add("Explorer's Pack");
                    possiblePacks.Add("Dungeoneer's Pack");
                    possiblePacks.Add("Burglar's Pack");
                    possibleArmors.Add(Program.catalog.findArmor("Leather"));
                    equipment.Add("Thieves' Tools");
                    break;
                case 9: //SORCERER
                    primaryWeaponChoices.AddRange(Program.catalog.simple);
                    equipment.Add("20 Bolts");
                    secondaryWeaponChoices.Add(Program.catalog.findWeapon("Dagger"));
                    if (rand.Next(1, 3) == 2) { equipment.Add("Component Pouch"); }
                    else { equipment.Add("Arcane Focus"); }
                    possiblePacks.Add("Explorer's Pack");
                    possiblePacks.Add("Dungeoneer's Pack");
                    break;
                case 10: //WARLOCK
                    primaryWeaponChoices.Add(Program.catalog.findWeapon("Crossbow [Light]"));
                    primaryWeaponChoices.AddRange(Program.catalog.simple);
                    equipment.Add("20 Bolts");
                    secondaryWeaponChoices.Add(Program.catalog.findWeapon("Dagger"));
                    if (rand.Next(1, 3) == 2) { equipment.Add("Component Pouch"); }
                    else { equipment.Add("Arcane Focus"); }
                    possiblePacks.Add("Explorer's Pack");
                    possiblePacks.Add("Dungeoneer's Pack");
                    break;
                case 11: //WIZARD
                    primaryWeaponChoices.Add(Program.catalog.findWeapon("Quarterstaff"));
                    primaryWeaponChoices.Add(Program.catalog.findWeapon("Dagger"));
                    if (rand.Next(1, 3) == 2) { equipment.Add("Component Pouch"); }
                    else { equipment.Add("Arcane Focus"); }
                    possiblePacks.Add("Explorer's Pack");
                    possiblePacks.Add("Scholar's Pack");
                    equipment.Add("Spellbook");
                    break;
                default:
                    proficiencies.Add("CLASS NOT FULLY IMPLEMENTED YET");
                    break;

            }
            equipment.Add(chooseFromList(possiblePacks));
            #endregion

            #region Generate Alignment
            switch (rand.Next(9))
            {
                case 0:
                    alignment = "Lawful Good";
                    break;
                case 1:
                    alignment = "Neutral Lawful";
                    break;
                case 2:
                    alignment = "Lawful Evil";
                    break;
                case 3:
                    alignment = "Neutral Good";
                    break;
                case 4:
                    alignment = "True Neutral";
                    break;
                case 5:
                    alignment = "Neutral Evil";
                    break;
                case 6:
                    alignment = "Chaotic Good";
                    break;
                case 7:
                    alignment = "Chaotic Neutral";
                    break;
                case 8:
                    alignment = "Chaotic Evil";
                    break;
                default:
                    alignment = "True Neutral";
                    break;
            }
            #endregion

            #region Display Character Info
            try
            {
                statMods = Program.catalog.calcModifiers(statRolls);

                Int16 i = 0;
                foreach (TextBox box in statModifierBoxes)
                {
                    //REMOVED BECAUSE MESSES WITH SAVING CHARACTERS
                    //if (statRolls[i] > 11)
                    //{
                    //    box.Text = "+";
                    //}
                    //else if (statRolls[i] == 10 || statRolls[i] == 9 || statRolls[i] == 11)
                    //{
                    //    box.Text += "±";
                    //}
                    box.Text = statMods[i].ToString();
                    i++;
                }

                i = 0;
                foreach (TextBox box in coreStatBoxes)
                {
                    box.Text = statRolls[i].ToString();
                    i++;
                }

                txtRace.Text = raceName;
                txtClass.Text = className;
                txtProf.Text = "2";
                txtSpeed.Text = speed.ToString();
                txtAC.Text = ac.ToString();
                lblAlignment.Text = alignment;
                txtInit.Text = txtDexMod.Text;
                txtHP.Text = (hitDiceSides + ((statRolls[2] - 10) / 2)).ToString();

                bindWeaponComboBox(cbWeapon1, primaryWeaponChoices);
                bindWeaponComboBox(cbWeapon2, secondaryWeaponChoices);

                if (primaryWeaponChoices.Count == 1) { cbWeapon1.SelectedIndex = 0; }
                if (secondaryWeaponChoices.Count == 1) { cbWeapon2.SelectedIndex = 0; }

                bindArmorComboBox(cbArmor1, possibleArmors);

                if (possibleArmors.Count == 1) { cbArmor1.SelectedIndex = 0; }
                if (hasShield)
                {
                    cbArmor2.Items.Add("Shield");
                    cbArmor2.SelectedItem = "Shield";
                }

                rtbProficiencies.Text = "PROFICIENCIES\n\n";
                foreach (String prof in proficiencies) { rtbProficiencies.Text += prof + "\n"; }

                rtbTraits.Text = "TRAITS\n\n";
                foreach (String trait in traits) { rtbTraits.Text += trait + "\n"; }

                rtbLanguages.Text = "LANGUAGES\n\n";
                foreach (String language in languages) { rtbLanguages.Text += language + "\n"; }

                rtbEquipment.Text = "EQUIPMENT\n\n";
                foreach (String equip in equipment) { rtbEquipment.Text += equip + "\n"; }

            } catch(Exception ex)
            {
                MessageBox.Show("There has been an issue, please try again" + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            detailsChanged();
            #endregion
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void detailsChanged()
        {
            changedByClick = false;
            Catalog.Armor ar = Program.catalog.findArmor(cbArmor1.Text);
            int outAC = 10 + ((statRolls[1] - 10) / 2);
            try
            {
                outAC = ar.getAC((short)((statRolls[1] - 10) / 2));
            } catch { }
            if(hasShield) { outAC += 2; }
            ac = Convert.ToInt16(outAC);
            txtAC.Text = ac.ToString();
        }

        private void cbArmor1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (changedByClick) { detailsChanged(); }
        }

        private void BtnRegenerate_Click(object sender, EventArgs e)
        {
            frmCharacterDialog newFrm = new frmCharacterDialog();
            newFrm.Show();
            this.Close();
        }

        private void BtnAddCharbtnAddChar_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() != "")
            {
                try
                {
                    Catalog.Armor armor;
                    List<Catalog.Weapon> weapons = new List<Catalog.Weapon>();
                    String name = txtName.Text;
                    if (cbWeapon1.SelectedIndex != -1)
                    {
                        weapons.Add((Catalog.Weapon)(((ComboboxItem)cbWeapon1.SelectedItem).Value));
                    }
                    if (cbWeapon2.SelectedIndex != -1)
                    {
                        //weapons.Add(Program.catalog.findWeapon((String)cbWeapon2.Text));
                        weapons.Add((Catalog.Weapon)(((ComboboxItem)cbWeapon2.SelectedItem).Value));
                    }
                    armor = Program.catalog.findArmor((string)cbArmor1.Text);

                    string equipString = "", traitString = "", profString = "";
                    foreach(string equip in equipment)
                    {
                        equipString += $"${equip}\n";
                    }
                    foreach (string trait in traits)
                    {
                        traitString += $"${trait}\n";
                    }
                    foreach (string prof in proficiencies)
                    {
                        profString += $"${prof}\n";
                    }

                    player = new Catalog.PlayerCharacter(name, statRolls, className, raceName, speed, weapons, armor, alignment, equipString, languages, resistances, spellcastingStat, profString, hitDiceSides, savingThrows, traitString);
                    Program.storage.addCharacterSheet(player);
                    MessageBox.Show("Success!", "Character Created!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } catch
                {
                    MessageBox.Show("Error", "Error creating a character. Please try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("Error: No Name", "Please input a name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bindWeaponComboBox(ComboBox combobox, List<Catalog.Weapon> weapons )
        {
            foreach( Catalog.Weapon weap in weapons)
            {
                ComboboxItem cmbItem = new ComboboxItem();
                if(weap.quantity > 1)
                {
                    cmbItem.Text = $"{weap.quantity} x {weap.name}";
                } else
                {
                    cmbItem.Text = weap.name;
                }
                
                cmbItem.Value = weap;

                combobox.Items.Add(cmbItem);
            }
        }

        private void bindArmorComboBox(ComboBox combobox, List<Catalog.Armor> armors)
        {
            foreach (Catalog.Armor arm in armors)
            {
                ComboboxItem cmbItem = new ComboboxItem();
                cmbItem.Text = arm.name;
                cmbItem.Value = arm;

                combobox.Items.Add(cmbItem);
            }
        }
    }
}
