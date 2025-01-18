using System;
using CMSPlus.Domain.Models.CommentModels;

namespace CMSPlus.Domain.Models.CommentModels
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        // Full name of the person who made the comment
        public string FullName { get; set; }

        // ID of the topic the comment belongs to
        public int TopicId { get; set; }
    }
}
