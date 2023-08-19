using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Dtos.Character;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController] /*Atributo que marca esta clase como un controlador de API, 
    lo que permite la automatización de comportamientos comunes de las API, 
    como la validación de entradas y la respuesta automática.*/

    [Route("api/[controller]")]/* Atributo que define la ruta base para los endpoints de este controlador. 
    En este caso, la URL base sería "api/Character", donde "Character" se deriva del nombre de la clase controladora
    (sin el "Controller" al final).*/
    public class CharacterController : ControllerBase
    {
       
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            /*Se define un constructor para la clase CharacterController, 
            que acepta un parámetro del tipo ICharacterService. 
            Esto se conoce como inyección de dependencias y se utiliza para proporcionar la implementación de servicios 
            necesarios en el controlador.*/
            _characterService = characterService;            
        }


        [HttpGet("GetAll")]
        /*      [HttpGet("GetAll")]: Define un endpoint HTTP GET con la ruta adicional "GetAll". 
        Cuando se accede a "api/Character/GetAll", este método se ejecuta y devuelve una lista de personajes usando 
        el servicio _characterService.
        */
        public  async Task<ActionResult<ServiceResponse<List<GetCharacterDtos>>>> Get(){
            /*      ActionResult es una clase proporcionada por el framework ASP.NET Core 
            que se utiliza para representar el resultado de una acción en un controlador. 
            La ventaja de usar ActionResult es que permite a ASP.NET Core manejar automáticamente
             la construcción de respuestas HTTP adecuadas en función del contenido del ActionResult. 
             Por ejemplo, Ok() crea una respuesta HTTP 200 con el contenido proporcionado,
              NotFound() crea una respuesta HTTP 404 y así sucesivamente.
            */
            return Ok(await _characterService.GetAllCharacter()); // devuelvo la lista de character
        }
        [HttpGet("{id}")] 
        /*      [HttpGet("{id}")]: Define otro endpoint HTTP GET que espera un parámetro id en la URL.
        Al acceder a "api/Character/{id}", este método se ejecuta y devuelve un único personaje correspondiente al ID proporcionado.*/
        public  async Task<ActionResult<ServiceResponse<GetCharacterDtos>>> GetSingle(int id){
            return Ok(await _characterService.GetCharacterByID(id)); // devuelvo el personaje con el id que paso por parametro
        }

        // creo un metodo post para insertar un nuevo personaje
        [HttpPost]
        /*      [HttpPost]: Define un endpoint HTTP POST para agregar un nuevo personaje. 
        Toma un objeto Character como entrada y lo agrega usando el servicio _characterService.
        */
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDtos>>>> AddCharacter( AddCharacterDtos newCharacter){
            
            return Ok(await _characterService.AddCharacter(newCharacter)); // devuelvo la lista de character actualizada
        }
        [HttpPut]       
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDtos>>>> UpdateCharacter( UpdateCharacterDtos updatedCharacter){
            
            var response = await _characterService.UpdateCharacter(updatedCharacter); // devuelvo la lista de character actualizada
            if (response.Data is null)
                return NotFound(response);
            return Ok(Response);
        }

         [HttpDelete("{id}")] 
        /*      [HttpGet("{id}")]: Define otro endpoint HTTP GET que espera un parámetro id en la URL.
        Al acceder a "api/Character/{id}", este método se ejecuta y devuelve un único personaje correspondiente al ID proporcionado.*/
        public  async Task<ActionResult<ServiceResponse<GetCharacterDtos>>> DeleteCharacter(int id){
            var response = await _characterService.DeleteCharacter(id); // devuelvo la lista de character actualizada
            if (response.Data is null)
                return NotFound(response);
            return Ok(Response);
        }
    }
}