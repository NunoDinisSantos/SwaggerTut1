using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPG_Game_Test.Data;
using RPG_Game_Test.Dto.Character;
using RPG_Game_Test.Models;

namespace RPG_Game_Test.Services.CharacterServices
{
    public class CharacterFacade : ICharacterFacade
    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;


        public CharacterFacade(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CharacterDto>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<CharacterDto>();

            var dbCharacters = await _context.Characters.ToListAsync();
            var character = dbCharacters.FirstOrDefault(x => x.Id == id);

            if(character == null)
            {
                throw new Exception($"Character with id {id} not found");
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<CharacterDto>>();
            var dbCharacters = await _context.Characters.ToListAsync();
            serviceResponse.Data = dbCharacters.Select(x => _mapper.Map<CharacterDto>(x)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<CharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<CharacterDto>();
            var dbCharacters = await _context.Characters.ToListAsync();
            var character = dbCharacters.FirstOrDefault(x => x.Id == id);
            serviceResponse.Data = _mapper.Map<CharacterDto>(character);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<CharacterDto>>();
            var character = _mapper.Map<Character>(newCharacter);

            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();

            serviceResponse.Data = (await _context.Characters.ToListAsync()).Select(x => _mapper.Map<CharacterDto>(x)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<CharacterDto>> UpdateCharacter(int id, AddCharacterDto UpdatedCharacter)
        {
            var serviceResponse = new ServiceResponse<CharacterDto>();
            var character = _context.Characters.Where(x => x.Id == id).FirstOrDefault();

            if(character == null)
            {
                throw new Exception($"Could not update character with id {id}");
            }

            character.Name = UpdatedCharacter.Name;
            character.Strength = UpdatedCharacter.Strength;
            character.Defense = UpdatedCharacter.Defense;
            character.Health = UpdatedCharacter.Health;
            character.Class = UpdatedCharacter.Class;
            character.Intelligence= UpdatedCharacter.Intelligence;

            serviceResponse.Data = _mapper.Map<CharacterDto>(character);
            await _context.SaveChangesAsync();

            return serviceResponse;
        }
    }
}
