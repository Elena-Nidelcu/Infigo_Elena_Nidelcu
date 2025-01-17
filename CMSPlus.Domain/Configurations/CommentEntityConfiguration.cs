using CMSPlus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMSPlus.Domain.Configurations;

public class CommentEntityConfiguration : IEntityTypeConfiguration<CommentEntity>
{
    public void Configure(EntityTypeBuilder<CommentEntity> builder)
    {
        builder.ToTable("Comments");

        // Configure properties
        builder.Property(x => x.FullName).IsRequired();
        builder.Property(x => x.Content).IsRequired();

        // Configure relationships
        builder.HasOne(x => x.Topic)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.TopicId);
    }
}
