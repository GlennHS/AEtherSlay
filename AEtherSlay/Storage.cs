using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEtherSlay
{
    class Storage
    {
        private List<Catalog.PlayerCharacter> storedCharacterSheets;
        public List<Catalog.CreatureCharacter> storedCreatures;
        public List<Catalog.Spell> spellList;

        public Storage()
        {
            storedCharacterSheets = new List<Catalog.PlayerCharacter>();
            storedCreatures = new List<Catalog.CreatureCharacter>();
        }

        public void addCharacterSheet(Catalog.PlayerCharacter charToAdd)
        {
            storedCharacterSheets.Add(charToAdd);
        }

        public Catalog.PlayerCharacter retrieveCharacterSheet(string characterName)
        {
            foreach (Catalog.PlayerCharacter character in storedCharacterSheets)
            {
                if (character.name == characterName)
                {
                    return character;
                }
            }
            return null;
        }

        public List<Catalog.PlayerCharacter> retrieveAllCharacterSheets()
        {
            return storedCharacterSheets;
        }
    }
}
