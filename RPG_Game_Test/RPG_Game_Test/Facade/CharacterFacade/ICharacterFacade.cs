using RPG_Game_Test.Dto.Character;
using RPG_Game_Test.Models;

namespace RPG_Game_Test.Services.CharacterServices
{
    public interface ICharacterFacade
    {
        Task<ServiceResponse<List<CharacterDto>>> GetAllCharacters();
        Task<ServiceResponse<CharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<CharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        Task<ServiceResponse<CharacterDto>> DeleteCharacter(int id);
        Task<ServiceResponse<CharacterDto>> UpdateCharacter(int id, AddCharacterDto updatedCharacter);
    }
}
