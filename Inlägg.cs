using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPERATIONDAYBOOK
{
    public class Inlägg
    {
        //Sparar inläggen
        public int DateTime { get; set; }
        public string PostTitle { get; set; }
        public string Post { get; set; }

        public Inlägg(string postTitle, string post, int Date)
        {
            DateTime = Date;
            PostTitle = postTitle;
            Post = post;
        }

        public override string ToString()
        {
            return $"Date: {DateTime}" +
                $"\nTitle: {PostTitle}" +
                $"\nPost: {Post}";
        }

    }
}
