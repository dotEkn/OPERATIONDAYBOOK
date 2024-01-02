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
        public DateTime PostDate { get; set; }
        public string PostTitle { get; set; }
        public string Content { get; set; }

        public static List<PostContent> postList = new List<PostContent>();
        static string postSave = "posts.txt"; // Filnamnet där posten sparas.

        public PostContent(string postTitle, DateTime postDate)
        {
            PostTitle = postTitle;
            PostDate = postDate;
        }

        public static void AddPost()

        {
            Console.WriteLine("Titel:");
            string postTitle = Console.ReadLine();

            bool dateTimeLoop = true;
            while (dateTimeLoop)
            {
                Console.WriteLine("Enter Datum (MM/DD/YYYY): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime postDate))
                {
                    PostContent newPost = new PostContent(postTitle, postDate);
                    postList.Add(newPost);

                    Console.WriteLine("´Datum tillagt!");
                    dateTimeLoop = false;
                }
                else
                {
                    Console.WriteLine("Ogiltigt datumformat. Var god försök igen.");
                    dateTimeLoop = true;

                }
            }




        }
    }





}
