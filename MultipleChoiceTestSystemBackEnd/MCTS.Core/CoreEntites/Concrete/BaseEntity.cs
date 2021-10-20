using MCTS.Core.CoreEntites.Abstract;
using System;

namespace MCTS.Core.CoreEntites.Concrete
{
    public class BaseEntity : IBaseEntity
    {
        public Guid ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
