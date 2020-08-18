using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace forum_test.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string ArticleText { get; set; }
        public string UserId { get; set; }
        public int TopicId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}