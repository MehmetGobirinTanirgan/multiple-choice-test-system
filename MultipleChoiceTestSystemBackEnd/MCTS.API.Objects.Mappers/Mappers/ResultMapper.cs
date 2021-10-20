using AutoMapper;
using MCTS.API.Objects.Mappers.Dtos;
using MCTS.Core.Models;

namespace MCTS.API.Objects.Mappers.Mappers
{
    public class ResultMapper :Profile
    {
        public ResultMapper()
        {
            CreateMap<ResultCreateDTO, Result>().ReverseMap();
            CreateMap<ResultDTO, Result>().ReverseMap();
        }
    }
}
