using MCTS.Core.CoreEntites.Concrete;
using System.Collections.Generic;

namespace MCTS.Core.Models
{
    public class Question : BaseEntity
    {
        public string QuestionText { get; set; }
        public string RightAnswer { get; set; }
        public virtual List<Option> Options { get; set; }
    }
}
