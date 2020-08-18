using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace forum_test.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    } 
}