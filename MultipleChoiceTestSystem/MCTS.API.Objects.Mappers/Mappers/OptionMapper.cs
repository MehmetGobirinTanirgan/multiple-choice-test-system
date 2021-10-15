using AutoMapper;
using MCTS.API.Objects.Mappers.Dtos;
using MCTS.Core.Models;

namespace MCTS.API.Objects.Mappers.Mappers
{
    public class OptionMapper : Profile
    {
        public OptionMapper()
        {
            CreateMap<OptionCreateDTO, Option>().ReverseMap();
            CreateMap<OptionDTO, Option>().ReverseMap();
        }
    }
}
