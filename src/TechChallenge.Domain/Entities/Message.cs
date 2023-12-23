namespace TechChallenge.Domain.Entities;

public class Message
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string Title { get; private set; } = string.Empty;

    public string Content { get; private set; } = string.Empty;

    public MessageType MessageType { get; private set; } = MessageType.All;

    public DateTime CreatedAt { get; private set; } = DateTime.Now;

    public static class Factory
    {
        public static Message New(string title, string content)
        {
            return new Message {Title = title, Content = content};
        }

        public static Message FromId
        (
            Guid messageId,
            string title,
            string content,
            DateTime createdAt,
            MessageType messageType
        )
        {
            return new Message
            {
                Id = messageId,
                Title = title,
                Content = content,
                CreatedAt = createdAt,
                MessageType = messageType
            };
        }
    }
}