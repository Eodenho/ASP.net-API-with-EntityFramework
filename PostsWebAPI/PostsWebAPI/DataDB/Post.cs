using System;
using System.Collections.Generic;

namespace PostsWebAPI.DataDB
{
    public partial class Post
    {
        public int? UserId { get; set; }
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
    }
}
