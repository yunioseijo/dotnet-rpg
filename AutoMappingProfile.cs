using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Dtos.Character;

namespace dotnet_rpg
{
    public class AutoMappingProfile :  Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Character, GetCharacterDtos>();
            CreateMap<AddCharacterDtos, Character>();
            
        }
        
    }
}