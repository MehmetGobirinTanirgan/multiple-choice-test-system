using MCTS.Core.CoreEntites.Concrete;

namespace MCTS.Core.Models
{
    public class Admin : BaseEntity
    {
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
