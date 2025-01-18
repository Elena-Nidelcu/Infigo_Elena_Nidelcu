using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Interfaces;
using CMSPlus.Services.Interfaces;

namespace CMSPlus.Services.Services;

public class TopicService:ITopicService
{
    private readonly ITopicRepository _repository;

    public TopicService(ITopicRepository repository)
    {
        _repository = repository;
    }

    public async Task<TopicEntity> GetById(int id)
    {
        return await _repository.GetById(id);
    }
    
    public async Task<TopicEntity?> GetBySystemName(string systemName)
    {
        return await _repository.GetBySystemName(systemName);
    }

    public async Task<IEnumerable<TopicEntity>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task Create(TopicEntity entity)
    {
        await _repository.Create(entity);
    }

    public async Task Update(TopicEntity entity)
    {
        await _repository.Update(entity);
    }

    public async Task Delete(int id)
    {
        await _repository.Delete(id);
    }
    public async Task AddComment(int topicId, CommentEntity comment)
    {
        var topic = await _repository.GetById(topicId);
        if (topic == null)
        {
            throw new Exception("Topic not found.");
        }

        topic.Comments ??= new List<CommentEntity>();
        topic.Comments.Add(comment);
        await _repository.Update(topic);
    }

    // Delete a comment from a topic
    public async Task DeleteComment(int topicId, int commentId)
    {
        var topic = await _repository.GetById(topicId);
        if (topic == null)
        {
            throw new Exception("Topic not found.");
        }

        var comment = topic.Comments?.FirstOrDefault(c => c.Id == commentId);
        if (comment == null)
        {
            throw new Exception("Comment not found.");
        }

        topic.Comments.Remove(comment);
        await _repository.Update(topic);
    }
}