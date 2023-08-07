using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Services.CharacterSevice
{
    public interface ICharacterService
    {
        List<Character> GetAllCharacter();
       Character GetCharacterByID(int id);
       List<Character> AddCharacter(Character newCharacter);    
    }
}