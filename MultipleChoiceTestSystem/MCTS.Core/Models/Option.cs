using MCTS.Core.CoreEntites;
using System;

namespace MCTS.Core.Models
{
    public class Option : BaseEntity
    {
        public string OptionText { get; set; }
        public Guid QuestionID { get; set; }
        public virtual Question Question { get; set; }
    }
}
