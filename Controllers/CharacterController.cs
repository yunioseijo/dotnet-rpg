
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
       
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
            
        }
        [HttpGet("GetAll")]
        public ActionResult<List<Character>> Get(){
            return Ok(_characterService.GetAllCharacter()); // devuelvo la lista de character
        }
        [HttpGet("{id}")] // este ruta necesita el saber el parametro
        public ActionResult<Character> GetSingle(int id){
            return Ok(_characterService.GetCharacterByID(id)); // devuelvo el personaje con el id que paso por parametro
        }
        // creo un metodo post para insertar un nuevo personaje
        [HttpPost]
        public ActionResult<List<Character>> AddCharacter( Character newCharacter){
            
            return Ok(_characterService.AddCharacter(newCharacter)); // devuelvo la lista de character actualizada
        }
    }
}