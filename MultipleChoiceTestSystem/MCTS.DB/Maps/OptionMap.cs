using MCTS.Core.CoreMaps;
using MCTS.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCTS.DB.Maps
{
    public class OptionMap : BaseEntityMap<Option>
    {
        public override void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.Property(x => x.OptionText).IsRequired().HasMaxLength(100);
            builder.Property(x => x.QuestionID).IsRequired();

            builder.HasOne(o => o.Question)
                .WithMany(q => q.Options)
                .HasForeignKey(o => o.QuestionID);

            base.Configure(builder);
        }
    }
}
