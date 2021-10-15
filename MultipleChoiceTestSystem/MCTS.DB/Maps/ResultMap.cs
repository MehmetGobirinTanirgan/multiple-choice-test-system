using MCTS.Core.CoreMaps;
using MCTS.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCTS.DB.Maps
{
    public class ResultMap : BaseEntityMap<Result>
    {
        public override void Configure(EntityTypeBuilder<Result> builder)
        {
            builder.Property(x => x.RightAnswerCt).IsRequired();
            builder.Property(x => x.WrongAnswerCt).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(50);
            builder.Property(x => x.EmailAddress).IsRequired().HasMaxLength(50);
            builder.Property(x => x.PhoneNumber).IsRequired(false).HasMaxLength(20);
            base.Configure(builder);
        }
    }
}
