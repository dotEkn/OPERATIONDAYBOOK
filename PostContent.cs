using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace OPERATIONDAYBOOK
{
    public class PostContent
    {
        //Sparar inläggen
        public DateTime dateTime { get; set; }
        public string postTitle { get; set; }
        public string Content { get; set; }
    }
}
