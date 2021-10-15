using MCTS.Core.CoreEntites;

namespace MCTS.Core.Models
{
    public class Result : BaseEntity
    {
        public int RightAnswerCt { get; set; }
        public int WrongAnswerCt { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
