using Microsoft.AspNetCore.Mvc;
using RPG_Game_Test.Authentication;
using RPG_Game_Test.Dto.Character;
using RPG_Game_Test.Models;
using RPG_Game_Test.Services.CharacterServices;

namespace RPG_Game_Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterFacade _characterService;

        public CharacterController(ICharacterFacade characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAllCharacters")]
        public async Task<ActionResult<ServiceResponse<List<CharacterDto>>>> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("GetCharacter/{id}")]
        public async Task<ActionResult<ServiceResponse<CharacterDto>>> GetSingleCharacter(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost("CreateNewCharacter")]
        //[ServiceFilter(typeof(ApiKeyAuthFilter))]
        public async Task<ActionResult<ServiceResponse<List<CharacterDto>>>> AddCharacter(AddCharacterDto newCharacter) 
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpDelete("DeleteCharacter")]
        //[ServiceFilter(typeof(ApiKeyAuthFilter))]
        public async Task<ActionResult<ServiceResponse<List<CharacterDto>>>> DeleteCharacter(int id)
        {
            return Ok(await _characterService.DeleteCharacter(id));
        }

        [HttpPut("UpdateCharacter")]
        //[ServiceFilter(typeof(ApiKeyAuthFilter))]
        public async Task<ActionResult<ServiceResponse<CharacterDto>>> UpdateCharacter(int id, AddCharacterDto updatedCharacter)
        {
            return Ok(await _characterService.UpdateCharacter(id, updatedCharacter));
        }
    }
}
