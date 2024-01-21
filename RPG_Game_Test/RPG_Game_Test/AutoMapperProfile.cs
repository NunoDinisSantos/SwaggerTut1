using AutoMapper;
using RPG_Game_Test.Dto.Character;
using RPG_Game_Test.Models;

namespace RPG_Game_Test
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, CharacterDto>();
            CreateMap<AddCharacterDto, Character>();
        }
    }
}
