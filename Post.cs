using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace OPERATIONDAYBOOK
{
    class Post
    {
        //Sparar inläggen
        public DateTime dateTime { get; set; }
        public string postTitle { get; set; }
        public string Content { get; set; }

        public Post (string title, DateTime date, string content)
        {
            title = postTitle;
            dateTime = date;
            Content = content;

        }
    }
}
