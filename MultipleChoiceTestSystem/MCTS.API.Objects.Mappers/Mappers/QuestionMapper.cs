using AutoMapper;
using MCTS.API.Objects.Mappers.Dtos;
using MCTS.Core.Models;

namespace MCTS.API.Objects.Mappers.Mappers
{
    public class QuestionMapper : Profile
    {
        public QuestionMapper()
        {
            CreateMap<QuestionDTO, Question>().ReverseMap();
            CreateMap<QuestionCreateDTO, Question>().ReverseMap();
        }
    }
}
