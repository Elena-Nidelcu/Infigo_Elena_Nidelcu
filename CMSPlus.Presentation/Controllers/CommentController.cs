using CMSPlus.Domain.Entities;
using CMSPlus.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMSPlus.Presentation.Controllers;

public class CommentController : Controller
{
    private readonly ITopicService _topicService;

    public CommentController(ITopicService topicService)
    {
        _topicService = topicService;
    }

    [HttpPost]
    public async Task<IActionResult> AddComment(int topicId, string commentText)
    {
        if (string.IsNullOrWhiteSpace(commentText))
        {
            return BadRequest("Comment cannot be empty.");
        }

        // Add the comment to the topic
        var topic = await _topicService.GetById(topicId);
        if (topic == null)
        {
            return NotFound("Topic not found.");
        }

        topic.Comments ??= new List<CommentEntity>();
        topic.Comments.Add(new CommentEntity
        {
            Content = commentText,
            CreatedOnUtc = DateTime.UtcNow
        });

        await _topicService.Update(topic);

        return RedirectToAction("Details", "Topic", new { systemName = topic.SystemName });
    }

    [HttpPost]
    public async Task<IActionResult> DeleteComment(int topicId, int commentId)
    {
        var topic = await _topicService.GetById(topicId);
        if (topic == null)
        {
            return NotFound("Topic not found.");
        }

        var comment = topic.Comments?.FirstOrDefault(c => c.Id == commentId);
        if (comment == null)
        {
            return NotFound("Comment not found.");
        }

        topic.Comments.Remove(comment);
        await _topicService.Update(topic);

        return RedirectToAction("Details", "Topic", new { systemName = topic.SystemName });
    }
}
