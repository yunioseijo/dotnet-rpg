using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Dtos.Character;

namespace dotnet_rpg.Services.CharacterSevice
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character> {
            new Character(),
            new Character{Id = 1, Name= "Seijo"}
        };
        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
            
        }
        public async Task<ServiceResponse<List<GetCharacterDtos>>> AddCharacter(AddCharacterDtos newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDtos>>();
            var character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            serviceResponse.Data = characters.Select( c=> _mapper.Map<GetCharacterDtos>(c)).ToList();
            return serviceResponse; // devuelvo la lista de character actualizada
        }

        public async Task<ServiceResponse<List<GetCharacterDtos>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDtos>>();
            try
            {
            // asigna el valar a character y en caso que sea null lanza la exception   
            var character = characters.First(c => c.Id == id) ?? throw new Exception($"Character with id '{id}' not found." );
            characters.Remove(character);    
            serviceResponse.Data =  characters.Select( c=> _mapper.Map<GetCharacterDtos>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDtos>>> GetAllCharacter()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDtos>>();
            serviceResponse.Data = characters.Select( c=> _mapper.Map<GetCharacterDtos>(c)).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetCharacterDtos>> GetCharacterByID(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDtos>();
            var character  = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDtos>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDtos>> UpdateCharacter(UpdateCharacterDtos updateCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDtos>();
            try
            {
                
            var character = characters.FirstOrDefault(c => c.Id == updateCharacter.Id);
             if (character is null){
                throw new Exception($"Character with id '{updateCharacter.Id}' not found." );
             }

            character.Name = updateCharacter.Name;
            character.HitPoints = updateCharacter.HitPoints;
            character.Strength = updateCharacter.Strength;
            character.Defense = updateCharacter.Defense;
            character.Intelligence = updateCharacter.Intelligence;
            character.Clase = updateCharacter.Clase;

            serviceResponse.Data =  _mapper.Map<GetCharacterDtos>(character);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                
            }
            return serviceResponse;


        }
    }
}