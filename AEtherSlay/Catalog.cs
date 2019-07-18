using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * MAIN DnD CATALOG CLASS
 * 
 * STATS FOLLOW ORDER [STR, CON, DEX, INT, WIS, CHA]
 * 
 */

namespace AEtherSlay
{
    public class Catalog
    {
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
        public static List<Spell> spellList = new List<Spell>()
        {
            new Spell(1, "Alarm", new List<String>() { "ranger", "wizard"}),
            new Spell(1, "Animal Friendship", new List<String>() { "bard", "druid", "ranger"}),
            new Spell(1, "Armor of Agathys", new List<String>() { "warlock"}),
            new Spell(1, "Arms of Hadar", new List<String>() { "warlock"}),
            new Spell(1, "Bane", new List<String>() { "bard", "cleric"}),
            new Spell(1, "Bless", new List<String>() { "cleric", "paladin"}),
            new Spell(1, "Burning Hands", new List<String>() { "sorcerer", "wizard"}),
            new Spell(1, "Charm Person", new List<String>() { "bard", "druid", "sorcerer", "warlock", "wizard"}),
            new Spell(1, "Chromatic Orb", new List<String>() { "sorcerer", "wizard"}),
            new Spell(1, "Color Spray", new List<String>() { "sorcerer", "wizard"}),
            new Spell(1, "Command", new List<String>() { "cleric", "paladin"}),
            new Spell(1, "Compelled Duel", new List<String>() { "paladin"}),
            new Spell(1, "Comprehend Languages", new List<String>() { "bard", "sorcerer", "warlock", "wizard"}),
            new Spell(1, "Create or Destroy Water", new List<String>() { "cleric", "druid"}),
            new Spell(1, "Cure Wounds", new List<String>() { "bard", "cleric", "druid", "paladin", "ranger"}),
            new Spell(1, "Detect Evil and Good", new List<String>() { "cleric", "paladin"}),
            new Spell(1, "Detect Magic", new List<String>() { "bard", "cleric", "druid", "paladin", "ranger", "sorcerer", "wizard"}),
            new Spell(1, "Detect Poison and Disease", new List<String>() { "cleric", "druid", "paladin", "ranger"}),
            new Spell(1, "Disguise Self", new List<String>() { "bard", "sorcerer", "wizard"}),
            new Spell(1, "Dissonant Whispers", new List<String>() { "bard"}),
            new Spell(1, "Divine Favor", new List<String>() { "paladin"}),
            new Spell(1, "Ensnaring Strike", new List<String>() { "ranger"}),
            new Spell(1, "Entangle", new List<String>() { "druid"}),
            new Spell(1, "Expeditious Retreat", new List<String>() { "sorcerer", "warlock", "wizard"}),
            new Spell(1, "False Life", new List<String>() { "sorcerer", "wizard"}),
            new Spell(1, "Faerie Fire", new List<String>() { "bard", "druid"}),
            new Spell(1, "Feather Fall", new List<String>() { "bard", "sorcerer", "wizard"}),
            new Spell(1, "Find Familiar", new List<String>() { "wizard"}),
            new Spell(1, "Fog Cloud", new List<String>() { "druid", "ranger", "sorcerer", "wizard"}),
            new Spell(1, "Goodberry", new List<String>() { "druid", "ranger"}),
            new Spell(1, "Grease", new List<String>() { "wizard"}),
            new Spell(1, "Guiding Bolt", new List<String>() { "cleric"}),
            new Spell(1, "Hail of Thorns", new List<String>() { "ranger"}),
            new Spell(1, "Healing Word", new List<String>() { "bard", "cleric", "druid"}),
            new Spell(1, "Hellish Rebuke", new List<String>() { "warlock"}),
            new Spell(1, "Heroism", new List<String>() { "bard", "paladin"}),
            new Spell(1, "Hex", new List<String>() { "warlock"}),
            new Spell(1, "Hunter's Mark", new List<String>() { "ranger"}),
            new Spell(1, "Identify", new List<String>() { "bard", "wizard"}),
            new Spell(1, "Illusory Script", new List<String>() { "bard", "warlock", "wizard"}),
            new Spell(1, "Inflict Wounds", new List<String>() { "cleric"}),
            new Spell(1, "Jump", new List<String>() { "druid", "ranger", "sorcerer", "wizard"}),
            new Spell(1, "Longstrider", new List<String>() { "bard", "druid", "ranger", "wizard"}),
            new Spell(1, "Mage Armor", new List<String>() { "sorcerer", "wizard"}),
            new Spell(1, "Magic Missle", new List<String>() { "sorcerer", "wizard"}),
            new Spell(1, "Protection from Evil and Good", new List<String>() { "cleric", "paladin", "warlock", "wizard"}),
            new Spell(1, "Purify Food and Drink", new List<String>() { "cleric", "druid", "paladin"}),
            new Spell(1, "Ray of Sickness", new List<String>() { "sorcerer", "wizard"}),
            new Spell(1, "Searing Smite", new List<String>() { "paladin"}),
            new Spell(1, "Sanctuary", new List<String>() { "cleric"}),
            new Spell(1, "Shield", new List<String>() { "sorcerer", "wizard"}),
            new Spell(1, "Shield of Faith", new List<String>() { "cleric", "paladin"}),
            new Spell(1, "Silent Image", new List<String>() { "bard", "sorcerer", "wizard"}),
            new Spell(1, "Sleep", new List<String>() { "bard", "sorcerer", "wizard"}),
            new Spell(1, "Speak with Animals", new List<String>() { "bard", "druid", "ranger"}),
            new Spell(1, "Tasha's Hideous Laughter", new List<String>() { "bard", "wizard"}),
            new Spell(1, "Tensor's Floating Disk", new List<String>() { "wizard"}),
            new Spell(1, "Thunderous Smite", new List<String>() { "paladin"}),
            new Spell(1, "Thunderwave", new List<String>() { "bard", "druid", "sorcerer", "wizard"}),
            new Spell(1, "Unseen Servant", new List<String>() { "bard", "warlock", "wizard"}),
            new Spell(1, "Witch Bolt", new List<String>() { "sorcerer", "warlock", "wizard"}),
            new Spell(1, "Wrathful Smite", new List<String>() { "paladin"}),
            new Spell(2, "Aid", new List<String>() { "cleric", "paladin"}),
            new Spell(2, "Alter Self", new List<String>() { "sorcerer", "wizard"}),
            new Spell(2, "Animal Messenger", new List<String>() { "bard", "druid", "ranger"}),
            new Spell(2, "Arcane Lock", new List<String>() { "wizard"}),
            new Spell(2, "Augury", new List<String>() { "cleric"}),
            new Spell(2, "Barkskin", new List<String>() { "druid", "ranger"}),
            new Spell(2, "Beast Sense", new List<String>() { "druid", "ranger"}),
            new Spell(2, "Blindness/Deafness", new List<String>() { "bard", "cleric", "sorcerer", "wizard"}),
            new Spell(2, "Blur", new List<String>() { "sorcerer", "wizard"}),
            new Spell(2, "Branding Smite", new List<String>() { "paladin"}),
            new Spell(2, "Calm Emotions", new List<String>() { "bard", "cleric"}),
            new Spell(2, "Cloud of Daggers", new List<String>() { "bard", "sorcerer", "warlock", "wizard"}),
            new Spell(2, "Continual Flame", new List<String>() { "cleric", "wizard"}),
            new Spell(2, "Cordon of Arrows", new List<String>() { "ranger"}),
            new Spell(2, "Crown of Madness", new List<String>() { "bard", "sorcerer", "warlock", "wizard"}),
            new Spell(2, "Darkness", new List<String>() { "sorcerer", "warlock", "wizard"}),
            new Spell(2, "Darkvision", new List<String>() { "druid", "ranger", "sorcerer", "wizard"}),
            new Spell(2, "Detect Thoughts", new List<String>() { "bard", "sorcerer", "wizard"}),
            new Spell(2, "Enhance Ability", new List<String>() { "bard", "cleric", "druid", "sorcerer"}),
            new Spell(2, "Enlarge/Reduce", new List<String>() { "sorcerer", "wizard"}),
            new Spell(2, "Enthrall", new List<String>() { "bard", "warlock"}),
            new Spell(2, "Find Steed", new List<String>() { "paladin"}),
            new Spell(2, "Find Traps", new List<String>() { "cleric", "druid", "ranger"}),
            new Spell(2, "Flame Blade", new List<String>() { "druid"}),
            new Spell(2, "Flaming Sphere", new List<String>() { "druid", "wizard"}),
            new Spell(2, "Heat Metal", new List<String>() { "bard", "druid"}),
            new Spell(2, "Hold Person", new List<String>() { "bard", "druid", "sorcerer", "warlock"}),
            new Spell(2, "Gentle Repose", new List<String>() { "cleric"}),
            new Spell(2, "Gust of Wind", new List<String>() { "druid", "sorcerer"}),
            new Spell(2, "Invisibility", new List<String>() { "bard", "sorcerer", "warlock", "wizard"}),
            new Spell(2, "Knock", new List<String>() { "bard", "sorcerer", "wizard"}),
            new Spell(2, "Lesser Restoration", new List<String>() { "bard", "cleric", "druid", "paladin", "ranger"}),
            new Spell(2, "Levitate", new List<String>() { "sorcerer", "wizard"}),
            new Spell(2, "Locate Animals or Plants", new List<String>() { "bard", "druid", "ranger"}),
            new Spell(2, "Locate Object", new List<String>() { "bard", "cleric", "druid", "paladin", "ranger", "wizard"}),
            new Spell(2, "Magic Mouth", new List<String>() { "bard", "wizard"}),
            new Spell(2, "Magic Weapon", new List<String>() { "paladin", "wizard"}),
            new Spell(2, "Melf's Acid Arrow", new List<String>() { "wizard"}),
            new Spell(2, "Mirror Image", new List<String>() { "sorcerer", "warlock", "wizard"}),
            new Spell(2, "Misty Step", new List<String>() { "sorcerer", "warlock", "wizard"}),
            new Spell(2, "Moonbeam", new List<String>() { "druid"}),
            new Spell(2, "Nystul's Magic Aura", new List<String>() { "wizard"}),
            new Spell(2, "Pass without Trace", new List<String>() { "druid", "ranger"}),
            new Spell(2, "Phantasmal Force", new List<String>() { "bard", "sorcerer", "wizard"}),
            new Spell(2, "Prayer of Healing", new List<String>() { "cleric"}),
            new Spell(2, "Protection of Poison", new List<String>() { "cleric", "druid", "poison", "ranger"}),
            new Spell(2, "Ray of Enfeeblement", new List<String>() { "warlock", "wizard"}),
            new Spell(2, "Rope Trick", new List<String>() { "wizard"}),
            new Spell(2, "Scorching Ray", new List<String>() { "sorcerer", "wizard"}),
            new Spell(2, "See Invisibility", new List<String>() { "bard", "sorcerer", "wizard"}),
            new Spell(2, "Shatter", new List<String>() { "bard", "sorcerer", "warlock", "wizard"}),
            new Spell(2, "Silence", new List<String>() { "bard", "cleric", "ranger"}),
            new Spell(2, "Spider Climb", new List<String>() { "sorcerer", "warlock", "wizard"}),
            new Spell(2, "Spike Growth", new List<String>() { "druid", "ranger"}),
            new Spell(2, "Spiritual Weapon", new List<String>() { "cleric"}),
            new Spell(2, "Suggestion", new List<String>() { "bard", "sorcerer", "warlock", "wizard"}),
            new Spell(2, "Warding Bond", new List<String>() { "cleric"}),
            new Spell(2, "Web", new List<String>() { "sorcerer", "wizard"}),
            new Spell(2, "Zone of Truth", new List<String>() { "bard", "cleric", "paladin"}),
            new Spell(3, "Animate Dead", new List<String>() { "cleric", "wizard"}),
            new Spell(3, "Aura of Vitality", new List<String>() { "paladin"}),
            new Spell(3, "Beacon of Hope", new List<String>() { "cleric"}),
            new Spell(3, "Bestow Curse", new List<String>() { "bard", "cleric", "wizard"}),
            new Spell(3, "Blinding Smite", new List<String>() { "paladin"}),
            new Spell(3, "Blink", new List<String>() { "sorcerer", "wizard"}),
            new Spell(3, "Call Lightning", new List<String>() { "druid"}),
            new Spell(3, "Clairvoyance", new List<String>() { "bard", "cleric", "sorcerer", "wizard"}),
            new Spell(3, "Conjure Animals", new List<String>() { "druid", "ranger"}),
            new Spell(3, "Conjure Barrage", new List<String>() { "ranger"}),
            new Spell(3, "Counterspell", new List<String>() { "sorcerer", "warlock", "wizard"}),
            new Spell(3, "Create Food and Water", new List<String>() { "cleric", "paladin"}),
            new Spell(3, "Crusader's Mantle", new List<String>() { "paladin"}),
            new Spell(3, "Daylight", new List<String>() { "cleric", "druid", "paladin", "ranger", "sorcerer"}),
            new Spell(3, "Dispel Magic", new List<String>() { "bard", "cleric", "druid", "paladin", "sorcerer", "warlock", "wizard"}),
            new Spell(3, "Elemental Weapon", new List<String>() { "paladin"}),
            new Spell(3, "Fear", new List<String>() { "bard", "sorcerer", "warlock", "wizard"}),
            new Spell(3, "Feign Death", new List<String>() { "bard", "cleric", "druid", "wizard"}),
            new Spell(3, "Fireball", new List<String>() { "sorcerer", "wizard"}),
            new Spell(3, "Fly", new List<String>() { "sorcerer", "warlock"}),
            new Spell(3, "Gaseous Form", new List<String>() { "sorcerer", "warlock", "wizard"}),
            new Spell(3, "Glyph of Warding", new List<String>() { "bard", "cleric", "wizard"}),
            new Spell(3, "Haste", new List<String>() { "sorcerer", "wizard"}),
            new Spell(3, "Hunger of Hadar", new List<String>() { "warlock"}),
            new Spell(3, "Hypnotic Pattern", new List<String>() { "bard", "sorcerer", "warlock", "wizard"}),
            new Spell(3, "Leomund's Tiny Hut", new List<String>() { "bard", "wizard"}),
            new Spell(3, "Lightning Arrow", new List<String>() { "ranger"}),
            new Spell(3, "Lightning Bolt", new List<String>() { "sorcerer", "wizard"}),
            new Spell(3, "Magic Circle", new List<String>() { "cleric", "paladin", "warlock", "wizard"}),
            new Spell(3, "Major Image", new List<String>() { "bard", "sorcerer", "warlock", "wizard"}),
            new Spell(3, "Mass Healing Word", new List<String>() { "cleric"}),
            new Spell(3, "Meld Into Stone", new List<String>() { "cleric", "druid"}),
            new Spell(3, "Nondetection", new List<String>() { "bard", "ranger", "wizard"}),
            new Spell(3, "Phantom Steed", new List<String>() { "wizard"}),
            new Spell(3, "Plant Growth", new List<String>() { "bard", "druid", "ranger"}),
            new Spell(3, "Protection from Energy", new List<String>() { "cleric", "druid", "ranger", "sorcerer", "wizard"}),
            new Spell(3, "Remove Curse", new List<String>() { "cleric", "paladin", "warlock"}),
            new Spell(3, "Revivify", new List<String>() { "cleric", "paladin"}),
            new Spell(3, "Sending", new List<String>() { "bard", "cleric", "wizard"}),
            new Spell(3, "Sleet Storm", new List<String>() { "druid", "sorcerer", "wizard"}),
            new Spell(3, "Slow", new List<String>() { "sorcerer", "wizard"}),
            new Spell(3, "Speak with Dead", new List<String>() { "bard", "cleric"}),
            new Spell(3, "Speak with Plants", new List<String>() { "bard", "druid", "ranger"}),
            new Spell(3, "Spirit Guardians", new List<String>() { "cleric"}),
            new Spell(3, "Stinking Cloud", new List<String>() { "bard", "sorcerer", "wizard"}),
            new Spell(3, "Tongues", new List<String>() { "bard", "cleric", "sorcerer", "warlock", "wizard"}),
            new Spell(3, "Vampiric Touch", new List<String>() { "warlock", "wizard"}),
            new Spell(3, "Water Breathing", new List<String>() { "druid", "ranger", "sorcerer", "wizard"}),
            new Spell(3, "Water Walk", new List<String>() { "cleric", "druid", "ranger", "sorcerer"}),
            new Spell(3, "Wind Wall", new List<String>() { "druid", "ranger"}),
            new Spell(4, "Aura of Life", new List<String>() { "paladin"}),
            new Spell(4, "Aura of Purify", new List<String>() { "paladin"}),
            new Spell(4, "Arcane Eye", new List<String>() { "wizard"}),
            new Spell(4, "Banishment", new List<String>() { "cleric", "paladin", "sorcerer", "warlock", "wizard"}),
            new Spell(4, "Blight", new List<String>() { "druid", "sorcerer", "warlock", "wizard"}),
            new Spell(4, "Compulsion", new List<String>() { "bard"}),
            new Spell(4, "Confusion", new List<String>() { "bard", "druid", "sorcerer", "wizard"}),
            new Spell(4, "Conjure Minor Elementals", new List<String>() { "druid", "wizard"}),
            new Spell(4, "Conjure Woodland Beings", new List<String>() { "druid", "ranger"}),
            new Spell(4, "Control Water", new List<String>() { "druid", "wizard"}),
            new Spell(4, "Control Weather", new List<String>() { "cleric"}),
            new Spell(4, "Death Ward", new List<String>() { "cleric"}),
            new Spell(4, "Dimension Door", new List<String>() { "bard", "warlock", "wizard"}),
            new Spell(4, "Divination", new List<String>() { "cleric"}),
            new Spell(4, "Dominate Beast", new List<String>() { "druid", "sorcerer"}),
            new Spell(4, "Evard's Black Tentacles", new List<String>() { "wizard"}),
            new Spell(4, "Fabricate", new List<String>() { "wizard"}),
            new Spell(4, "Fire Shield", new List<String>() { "wizard"}),
            new Spell(4, "Freedom of Movement", new List<String>() { "bard", "cleric", "druid", "ranger"}),
            new Spell(4, "Giant Insect", new List<String>() { "druid"}),
            new Spell(4, "Grasping Vine", new List<String>() { "druid", "ranger"}),
            new Spell(4, "Greater Invisibility", new List<String>() { "bard", "sorcerer", "wizard"}),
            new Spell(4, "Guardian of Faith", new List<String>() { "cleric"}),
            new Spell(4, "Hallucinatory Terrain", new List<String>() { "bard", "druid", "warlock", "wizard"}),
            new Spell(4, "Ice Storm", new List<String>() { "druid", "sorcerer", "wizard"}),
            new Spell(4, "Leomund's Secret Chest", new List<String>() { "wizard"}),
            new Spell(4, "Locate Creature", new List<String>() { "bard", "cleric", "druid", "paladin", "ranger", "wizard"}),
            new Spell(4, "Mordenkainen's Faithful Hound", new List<String>() { "wizard"}),
            new Spell(4, "Mordenkainen's Private Sanctum", new List<String>() { "wizard"}),
            new Spell(4, "Otiluke's Resilient Sphere", new List<String>() { "wizard"}),
            new Spell(4, "Phantasmal Killer", new List<String>() { "wizard"}),
            new Spell(4, "Polymorph", new List<String>() { "bard", "sorcerer", "wizard"}),
            new Spell(4, "Staggering Smite", new List<String>() { "paladin"}),
            new Spell(4, "Stone Shape", new List<String>() { "cleric", "druid", "wizard"}),
            new Spell(4, "Stoneskin", new List<String>() { "druid", "ranger", "sorcerer", "wizard"}),
            new Spell(4, "Wall of Fire", new List<String>() { "druid", "sorcerer", "wizard"}),
            new Spell(5, "Animate Objects", new List<String>() { "bard", "sorcerer", "wizard"}),
            new Spell(5, "Antilife Shell", new List<String>() { "druid"}),
            new Spell(5, "Awaken", new List<String>() { "bard", "druid"}),
            new Spell(5, "Banishing Smite", new List<String>() { "paladin"}),
            new Spell(5, "Bigby's Hand", new List<String>() { "wizard"}),
            new Spell(5, "Circle of Power", new List<String>() { "paladin"}),
            new Spell(5, "Cloudkill", new List<String>() { "sorcerer", "wizard"}),
            new Spell(5, "Commune", new List<String>() { "cleric"}),
            new Spell(5, "Commune with Nature", new List<String>() { "druid", "ranger"}),
            new Spell(5, "Cone of Cold", new List<String>() { "sorcerer", "wizard"}),
            new Spell(5, "Conjure ELemental", new List<String>() { "druid", "wizard"}),
            new Spell(5, "Conjure Volley", new List<String>() { "ranger"}),
            new Spell(5, "Contact Other Plane", new List<String>() { "warlock", "wizard"}),
            new Spell(5, "Contagion", new List<String>() { "cleric", "druid"}),
            new Spell(5, "Creation", new List<String>() { "sorcerer", "wizard"}),
            new Spell(5, "Destructive Smite", new List<String>() { "paladin"}),
            new Spell(5, "Dispel Evil and Good", new List<String>() { "cleric", "paladin"}),
            new Spell(5, "Dominate Person", new List<String>() { "bard", "sorcerer", "wizard"}),
            new Spell(5, "Dream", new List<String>() { "bard", "warlock", "wizard"}),
            new Spell(5, "Flame Strike", new List<String>() { "cleric"}),
            new Spell(5, "Geas", new List<String>() { "bard", "cleric", "druid", "paladin", "wizard"}),
            new Spell(5, "Greater Restoration", new List<String>() { "bard", "cleric", "druid"}),
            new Spell(5, "Hallow", new List<String>() { "cleric"}),
            new Spell(5, "Hold Monster", new List<String>() { "bard", "sorcerer", "warlock", "wizard"}),
            new Spell(5, "Insect Plague", new List<String>() { "cleric", "druid", "sorcerer"}),
            new Spell(5, "Legend Lore", new List<String>() { "bard", "cleric", "wizard"}),
            new Spell(5, "Mass Cure Wounds", new List<String>() { "bard", "cleric"}),
            new Spell(5, "Mislead", new List<String>() { "bard", "wizard"}),
            new Spell(5, "Modify Memory", new List<String>() { "bard", "wizard"}),
            new Spell(5, "Passwall", new List<String>() { "wizard"}),
            new Spell(5, "Planar Binding", new List<String>() { "bard", "cleric", "druid", "wizard"}),
            new Spell(5, "Raise Dead", new List<String>() { "bard", "cleric", "paladin"}),
            new Spell(5, "Rary's Telepathic Bond", new List<String>() { "wizard"}),
            new Spell(5, "Reincarnate", new List<String>() { "druid"}),
            new Spell(5, "Scrying", new List<String>() { "bard", "cleric", "druid", "warlock", "wizard"}),
            new Spell(5, "Seeming", new List<String>() { "bard", "sorcerer", "wizard"}),
            new Spell(5, "Swift Quiver", new List<String>() { "ranger"}),
            new Spell(5, "Telekinesis", new List<String>() { "sorcerer", "wizard"}),
            new Spell(5, "Teleportation Circle", new List<String>() { "bard", "sorcerer", "wizard"}),
            new Spell(5, "Tree Stride", new List<String>() { "druid", "ranger"}),
            new Spell(5, "Wall of Force", new List<String>() { "wizard"}),
            new Spell(5, "Wall of Stone", new List<String>() { "druid", "sorcerer", "wizard"}),
            new Spell(6, "Arcane Gate", new List<String>() { "sorcerer", "warlock", "wizard"}),
            new Spell(6, "Blade Barrier", new List<String>() { "cleric"}),
            new Spell(6, "Chain Lightning", new List<String>() { "sorcerer", "wizard"}),
            new Spell(6, "Circle of Death", new List<String>() { "sorcerer", "warlock", "wizard"}),
            new Spell(6, "Conjure Fey", new List<String>() { "druid", "warlock"}),
            new Spell(6, "Contingency", new List<String>() { "wizard"}),
            new Spell(6, "Create Undead", new List<String>() { "cleric", "warlock", "wizard"}),
            new Spell(6, "Disintegrate", new List<String>() { "sorcerer", "wizard"}),
            new Spell(6, "Drawmij's Instant Summons", new List<String>() { "wizard"}),
            new Spell(6, "Eyebit", new List<String>() { "bard", "sorcerer", "warlock", "wizard"}),
            new Spell(6, "Find the Path", new List<String>() { "bard", "cleric", "druid"}),
            new Spell(6, "Flesh to Stone", new List<String>() { "warlock", "wizard"}),
            new Spell(6, "Forbiddance", new List<String>() { "cleric"}),
            new Spell(6, "Globe of Invulnerability", new List<String>() { "sorcerer", "wizard"}),
            new Spell(6, "Guards and Wards", new List<String>() { "bard", "wizard"}),
            new Spell(6, "Harm", new List<String>() { "cleric"}),
            new Spell(6, "Heal", new List<String>() { "cleric", "druid"}),
            new Spell(6, "Heroes' Feast", new List<String>() { "cleric", "druid"}),
            new Spell(6, "Magic Jar", new List<String>() { "wizard"}),
            new Spell(6, "Mass Suggestion", new List<String>() { "bard", "sorcerer", "warlock", "wizard"}),
            new Spell(6, "Move Earth", new List<String>() { "druid", "sorcerer", "wizard"}),
            new Spell(6, "Otiluke's Freezing Sphere", new List<String>() { "wizard"}),
            new Spell(6, "Otto's Irresistible Dance", new List<String>() { "bard", "wizard"}),
            new Spell(6, "Planar Ally", new List<String>() { "cleric"}),
            new Spell(6, "Programmed Illusion", new List<String>() { "bard", "wizard"}),
            new Spell(6, "Sunbeam", new List<String>() { "druid", "sorcerer", "wizard"}),
            new Spell(6, "Transport via Plants", new List<String>() { "druid"}),
            new Spell(6, "True Seeing", new List<String>() { "bard", "cleric", "sorcerer", "warlock", "wizard"}),
            new Spell(6, "Wall of Ice", new List<String>() { "wizard"}),
            new Spell(6, "Wall of Thorns", new List<String>() { "druid"}),
            new Spell(6, "Wind Walk", new List<String>() { "druid"}),
            new Spell(6, "Word of Recall", new List<String>() { "cleric"}),
            new Spell(7, "Conjure Celestial", new List<String>() { "cleric"}),
            new Spell(7, "Delayed Blast Fireball", new List<String>() { "sorcerer", "wizard"}),
            new Spell(7, "Divine Word", new List<String>() { "cleric"}),
            new Spell(7, "Etherealness", new List<String>() { "bard", "cleric", "sorcerer", "wizard"}),
            new Spell(7, "Finger of Death", new List<String>() { "sorcerer", "wizard"}),
            new Spell(7, "Fire Storm", new List<String>() { "cleric", "druid", "sorcerer"}),
            new Spell(7, "Forcecage", new List<String>() { "bard", "wizard"}),
            new Spell(7, "Mirage Arcane", new List<String>() { "bard", "druid", "wizard"}),
            new Spell(7, "Mordenkainen's Magnificent Mansion", new List<String>() { "bard", "wizard"}),
            new Spell(7, "Mordenkainen's Sword", new List<String>() { "bard", "wizard"}),
            new Spell(7, "Plane Shift", new List<String>() { "cleric", "druid", "sorcerer", "wizard"}),
            new Spell(7, "Prismatic Spray", new List<String>() { "sorcerer", "wizard"}),
            new Spell(7, "Project Image", new List<String>() { "bard", "wizard"}),
            new Spell(7, "Regenerate", new List<String>() { "bard", "cleric", "druid"}),
            new Spell(7, "Resurrection", new List<String>() { "bard", "cleric"}),
            new Spell(7, "Reverse Gravity", new List<String>() { "druid", "sorcerer", "wizard"}),
            new Spell(7, "Sequester", new List<String>() { "wizard"}),
            new Spell(7, "Simulacrum", new List<String>() { "wizard"}),
            new Spell(7, "Symbol", new List<String>() { "bard", "cleric", "wizard"}),
            new Spell(7, "Teleport", new List<String>() { "bard", "sorcerer", "wizard"}),
            new Spell(8, "Animal Shapes", new List<String>() { "druid"}),
            new Spell(8, "Antimagic Field", new List<String>() { "cleric", "wizard"}),
            new Spell(8, "Antipathy/Sympathy", new List<String>() { "druid", "wizard"}),
            new Spell(8, "Clone", new List<String>() { "wizard"}),
            new Spell(8, "Control Weather", new List<String>() { "cleric", "druid", "wizard"}),
            new Spell(8, "Demiplane", new List<String>() { "warlock", "wizard"}),
            new Spell(8, "Dominate Monster", new List<String>() { "bard", "sorcerer", "warlock", "wizard"}),
            new Spell(8, "Earthquake", new List<String>() { "cleric", "druid", "sorcerer"}),
            new Spell(8, "Feeblemind", new List<String>() { "bard", "druid", "warlock", "wizard"}),
            new Spell(8, "Glibness", new List<String>() { "bard", "warlock"}),
            new Spell(8, "Holy Aura", new List<String>() { "cleric"}),
            new Spell(8, "Incendiary Cloud", new List<String>() { "sorcerer", "wizard"}),
            new Spell(8, "Maze", new List<String>() { "wizard"}),
            new Spell(8, "Mind Blank", new List<String>() { "bard", "wizard"}),
            new Spell(8, "Power Word Stun", new List<String>() { "bard", "sorcerer", "warlock", "wizard"}),
            new Spell(8, "Sunburst", new List<String>() { "druid", "sorcerer", "wizard"}),
            new Spell(8, "Telepathy", new List<String>() { "wizard"}),
            new Spell(8, "Trap the Soul", new List<String>() { "wizard"}),
            new Spell(8, "Tsunami", new List<String>() { "druid"}),
            new Spell(9, "Astral Projection", new List<String>() { "cleric", "warlock", "wizard"}),
            new Spell(9, "Foresight", new List<String>() { "bard", "druid", "warlock", "wizard"}),
            new Spell(9, "Gate", new List<String>() { "cleric", "sorcerer", "wizard"}),
            new Spell(9, "Imprisonment", new List<String>() { "warlock", "wizard"}),
            new Spell(9, "Mass Heal", new List<String>() { "cleric"}),
            new Spell(9, "Meteor Swarm", new List<String>() { "sorcerer", "wizard"}),
            new Spell(9, "Power Word Heal", new List<String>() { "bard"}),
            new Spell(9, "Power Word Kill", new List<String>() { "bard", "sorcerer", "warlock", "wizard"}),
            new Spell(9, "Prismatic Wall", new List<String>() { "wizard"}),
            new Spell(9, "Shapechange", new List<String>() { "druid", "wizard"}),
            new Spell(9, "Storm of Vengeance", new List<String>() { "druid"}),
            new Spell(9, "Time Stop", new List<String>() { "sorcerer", "wizard"}),
            new Spell(9, "True Polymorph", new List<String>() { "bard", "warlock", "wizard"}),
            new Spell(9, "True Resurrection", new List<String>() { "cleric", "druid"}),
            new Spell(9, "Weird", new List<String>() { "wizard"}),
            new Spell(9, "Wish", new List<String>() { "sorcerer", "wizard"})
        };
        public List<CreatureCharacter> creatureList = new List<CreatureCharacter>();
        #endregion

        public Catalog()
        {
            catalogInit();
        }

        private void catalogInit()
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
        }

        public abstract class Character
        {
            public String       name
                               ,alignment
                               ,spellcastingStat
                               ,misc
                               ,equipment
                               ,proficiencies
                               ,traits
                               ,languages;
            public List<String> savingThrows
                               ,immunities     
                               ,resistances    
                               ,vulnerabilities;
            public List<Weapon> weapons;
            public Armor        armor;
            public Int16[]      stats     // STATS FOLLOW ORDER [STR, DEX, CON, INT, WIS, CHA]
                               ,statMods  // STATS FOLLOW ORDER [STR, DEX, CON, INT, WIS, CHA]
                               ,money = new short[5];
            public Boolean      hasShield;
            public Int16        ac
                               ,health
                               ,hitDiceSides
                               ,hitDice
                               ,level
                               ,speed;

            protected Character(short speed, string spellcastingStat, string proficiencies, List<String> savingThrows, short hitDiceSides)
            {
                this.spellcastingStat = spellcastingStat;
                this.proficiencies = proficiencies;
                this.savingThrows = savingThrows;
                this.hitDiceSides = hitDiceSides;
                level = 1;
                this.speed = speed;

            }

            protected Character()
            {
                // DANGEROUS INSTANTIATION TRY AND AVOID
            }

            protected Character(string name, short[] statRolls, short speed, List<Weapon> weapons, Armor armor, string alignment, string equipment, string languages, List<string> resistances, string spellcastingStat, string proficiencies, Int16 hitDiceSides, List<string> savingThrows, string traits)
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

                calcAC();
                calcHealth();
            }

            private void calcAC()
            {
                // Check this.armor exists
                if (!(armor == null))
                {
                    ac = armor.getAC(stats[1]);
                } else
                {
                    ac = Convert.ToInt16(10 + statMods[1]);
                }
                if(hasShield)
                {
                    ac += 2;
                }
            }

            private void calcHealth()
            {
                health = Convert.ToInt16(hitDiceSides + (((hitDiceSides / 2) + 1) * (level - 1)) + statMods[2]);
            }
        }
    
        public class PlayerCharacter : Character
        {
            public List<Spell> validSpells, knownSpells = new List<Spell>();
            public string className, raceName, notes = "None Set";

            public PlayerCharacter(String name, Int16[] statRolls, string className, string raceName, Int16 speed, List<Weapon> weapons, Armor armor, string alignment, string equipment, string languages, List<string> resistances, string spellcastingStat, string proficiencies, Int16 hitDiceSides, List<string> savingThrows, string traits)
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
            }

            public List<Spell> getValidSpells()
            {
                List<Spell> outSpells = new List<Spell>();
                foreach(Spell currentSpell in spellList)
                {
                    if (currentSpell.canUse.Contains(this.className.ToLower()))
                    {
                        outSpells.Add(currentSpell);
                    }
                }
                return validSpells;
            }

            public void setKnownSpells(List<Spell> newSpells)
            {
                this.knownSpells = newSpells;
            }

            public void addSpell(Spell spell)
            {
                this.knownSpells.Add(spell);
            }
        }

        public class CreatureCharacter : Character
        {

        }

        public short[] rollStats()
        {
            // STR CON DEX INT WIS CHA
            // 0   1   2   3   4   5
            Int16[] statRolls = new Int16[6];

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
                if(stats[i] < 10 && (stats[i] % 2) == 1)
                {
                    statModifiers[i] = Convert.ToInt16((double)((stats[i] - 10) / 2) - 1);
                } else
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

            public String getDmgString()
            {
                return $"{numDamageDice}d{damageDiceSides} {damageType}";
            }
        }
    
        public class Armor
        {
            public String name;
            public Int16 baseAC, dexLimit;
            public bool givesStealthDisadvantage;

            public Armor(string name, short dexLimit, short baseAC, bool givesStealthDisadvantage)
            {
                this.name = name;
                this.dexLimit = dexLimit;
                this.baseAC = baseAC;
                this.givesStealthDisadvantage = givesStealthDisadvantage;
            }

            public Int16 getAC(Int16 dex)
            {
                return Convert.ToInt16(baseAC + Math.Min(dex, dexLimit));
            }
        }
    
        public class Spell
        {
            public Int16 level;
            public String name;
            public List<String> canUse;

            public Spell(short level, string name, List<string> canUse)
            {
                this.level = level;
                this.name = name;
                this.canUse = canUse;
            }
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
