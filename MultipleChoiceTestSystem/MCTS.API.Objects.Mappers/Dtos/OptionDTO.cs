using System;

namespace MCTS.API.Objects.Mappers.Dtos
{
    public class OptionDTO
    {
        public string OptionText { get; set; }
        public Guid QuestionID { get; set; }
    }
}
