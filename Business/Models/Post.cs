using System;

namespace Business.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public DateTime PostedOn { get; set; }
        public int CategoryId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Category Category { get; set; }
    }
}
