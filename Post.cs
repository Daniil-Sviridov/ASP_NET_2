using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    internal class Post
    {  
        public int UserId { get; set; }
        public int Id { get; set; }
        public string? Title { get; set; }
        public string Body { get; set; }

        public override string ToString() => $"UserId:{UserId}\nId:{Id}\nTitle:{Title}\nBody:{Body}\n";
    }
}
