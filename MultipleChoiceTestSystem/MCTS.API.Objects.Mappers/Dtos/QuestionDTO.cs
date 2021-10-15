using System;
using System.Collections.Generic;

namespace MCTS.API.Objects.Mappers.Dtos
{
    public class QuestionDTO
    {
        public Guid ID { get; set; }
        public string QuestionText { get; set; }
        public string RightAnswer { get; set; }
        public List<OptionDTO> Options { get; set; }
    }
}
