using System;

namespace MCTS.Core.CoreEntites
{
    public class BaseEntity : IBaseEntity
    {
        public Guid ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
