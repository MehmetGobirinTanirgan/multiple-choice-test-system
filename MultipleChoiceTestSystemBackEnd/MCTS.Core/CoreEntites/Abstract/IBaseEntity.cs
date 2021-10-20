using System;

namespace MCTS.Core.CoreEntites.Abstract
{
    public interface IBaseEntity
    {
        Guid ID { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}
