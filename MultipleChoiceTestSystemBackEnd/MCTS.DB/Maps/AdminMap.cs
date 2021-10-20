using MCTS.Core.CoreMaps;
using MCTS.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCTS.DB.Maps
{
    public class AdminMap : BaseEntityMap<Admin>
    {
        public override void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.Property(x => x.Fullname).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Username).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(20);
            builder.Property(x => x.EmailAddress).IsRequired().HasMaxLength(50);
            base.Configure(builder);
        }
    }
}
