using MCTS.Core.CoreMaps;
using MCTS.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCTS.DB.Maps
{
    public class QuestionMap : BaseEntityMap<Question>
    {
        public override void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(x => x.QuestionText).IsRequired();
            builder.Property(x => x.RightAnswer).IsRequired().HasMaxLength(100);
            base.Configure(builder);
        }
    }
}
