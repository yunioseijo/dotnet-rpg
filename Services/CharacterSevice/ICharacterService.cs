using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Dtos.Character;

namespace dotnet_rpg.Services.CharacterSevice
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDtos>>> GetAllCharacter();
        Task<ServiceResponse<GetCharacterDtos>> GetCharacterByID(int id);
        Task<ServiceResponse<List<GetCharacterDtos>>> AddCharacter(AddCharacterDtos newCharacter);
        Task<ServiceResponse<GetCharacterDtos>> UpdateCharacter(UpdateCharacterDtos updateCharacter);
        Task<ServiceResponse<List<GetCharacterDtos>>> DeleteCharacter(int  id);
    }
}