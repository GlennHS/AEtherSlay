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

    public partial class frmCharacter : Form
    {
        #region Variable Declarations
        Random rand = new Random();
        TextBox[] coreStatBoxes;
        TextBox[] statModifierBoxes;
        Boolean changedByClick = false, useIRA = false;

        Int32[] statRolls = new Int32[6];
        Int32 ac, health = 0;
        Int16 speed = 30;
        Boolean hasShield = false;
        int forcedClass = -1, forcedRace = -1, forcedCategory = -1;
        List<String>
            weapons = new List<string>(),
            secondaryWeapons = new List<string>(),
            armors = new List<string>(),
            simpleMelee = new List<string>() {
                    "Club",
                    "Dagger",
                    "Greatclub",
                    "Handaxe",
                    "Javelin",
                    "Light Hammer",
                    "Mace",
                    "Quarterstaff",
                    "Sickle",
                    "Spear",
                    "Unarmed Strike"
            }, simpleRanged = new List<String>() {
                    "Crossbow [light]",
                    "Dart",
                    "Shortbow",
                    "Sling"
            }, martialMelee = new List<String>() {
                    "Battleaxe",
                    "Flail",
                    "Glaive",
                    "Greataxe",
                    "Greatsword",
                    "Halberd",
                    "Lance",
                    "Longsword",
                    "Maul",
                    "Morningstar",
                    "Pike",
                    "Rapier",
                    "Scimitar",
                    "Shortsword",
                    "Trident",
                    "War Pick",
                    "Warhammer",
                    "Whip"
            }, martialRanged = new List<string>()
            {
                    "Blowgun",
                    "Crossbow [hand]",
                    "Crossbow [heavy]",
                    "Longbow",
                    "Net"
            },
            simple,
            martial,
            lightArmor = new List<string>()
            {
                    "Padded",
                    "Leather",
                    "Studded Leather"
            },
            mediumArmor = new List<string>()
            {
                    "Hide",
                    "Chain Shirt",
                    "Scale Mail",
                    "Breastplate",
                    "Half Plate",
            },
            heavyArmor = new List<string>()
            {
                    "Ring Mail",
                    "Chain Mail",
                    "Splint",
                    "Plate"
            },
            armor,
            languages = new List<String>()
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
            },
            preferredStatsIRA = new List<string>() { };
        #endregion

        private void cbArmor1_Click(object sender, EventArgs e)
        {
            changedByClick = true;
        }

        public String choosePack(List<String> packChoices)
        {
            return packChoices[rand.Next(0, packChoices.Count)];
        }

        public frmCharacter(int optCategory = -1, int optClass = -1, int optRace = -1, bool optIRA = false)
        {
            InitializeComponent();

            // MessageBox.Show("This form was instantiated with the following parameters\nCategory: " + optCategory + "\nClass: " + optClass + "\nRace: " + optRace);

            coreStatBoxes     = new TextBox[] { txtStr, txtCon, txtDex, txtInt, txtWis, txtCha };
            statModifierBoxes = new TextBox[] { txtStrMod, txtConMod, txtDexMod, txtIntMod, txtWisMod, txtChaMod };
            simple = simpleMelee;
            martial = martialMelee;
            armor = lightArmor;

            forcedCategory = optCategory;
            forcedClass = optClass;
            forcedRace = optRace;
            useIRA = optIRA;

            armor.AddRange(mediumArmor);
            armor.AddRange(heavyArmor);

            simple.AddRange(simpleRanged);
            martial.AddRange(martialRanged);
            generateCharacter();
        }

        public class playerClass
        {
            public String name, spellcasting, alignment;
            public String[] savingThrows = new string[2];
            public List<String> proficiencies = new List<string>(), traits = new List<String>(), languages = new List<String>(), equipment = new List<String>();
            public short hitDiceSides;

            public playerClass(String name, String spellcasting, List<String> proficiencies, String[] savingThrows, short hitDiceSides)
            {
                this.name = name;
                this.spellcasting = spellcasting;
                this.proficiencies = proficiencies;
                this.savingThrows = savingThrows;
                this.hitDiceSides = hitDiceSides;
            }
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

            playerClass player;

            switch (classNum)
            {
                case 0:
                    player = new playerClass("Barbarian", "NONE", new List<string>() { "Light Armor", "Medium Armor", "Shields", "Simple Weapons", "Martial Weapons" }, new string[] { "Strength", "Constitution" }, 12);
                    preferredStatsIRA = new List<string>() { "STR", "CON", "DEX" };
                    break;
                case 1:
                    player = new playerClass("Bard", "Charisma", new List<string>() { "Light Armor", "Simple Weapons", "Hand Crossbows", "Longswords", "Rapiers", "Shortswords" }, new string[] { "Dexterity", "Charisma" }, 8);
                    preferredStatsIRA = new List<string>() { "CHA", "WIS", "CON" };
                    break;
                case 2:
                    player = new playerClass("Cleric", "Wisdom", new List<string>() { "Light Armor", "Medium Armor", "Shields", "Simple Weapons" }, new string[] { "Charisma", "Wisdom" }, 8);
                    preferredStatsIRA = new List<string>() { "WIS", "DEX" };
                    break;
                case 3:
                    player = new playerClass("Druid", "Wisdom", new List<string>() { "Light Armor", "Medium Armor (nonmetal)", "Shields (nonmetal)", "Clubs", "Daggers", "Darts", "Javelins", "Maces", "Quarterstaffs", "Scimitars", "Sickles", "Slings", "Spears" }, new string[] { "Intelligence", "Wisdom" }, 8);
                    preferredStatsIRA = new List<string>() { "WIS", "CON", "DEX" };
                    break;
                case 4:
                    player = new playerClass("Fighter", "Intelligence", new List<string>() { "Light Armor", "Medium Armor", "Heavy Armor", "Shields", "Simple Weapons", "Martial Weapons" }, new string[] { "Strength", "Constitution" }, 10);
                    preferredStatsIRA = new List<string>() { "STR", "DEX", "CON" };
                    break;
                case 5:
                    player = new playerClass("Monk", "Wisdom", new List<string>() { "Simple Weapons", "Shortswords" }, new string[] { "Dexterity", "Strength" }, 8);
                    preferredStatsIRA = new List<string>() { "WIS", "DEX", "CON" };
                    break;
                case 6:
                    player = new playerClass("Paladin", "Charisma", new List<string>() { "Light Armor", "Medium Armor", "Heavy Armor", "Shields", "Simple Weapons", "Martial Weapons" }, new string[] { "Charisma", "Wisdom" }, 10);
                    preferredStatsIRA = new List<string>() { "CHA", "STR", "CON" };
                    break;
                case 7:
                    player = new playerClass("Ranger", "Wisdom", new List<string>() { "Light Armor", "Medium Armor", "Shields", "Simple Weapons", "Martial Weapons" }, new string[] { "Strength", "Dexterity" }, 10);
                    preferredStatsIRA = new List<string>() { "DEX", "WIS" };
                    break;
                case 8:
                    player = new playerClass("Rogue", "Intelligence", new List<string>() { "Light Armor", "Simple Weapons", "Hand Crossbows", "Longswords", "Rapiers", "Shortswords" }, new string[] { "Dexterity", "Intelligence" }, 8);
                    preferredStatsIRA = new List<string>() { "DEX", "INT", "WIS" };
                    break;
                case 9:
                    player = new playerClass("Sorcerer", "Charisma", new List<string>() { "Daggers", "Darts", "Slings", "Quarterstaffs", "Light Crossbows" }, new string[] { "Charisma", "Constitution" }, 6);
                    preferredStatsIRA = new List<string>() { "CHA" };
                    break;
                case 10:
                    player = new playerClass("Warlock", "Charisma", new List<string>() { "Light Armor", "Simple Weapons" }, new string[] { "Wisdom", "Charisma" }, 8);
                    preferredStatsIRA = new List<string>() { "CHA" };
                    break;
                case 11:
                    player = new playerClass("Wizard", "Intelligence", new List<string>() { "Daggers", "Darts", "Slings", "Quarterstaffs", "Light Crossbows" }, new string[] { "Wisdom", "Intelligence" }, 8);
                    preferredStatsIRA = new List<string>() { "INT" };
                    break;
                default:
                    player = new playerClass("Barbarian", "NONE", new List<string>() { "Light Armor", "Medium Armor", "Shields", "Simple Weapons", "Martial Weapons" }, new string[] { "Strength", "Constitution" }, 12);
                    preferredStatsIRA = new List<string>() { "STR", "CON", "DEX" };
                    break;
            }
            #endregion

            #region Core Stats
            // STR CON DEX INT WIS CHA
            // 0   1   2   3   4   5

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
                statRolls[stat] = rolls.Sum();
            }
            ac = 10 + ((statRolls[2] - 10) / 2);
            #region IRA
            if (useIRA)
            {
                int[] sortedRolls = statRolls;
                statRolls = new int[6] { -1, -1, -1, -1, -1, -1 };
                Array.Sort(sortedRolls);
                Array.Reverse(sortedRolls);
                for(int i = 0; i < preferredStatsIRA.Count; i++)
                {
                    switch(preferredStatsIRA[i])
                    {
                        case "STR": statRolls[0] = sortedRolls[i]; break;
                        case "CON": statRolls[1] = sortedRolls[i]; break;
                        case "DEX": statRolls[2] = sortedRolls[i]; break;
                        case "INT": statRolls[3] = sortedRolls[i]; break;
                        case "WIS": statRolls[4] = sortedRolls[i]; break;
                        case "CHA": statRolls[5] = sortedRolls[i]; break;
                        default: statRolls[i] = sortedRolls[i]; break;
                    }
                    sortedRolls[i] = -1;
                }
                for(int i = 0; i < 6; i++)
                {
                    if(statRolls[i] < 0)
                    {
                        statRolls[i] = sortedRolls.Max();
                        sortedRolls[Array.IndexOf(sortedRolls, sortedRolls.Max())] = -1;
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

            String raceName;

            switch (raceNum)
            {
                case 0:
                    raceName = "High Elf";
                    statRolls[2] += 2;
                    statRolls[3] += 1;
                    player.traits.AddRange(new List<String>() { "Darkvision", "Advantage on Saving Throws [Charm]", "No Magical Sleep", "Trance [4 hour long rest]", "Cantrip", "Additional Language" });
                    player.proficiencies.AddRange( new List<String>{ "Perception", "Longsword", "Shortsword", "Shortbow", "Longbow" });
                    player.languages.Add("Elvish");
                    break;

                case 1:
                    raceName = "Wood Elf";
                    statRolls[2] += 2;
                    statRolls[4] += 1;
                    speed = 35;
                    player.traits.AddRange(new List<String>() { "Darkvision", "Advantage on Saving Throws [Charm]", "No Magical Sleep", "Trance [4 hour long rest]", "Mask Of The Wild" });
                    player.proficiencies.AddRange(new List<String> { "Perception", "Longsword", "Shortsword", "Shortbow", "Longbow" });
                    player.languages.Add("Elvish");
                    break;

                case 2:
                    raceName = "Hill Dwarf";
                    statRolls[1] += 2;
                    statRolls[4] += 1;
                    health += 1;
                    speed = 25;
                    player.traits.AddRange( new List<String>() { "Darkvision", "Advantage on Saving Throws [Poison]", "Poison Resistance", "Dwarven Toughness", "Tool Proficiency", "Stonecunning" });
                    player.proficiencies.AddRange(new List<String>() { "Battleaxe", "Handaxe", "Throwing Hammer", "Warhammer" });
                    player.languages.Add("Dwarvish");
                    break;

                case 3:
                    raceName = "Mountain Dwarf";
                    statRolls[1] += 2;
                    statRolls[0] += 2;
                    speed = 25;
                    player.traits.AddRange(new List<String>() { "Darkvision", "Advantage on Saving Throws [Poison]", "Poison Resistance", "Dwarven Toughness", "Tool Proficiency", "Stonecunning" });
                    player.proficiencies.AddRange(new List<String>() { "Battleaxe", "Handaxe", "Throwing Hammer", "Warhammer" });
                    if (!player.proficiencies.Contains("Light Armor")) { player.proficiencies.AddRange(new List<String>() { "Light Armor" }); }
                    if (!player.proficiencies.Contains("Medium Armor")) { player.proficiencies.AddRange(new List<String>() { "Medium Armor" }); }
                    player.languages.Add("Dwarvish");
                    break;

                case 4:
                    raceName = "Dark Elf";
                    statRolls[2] += 2;
                    statRolls[5] += 1;
                    player.traits.AddRange(new List<String>() { "Superior Darkvision", "Advantage on Saving Throws [Charm]", "No Magical Sleep", "Trance [4 hour long rest]", "Sunlight Sensitivity", "Drow Magic" });
                    player.proficiencies.AddRange(new List<String> { "Perception", "Rapier", "Shortsword", "Hand Crossbow" });
                    player.languages.Add("Elvish");
                    break;

                case 5:
                    raceName = "Lightfoot Halfling";
                    statRolls[2] += 2;
                    statRolls[5] += 1;
                    speed = 25;
                    player.traits.AddRange(new List<String>() { "Lucky", "Brave", "Halfling Nimbleness", "Naturally Stealthy" });
                    player.languages.Add("Halfling");
                    break;

                case 6:
                    raceName = "Stout Halfling";
                    statRolls[2] += 2;
                    statRolls[1] += 1;
                    speed = 25;
                    player.traits.AddRange(new List<String>() { "Lucky", "Brave", "Halfling Nimbleness", "Poison Resistance", "Advantage Saving Throws Poison" });
                    player.languages.Add("Halfling");
                    break;

                case 7:
                    raceName = "Human";
                    for (Int16 i = 0; i < 6; i++) { statRolls[i] += 1; }
                    Int32 langNum = rand.Next(languages.Count);
                    player.languages.Add(languages[langNum]);
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
                    player.traits.AddRange(new List<String>() { "Draconic Ancestry: " + ancestryType });
                    player.traits.AddRange(new List<String>() { "Breath Weapon: " + breathWeapon });
                    player.traits.AddRange(new List<String>() { "Elemental Resistance: " + ancestryElement[ancestryNum] });
                    #endregion
                    player.languages.Add("Draconic");
                    break;

                case 9:
                    raceName = "Forest Gnome";
                    statRolls[3] += 2;
                    statRolls[2] += 1;
                    player.languages.Add("Gnomish");
                    player.traits.AddRange(new List<String>() { "Darkvision", "Gnome Cunning", "Natural Illusionist", "Speak w/Small Beasts" });
                    break;

                case 10:
                    raceName = "Rock Gnome";
                    statRolls[3] += 2;
                    statRolls[1] += 1;
                    player.languages.Add("Gnomish");
                    player.traits.AddRange(new List<String>() { "Darkvision", "Gnome Cunning", "Artificer's Lore", "Tinker" });
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
                    player.languages.Add("Elvish");
                    player.traits.AddRange(new List<String>() { "Darkvision", "Fey Ancestry", "Skill Versatility" });
                    break;

                case 12:
                    raceName = "Half Orc";
                    statRolls[0] += 2;
                    statRolls[1] += 1;
                    player.languages.Add("Orc");
                    player.traits.AddRange(new List<String>() { "Darkvision", "Relentless Endurance", "Savage Attacks" });
                    player.proficiencies.Add("Intimidation");
                    break;

                case 13:
                    raceName = "Tiefling";
                    statRolls[3] += 1;
                    statRolls[5] += 2;
                    player.traits.AddRange(new List<String>() { "Darkvision", "Hellish Resistance", "Infernal Legacy" });
                    player.languages.Add("Infernal");
                    break;

                default:
                    raceName = "ERROR";
                    break;
            }
            #endregion

            #region Add Class Particulars

            // classNum = 7;

            List<String> possiblePacks = new List<string>();

            switch (classNum)
            {
                case 0:
                    player.equipment.Add("4x Javelin");
                    possiblePacks.Add("Explorer's Pack");
                    weapons.AddRange(martialMelee);
                    secondaryWeapons.Add("2 x Handaxe");
                    secondaryWeapons.AddRange(simpleMelee);
                    break;
                case 1:
                    player.equipment.Add("Lute");
                    possiblePacks.Add("Diplomat's Pack");
                    possiblePacks.Add("Entertainer's Pack");
                    weapons.AddRange(simpleMelee);
                    weapons.Add("Longsword");
                    weapons.Add("Rapier");
                    secondaryWeapons.Add("Dagger");
                    armors.Add("Leather Armor");
                    break;
                case 2:
                    player.equipment.Add("Holy Symbol");
                    possiblePacks.Add("Priest's Pack");
                    possiblePacks.Add("Explorer's Pack");
                    weapons.Add("Mace");
                    if(player.proficiencies.Contains("Warhammer"))
                    {
                        weapons.Add("Warhammer");
                    }
                    secondaryWeapons.Add("Light Crossbow + 20 Bolts");
                    secondaryWeapons.AddRange(simple);
                    armors.Add("Leather Armor");
                    armors.Add("Scale Mail");
                    if(player.proficiencies.Contains("Chain Mail"))
                    {
                        armors.Add("Chain Mail");
                    }
                    hasShield = true;
                    break;
                case 3:
                    player.equipment.Add("Druidic Focus" );
                    possiblePacks.Add("Explorer's Pack");
                    armors.Add("Leather Armor");
                    weapons.Add("Shield");
                    weapons.AddRange(simple);
                    secondaryWeapons.Add("Scimitar");
                    secondaryWeapons.AddRange(simpleMelee);
                    break;
                case 4:
                    if (rand.Next(3) == 2) { armors.Add("Chain Mail"); }
                    else {
                        armors.Add("Leather Armor");
                        weapons.Add("Longbow + 20 Arrows");
                    }
                    weapons.AddRange(martial);
                    weapons.Add("Shield");
                    secondaryWeapons.AddRange(martial);
                    if(rand.Next(3) == 2) { player.equipment.Add("Light Crossbow + 20 Bolts"); }
                    else { player.equipment.Add("2 x Handaxe"); }
                    possiblePacks.Add("Explorer's Pack");
                    possiblePacks.Add("Dungeoneer's Pack");
                    break;
                case 5:
                    weapons.AddRange(simple);
                    weapons.Add("Shortsword");
                    secondaryWeapons.Add("10 Darts");
                    possiblePacks.Add("Explorer's Pack");
                    possiblePacks.Add("Dungeoneer's Pack");
                    break;
                case 6:
                    weapons.AddRange(martial);
                    if (rand.Next(1, 3) == 2) { hasShield = true; }
                    else { secondaryWeapons.AddRange(martial); }
                    armors.Add("Chain Mail");
                    player.equipment.Add("Holy Symbol");
                    player.equipment.Add("5x Javelin");
                    possiblePacks.Add("Priest's Pack");
                    possiblePacks.Add("Explorer's Pack");
                    break;
                case 7:
                    weapons.Add("Longbow");
                    if (rand.Next(1, 3) == 2) { secondaryWeapons.Add("2x Shortswords"); }
                    else
                    {
                        secondaryWeapons.AddRange(simpleMelee);
                        Label dualWieldNotifier = new Label();
                        dualWieldNotifier.Text = "2x ";
                        dualWieldNotifier.Location = new Point(0, cbWeapon2.Location.Y);
                        dualWieldNotifier.ForeColor = Color.White;
                        dualWieldNotifier.Font = new Font(new FontFamily("Calibri"), 10, FontStyle.Bold);
                        cbWeapon2.Size = new Size(cbWeapon2.Width - 20, cbWeapon2.Height);
                        cbWeapon2.Location = new Point(cbWeapon2.Location.X + 20, cbWeapon2.Location.Y);
                        pnlMisc.Controls.Add(dualWieldNotifier);
                    }
                    armors.Add("Scale Mail");
                    armors.Add("Leather Armor");
                    player.equipment.Add("20x Arrows");
                    possiblePacks.Add("Explorer's Pack");
                    possiblePacks.Add("Dungeoneer's Pack");
                    break;
                case 8:
                    weapons.Add("Rapier");
                    weapons.Add("Shortsword");
                    secondaryWeapons.Add("Shortbow + 20 Arrows");
                    secondaryWeapons.Add("Shortsword");
                    int packNum = rand.Next(1, 4);
                    possiblePacks.Add("Explorer's Pack");
                    possiblePacks.Add("Dungeoneer's Pack");
                    possiblePacks.Add("Burglar's Pack");
                    armors.Add("Leather Armor");
                    player.equipment.Add("Thieves' Tools");
                    break;
                case 9:
                    weapons.Add("Light Crossbow + 20 Bolts");
                    weapons.AddRange(simple);
                    secondaryWeapons.Add("2x Daggers");
                    if (rand.Next(1, 3) == 2) { player.equipment.Add("Component Pouch"); }
                    else { player.equipment.Add("Arcane Focus"); }
                    possiblePacks.Add("Explorer's Pack");
                    possiblePacks.Add("Dungeoneer's Pack");
                    break;
                case 10:
                    weapons.Add("Light Crossbow + 20 Bolts");
                    weapons.AddRange(simple);
                    secondaryWeapons.Add("2x Daggers");
                    if (rand.Next(1, 3) == 2) { player.equipment.Add("Component Pouch"); }
                    else { player.equipment.Add("Arcane Focus"); }
                    possiblePacks.Add("Explorer's Pack");
                    possiblePacks.Add("Dungeoneer's Pack");
                    break;
                case 11:
                    weapons.Add("Quarterstaff");
                    weapons.Add("Dagger");
                    if (rand.Next(1, 3) == 2) { player.equipment.Add("Component Pouch"); }
                    else { player.equipment.Add("Arcane Focus"); }
                    possiblePacks.Add("Explorer's Pack");
                    possiblePacks.Add("Scholar's Pack");
                    player.equipment.Add("Spellbook");
                    break;
                default:
                    player.proficiencies.Add("CLASS NOT FULLY IMPLEMENTED YET");
                    break;

            }
            player.equipment.Add(choosePack(possiblePacks));
            #endregion

            #region Generate Alignment
            switch (rand.Next(9))
            {
                case 0:
                    player.alignment = "Lawful Good";
                    break;
                case 1:
                    player.alignment = "Neutral Lawful";
                    break;
                case 2:
                    player.alignment = "Lawful Evil";
                    break;
                case 3:
                    player.alignment = "Neutral Good";
                    break;
                case 4:
                    player.alignment = "True Neutral";
                    break;
                case 5:
                    player.alignment = "Neutral Evil";
                    break;
                case 6:
                    player.alignment = "Chaotic Good";
                    break;
                case 7:
                    player.alignment = "Chaotic Neutral";
                    break;
                case 8:
                    player.alignment = "Chaotic Evil";
                    break;
                default:
                    player.alignment = "True Neutral";
                    break;
            }
            #endregion

            #region Display Character Info
            try
            {
                Int16 i = 0;

                #region Calculate Core Modifiers
                foreach (TextBox box in statModifierBoxes)
                {
                    if (statRolls[i] > 11)
                    {
                        box.Text = "+";
                    }
                    else if (statRolls[i] == 10 || statRolls[i] == 9 || statRolls[i] == 11)
                    {
                        box.Text += "±";
                    }
                    box.Text += ((statRolls[i] - 10) / 2).ToString();
                    i++;
                }
                #endregion

                i = 0;
                foreach (TextBox box in coreStatBoxes)
                {
                    box.Text = statRolls[i].ToString();
                    i++;
                }

                txtRace.Text = raceName;
                txtClass.Text = player.name;
                txtProf.Text = "2";
                txtSpeed.Text = speed.ToString();
                txtAC.Text = ac.ToString();
                lblAlignment.Text = player.alignment;
                txtInit.Text = txtDexMod.Text;
                txtHP.Text = (player.hitDiceSides + ((statRolls[1] - 10) / 2)).ToString();

                foreach (String weapon in weapons) { cbWeapon1.Items.Add(weapon); }
                foreach (String secondaryWeapon in secondaryWeapons) { cbWeapon2.Items.Add(secondaryWeapon); }
                if (weapons.Count == 1) { cbWeapon1.SelectedIndex = 0; }
                if (secondaryWeapons.Count == 1) { cbWeapon2.SelectedIndex = 0; }

                foreach (String armour in armors) { cbArmor1.Items.Add(armour); }
                if (armors.Count == 1) { cbArmor1.SelectedIndex = 0; }
                if (hasShield)
                {
                    cbArmor2.Items.Add("Shield");
                    cbArmor2.SelectedItem = "Shield";
                }

                rtbProficiencies.Text = "PROFICIENCIES\n\n";
                foreach (String prof in player.proficiencies) { rtbProficiencies.Text += prof + "\n"; }

                rtbTraits.Text = "TRAITS\n\n";
                foreach (String trait in player.traits) { rtbTraits.Text += trait + "\n"; }

                rtbLanguages.Text = "LANGUAGES\n\n";
                foreach (String language in player.languages) { rtbLanguages.Text += language + "\n"; }

                rtbEquipment.Text = "EQUIPMENT\n\n";
                foreach (String equip in player.equipment) { rtbEquipment.Text += equip + "\n"; }

            } catch(Exception ex)
            {
                MessageBox.Show("There has been an issue, please try again" + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            detailsChanged();
            #endregion
        }

        private void detailsChanged()
        {
            changedByClick = false;
            switch(cbArmor1.Text)
            {
                case "Padded Armor":
                    ac = 11 + (statRolls[2] - 10) / 2;
                    break;
                case "Leather Armor":
                    ac = 11 + (statRolls[2] - 10) / 2;
                    break;
                case "Studded Leather":
                    ac = 12 + (statRolls[2] - 10) / 2;
                    break;
                case "Hide Armor":
                    ac = 12 + Math.Min(((statRolls[2] - 10) / 2), Convert.ToInt16(2));
                    break;
                case "Chain Shirt":
                    ac = 13 + Math.Min(((statRolls[2] - 10) / 2), Convert.ToInt16(2));
                    break;
                case "Scale Mail":
                    ac = 14 + Math.Min(((statRolls[2] - 10) / 2), Convert.ToInt16(2));
                    break;
                case "Breastplate":
                    ac = 14 + Math.Min(((statRolls[2] - 10) / 2), Convert.ToInt16(2));
                    break;
                case "Half Plate":
                    ac = 15 + Math.Min(((statRolls[2] - 10) / 2), Convert.ToInt16(2));
                    break;
                case "Ring Mail":
                    ac = 14;
                    break;
                case "Chain Mail":
                    ac = 16;
                    break;
                case "Splint":
                    ac = 17;
                    break;
                case "Plate":
                    ac = 18;
                    break;
                default:
                    ac = 10 + (statRolls[2] - 10) / 2;
                    break;
            }
            if(hasShield) { ac += 2; }
            txtAC.Text = ac.ToString();
        }

        private void cbArmor1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (changedByClick) { detailsChanged(); }
        }
    }
}
