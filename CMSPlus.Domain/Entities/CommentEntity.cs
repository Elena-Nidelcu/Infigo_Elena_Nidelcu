using System.ComponentModel.DataAnnotations;

namespace CMSPlus.Domain.Entities;

public class CommentEntity : BaseEntity
{
    public string FullName { get; set; } = null!; // Name of the person adding the comment
    public string Content { get; set; } = null!; // The actual comment

    // Foreign key to TopicEntity
    public int TopicId { get; set; }
    public TopicEntity Topic { get; set; } = null!;
}
