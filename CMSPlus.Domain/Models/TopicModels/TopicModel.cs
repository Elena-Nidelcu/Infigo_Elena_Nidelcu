using System;
using System.Collections.Generic;
using CMSPlus.Domain.Models.CommentModels;

namespace CMSPlus.Domain.Models.TopicModels
{
    public class TopicModel : BaseTopicModel
    {
        public TopicModel()
        {
            UpdatedOnUtc = CreatedOnUtc = DateTime.UtcNow;
            Comments = new List<CommentModel>();
        }

        public int Id { get; set; }
        public string SystemName { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime? CreatedOnUtc { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }

        // List of associated comments
        public List<CommentModel> Comments { get; set; }
    }
}
