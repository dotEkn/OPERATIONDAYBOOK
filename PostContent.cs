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
        public string BlogPost { get; set; }

        public static List<PostContent> postList = new List<PostContent>();
        static string postSave = "posts.txt"; // Filnamnet där posten sparas.

        public PostContent(string postTitle, DateTime postDate, string blogPost)
        {
            PostTitle = postTitle;
            PostDate = postDate.Date;
            BlogPost = blogPost;
        }

        public static void AddPost()

        {
            Console.WriteLine("Titel:");
            string postTitle = Console.ReadLine();
        
            //whileloop med true som gör att blir det fel så kommer man få nya försök att skriva rätt datum och ej kan lägga in bokstäver.
            bool dateTimeLoop = true;
            while (dateTimeLoop)
            {
                Console.WriteLine("Skriv Datum (DD/MM/YYYY): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime postDate))
                {
                    dateTimeLoop = false;

                    Console.WriteLine("Skriv ditt inlägg:");
                    string blogPost = Console.ReadLine();

                    //Lägger sedan in all info som användaren har skrivit och sparar det i en lista.
                    PostContent newPost = new PostContent(postTitle, postDate, blogPost);
                    postList.Add(newPost);
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
