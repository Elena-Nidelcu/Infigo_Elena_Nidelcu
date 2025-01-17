using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMSPlus.Domain.Entities;

public class CommentEntity : BaseEntity
{
    public string FullName { get; set; } = null!;
    public string Content { get; set; } = null!;
    public int TopicId { get; set; }
    public TopicEntity Topic { get; set; } = null!;
}
