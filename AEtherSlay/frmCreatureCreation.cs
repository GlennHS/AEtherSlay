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
        List<Catalog.CreatureCharacter> allCreatures;
        Catalog.CreatureCharacter selectedCreature;
        public frmCreatureCreation()
        {
            InitializeComponent();
            allCreatures = Program.catalog.creatureList;
            showCreatureDetails("Aboleth");
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

        public class listBoxMember
        {
            string displayValue, memberValue;

            public listBoxMember(string displayValue, string memberValue)
            {
                this.displayValue = displayValue;
                this.memberValue = memberValue;
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
            foreach (Catalog.CreatureCharacter creature in allCreatures)
            {
                if (creature.challengeRating > lowerCR && creature.challengeRating < upperCR)
                {
                    validCreatures.Add(creature.name);
                }
            }
            populateDropdown(validCreatures);
        }

        private Catalog.CreatureCharacter getCreatureByName(string name)
        {
            foreach (Catalog.CreatureCharacter creature in allCreatures)
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
            Catalog.CreatureCharacter creatureToShow = getCreatureByName(creatureName);
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
            foreach(Catalog.Skill skill in creatureToShow.skills)
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
            foreach (Catalog.Attack atk in creatureToShow.attacks)
            {
                lbAttacks.Items.Add(atk.name);
            }
            lbLegAct.Items.Clear();
            foreach (Catalog.SpecialAbility legAct in creatureToShow.legendaryActions)
            {
                lbLegAct.Items.Add(legAct.name);
            }
            lbAbilities.Items.Clear();
            foreach (Catalog.SpecialAbility act in creatureToShow.specialAbilities)
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
            foreach(Catalog.Attack atk in selectedCreature.attacks)
            {
                if(atk.name == name)
                {
                    MessageBox.Show($"Name: {atk.name}\n\nDice: {atk.dice}\nDesc. {atk.desc}\n\nAttack Bonus: {atk.atkBonus}\nDamage Bonus: {atk.dmgBonus}");
                }
            }
        }

        public void showAbilityDetails(string name)
        {
            foreach (Catalog.SpecialAbility a in selectedCreature.legendaryActions)
            {
                if (a.name == name)
                {
                    MessageBox.Show($"Name: {a.name}\n\nDesc. {a.desc}");
                }
            }
            foreach (Catalog.SpecialAbility a in selectedCreature.specialAbilities)
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
