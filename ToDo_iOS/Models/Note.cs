using System;
namespace ToDo_iOS.Models
{
    public class Note
    {
        string _id;
        public string Id { get => _id; set => _id = value; }

        string _content;
        public string Content { get => _content; set => _content = value; }

        Status _status;
        public Status Status { get => _status; set => _status = value; }

        DateTime _createdAt;
        public DateTime CreatedAt { get => _createdAt; set => _createdAt = value; }

        DateTime _updatedAt;
        public DateTime UpdatedAt { get => _updatedAt; set => _updatedAt = value; }

        public Note(string id,
                    string content,
                    Status status,
                    DateTime createdAt,
                    DateTime updatedAt)
        {
            _id = id;
            _content = content;
            _status = status;
            _createdAt = createdAt;
            _updatedAt = updatedAt;
        }
    }
}
