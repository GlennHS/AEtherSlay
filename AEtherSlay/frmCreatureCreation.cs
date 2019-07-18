using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AEtherSlay
{
    public partial class frmCreatureCreation : Form
    {
        public frmCreatureCreation()
        {
            InitializeComponent();
        }
        List<Creature> allCreatures= new List<Creature>();
        JArray storedCreatures = (JArray)JsonConvert.DeserializeObject<object>(File.ReadAllText(@"..\Monsters.json"));
        Creature selectedCreature;

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

        public class Creature
        {
            public short? hitPoints, armorClass, initiative, passivePerception, rawStr, rawCon, rawDex, rawInt, rawWis, rawCha, strSave, conSave, dexSave, intSave, wisSave, chaSave;
            public decimal challengeRating;
            public List<string> damageVulns, damageRes, damageImm, conditionImm, languages, senses;
            public string name, type, subtype, size, alignment, speed;
            public List<Attack> attacks;
            public List<SpecialAbility> legendaryActions, specialAbilities;
            public List<Skill> skills;

            public Creature()
            {
                damageImm = new List<string>();
                conditionImm= new List<string>();
                languages = new List<string>();
                damageRes = new List<string>();
                damageVulns = new List<string>();
                senses = new List<string>();
                attacks = new List<Attack>();
                legendaryActions = new List<SpecialAbility>();
                specialAbilities = new List<SpecialAbility>();
                skills = new List<Skill>();
            }

            public void setInit()
            {
                initiative = (short?)(Program.catalog.rand.Next(1, 20) + Program.catalog.calcModifier(rawWis));
            }
        }

        public class listBoxMember
        {
            string displayValue, memberValue;

            public listBoxMember(string displayValue, string memberValue)
            {
                this.displayValue = displayValue;
                this.memberValue = memberValue;
            }
        }

        //private class CreatureRAW
        //{
        //    short hitPoints, armorClass, challengeRating, initiative, passivePerception, rawStr, rawCon, rawDex, rawInt, rawWis, rawCha, strSave, conSave, dexSave, intSave, wisSave, chaSave;
        //    string name, type, subtype, size, alignment, speed;
        //}

        private Skill getStatMod(string name, short coreStat, short? mod = 0)
        {
            if(mod != 0 && mod != null)
            {
                return new Skill(mod, name);
            } else
            {
                return new Skill(coreStat, name);
            }
        }

        private string[] splitString(string input)
        {
            string[] output = input.Split(",".ToCharArray()[0]);
            foreach(string thing in output)
            {
                thing.Trim();
            }
            return output;
        }

        private void populateCreatureList()
        {
            foreach (JToken creature in storedCreatures)
            {
                if (creature.SelectToken("license") == null)
                {
                    Creature currentCreature = new Creature();
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
                    currentCreature.setInit();
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
                    } catch { }
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
                    allCreatures.Add(currentCreature);
                }
            }
        }

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

        private void getCreatureNamesByCR(decimal lowerCR, decimal upperCR = 99)
        {
            List<String> validCreatures = new List<string>();
            foreach (Creature creature in allCreatures)
            {
                if (creature.challengeRating > lowerCR && creature.challengeRating < upperCR)
                {
                    validCreatures.Add(creature.name);
                }
            }
            populateDropdown(validCreatures);
        }

        private Creature getCreatureByName(string name)
        {
            foreach (Creature creature in allCreatures)
            {
                if (creature.name == name)
                {
                    return creature;
                }
            }
            return null;
        }

        private void showCreatureDetails(string creatureName)
        {
            Creature creatureToShow = getCreatureByName(creatureName);
            selectedCreature = creatureToShow;
            txtHP.Text = creatureToShow.hitPoints.ToString();
            txtAC.Text = creatureToShow.armorClass.ToString();
            txtCR.Text = creatureToShow.challengeRating.ToString();
            txtInit.Text = creatureToShow.initiative.ToString();
            txtPercept.Text = creatureToShow.passivePerception.ToString();
            txtSpeed.Text = creatureToShow.speed;
            txtStr.Text = creatureToShow.rawStr.ToString();
            txtCon.Text = creatureToShow.rawCon.ToString();
            txtDex.Text = creatureToShow.rawDex.ToString();
            txtInt.Text = creatureToShow.rawInt.ToString();
            txtWis.Text = creatureToShow.rawWis.ToString();
            txtCha.Text = creatureToShow.rawCha.ToString();
            txtStrSave.Text = creatureToShow.strSave.ToString();
            txtConSave.Text = creatureToShow.conSave.ToString();
            txtDexSave.Text = creatureToShow.dexSave.ToString();
            txtIntSave.Text = creatureToShow.intSave.ToString();
            txtWisSave.Text = creatureToShow.wisSave.ToString();
            txtChaSave.Text = creatureToShow.chaSave.ToString();
            lbSkills.Items.Clear();
            foreach(Skill skill in creatureToShow.skills)
            {
                lbSkills.Items.Add($"{skill.mod} - {skill.skill}");
            }
            lbVuln.Items.Clear();
            foreach(string vuln in creatureToShow.damageVulns)
            {
                lbVuln.Items.Add(vuln);
            }
            lbRes.Items.Clear();
            foreach (string res in creatureToShow.damageRes)
            {
                lbRes.Items.Add(res);
            }
            lbImm.Items.Clear();
            foreach (string imm in creatureToShow.damageImm)
            {
                lbImm.Items.Add(imm);
            }
            lbConImm.Items.Clear();
            foreach (string imm in creatureToShow.conditionImm)
            {
                lbConImm.Items.Add(imm);
            }
            lbSenses.Items.Clear();
            foreach (string sense in creatureToShow.senses)
            {
                lbSenses.Items.Add(sense);
            }
            lbAttacks.Items.Clear();
            foreach (Attack atk in creatureToShow.attacks)
            {
                lbAttacks.Items.Add(atk.name);
            }
            lbLegAct.Items.Clear();
            foreach (SpecialAbility legAct in creatureToShow.legendaryActions)
            {
                lbLegAct.Items.Add(legAct.name);
            }
            lbAbilities.Items.Clear();
            foreach (SpecialAbility act in creatureToShow.specialAbilities)
            {
                lbAbilities.Items.Add(act.name);
            }
            lbLanguages.Items.Clear();
            foreach(string lang in creatureToShow.languages)
            {
                lbLanguages.Items.Add(lang);
            }
            lblName.Text = creatureToShow.name;
            lblType.Text = $"{creatureToShow.type} // {creatureToShow.subtype ?? "NONE"}";
            lblSize.Text = creatureToShow.size;
            lblAlignment.Text = creatureToShow.alignment;
        }

        public void showAttackDetails(string name)
        {
            foreach(Attack atk in selectedCreature.attacks)
            {
                if(atk.name == name)
                {
                    MessageBox.Show($"Name: {atk.name}\n\nDice: {atk.dice}\nDesc. {atk.desc}\n\nAttack Bonus: {atk.atkBonus}\nDamage Bonus: {atk.dmgBonus}");
                }
            }
        }

        public void showAbilityDetails(string name)
        {
            foreach (SpecialAbility a in selectedCreature.legendaryActions)
            {
                if (a.name == name)
                {
                    MessageBox.Show($"Name: {a.name}\n\nDesc. {a.desc}");
                }
            }
            foreach (SpecialAbility a in selectedCreature.specialAbilities)
            {
                if (a.name == name)
                {
                    MessageBox.Show($"Name: {a.name}\n\nDesc. {a.desc}");
                }
            }
        }

        public void populateDropdown(List<string> creatureNames)
        {
            cbCreatures.Items.Clear();
            foreach(string cName in creatureNames)
            {
                cbCreatures.Items.Add(cName);
            }
        }

        private void frmCreatureCreation_Load(object sender, EventArgs e)
        {
            populateCreatureList();
            showCreatureDetails("Aboleth");
        }

        private void cbCreatures_SelectedIndexChanged(object sender, EventArgs e)
        {
            showCreatureDetails(cbCreatures.Text);
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            decimal upperBound = nudUpperCR.Value;
            if(upperBound == 0) { getCreatureNamesByCR(nudLowerCR.Value); }
            else { getCreatureNamesByCR(nudLowerCR.Value, nudUpperCR.Value); }
        }

        private void lbAttacks_SelectedIndexChanged(object sender, EventArgs e)
        {
            showAttackDetails(lbAttacks.Text);
        }

        private void lbLegAct_SelectedIndexChanged(object sender, EventArgs e)
        {
            showAbilityDetails(lbLegAct.Text);
        }

        private void lbAbilities_SelectedIndexChanged(object sender, EventArgs e)
        {
            showAbilityDetails(lbAbilities.Text);
        }

        private void btnRand_Click(object sender, EventArgs e)
        {
            decimal upperBound = nudUpperCR.Value;
            if (upperBound == 0) { getCreatureNamesByCR(nudLowerCR.Value); }
            else { getCreatureNamesByCR(nudLowerCR.Value, nudUpperCR.Value); }
            cbCreatures.SelectedIndex = Program.catalog.rand.Next(1, cbCreatures.Items.Count);
        }
    }
}
