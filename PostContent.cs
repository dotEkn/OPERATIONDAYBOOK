using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace OPERATIONDAYBOOK
{

    public class Post
    {
        //Sparar inläggen
        public DateTime PostDate { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }

        public static List<Post> postList = new List<Post>();
        static string postSave = "posts.txt"; // Filnamnet där posten sparas.

        public Post(string postTitle, DateTime postDate)
        {
            PostTitle = postTitle;
            PostDate = postDate;
        }

        public static void AddPost()

        {
            Console.WriteLine("Titel:");
            string postTitle = Console.ReadLine();

            Console.WriteLine("Enter Datum (MM/DD/YYYY): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime postDate))
            {
                Post newPost = new Post(postTitle, postDate);
                postList.Add(newPost);

                Console.WriteLine("Inlägg tillagt!");
            }
            else
            {
                Console.WriteLine("Ogiltigt datumformat. Försök igen.");
            }
        }


    }
    
}
