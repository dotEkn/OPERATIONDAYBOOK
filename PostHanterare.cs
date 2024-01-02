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
        public static List<Post> postList = new List<Post>();
        static string postSave = "posts.txt"; // Filnamnet där posten sparas.
    }
    
    public void SavePost()
    {
        //StreamWriter gör så att programmet själv skriver in i filen, så att inte en användare behöver göra det och få åtkomst.
        //Lite googling så var StreamWriter ett bra sätt att skriva in i fil, då "programmet" är det enda som har åtkomst för att ändra, samt vi.
      /*  savePost(); Denna kommer att ladda filen när programmet startas, om det redan finns sparade inlägg */
      using (StreamWriter writer = new StreamWriter(postSave))
        {
            foreach (var post in postList)
            {
                writer.WriteLine($"{post.Titel}|{post.postTitle}");
            }
        }
    }
}

