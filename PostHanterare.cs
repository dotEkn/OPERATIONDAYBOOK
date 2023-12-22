using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPERATIONDAYBOOK
{
    public class PostHanterare
    {
        static List<Post> postList = new List<Post>();
        static string postSave = "posts.txt"; // Filnamnet där posten sparas.
    }
    static void PostSave()
    {
        //StreamWriter
      /*  savePost(); Denna kommer att ladda filen när programmet startas, om det redan finns sparade inlägg */
      using (StreamWriter writer = new StreamWriter(postSave))
        {
            foreach (var post in postLista)
            {
                writer.WriteLine($"{post.Titel}|{post.postTitle}");
            }
        }
    }
}
