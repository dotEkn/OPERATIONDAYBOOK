using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPERATIONDAYBOOK
{
    public class TestList
    {
        public void UseListPC()
        {
            var PCLIST = PostHanterare.postHanterare.GetPostsFromList();

            foreach (var postContent in PCLIST) {
            Console.WriteLine(postContent);}
        }
    }
}
