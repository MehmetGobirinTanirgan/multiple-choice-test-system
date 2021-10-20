using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCTS.API.Objects.Mappers.Dtos
{
    public class ResultDTO
    {
        public Guid ID { get; set; }
        public int RightAnswerCt { get; set; }
        public int WrongAnswerCt { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
