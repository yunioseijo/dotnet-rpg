using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Services.CharacterSevice
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character> {
            new Character(),
            new Character{Id = 1, Name= "Seijo"}
        };
        public List<Character> AddCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            return characters; // devuelvo la lista de character actualizada
        }

        public List<Character> GetAllCharacter()
        {
            return characters;
        }
        public Character GetCharacterByID(int id)
        {
            var character  = characters.FirstOrDefault(c => c.Id == id);
            if (character is not null)
                return character;
            throw new Exception("Invalid character ID (Character not found)");
        }




    }
}