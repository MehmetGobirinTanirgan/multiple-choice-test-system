using System.Collections.Generic;

namespace MCTS.API.Objects.Mappers.Dtos
{
    public class QuestionCreateDTO
    {
        public string QuestionText { get; set; }
        public string RightAnswer { get; set; }
        public List<OptionCreateDTO> Options { get; set; }

    }
}
