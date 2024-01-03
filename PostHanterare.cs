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
        public static PostHanterare postHanterare = new PostHanterare();

        public static List<PostContent> postList = PostContent.postList;
        static string postSave = "posts.txt"; // Filnamnet där posten sparas.


        public static void ShowPost()
        {
            if (postList.Count == 0)
            {
                Console.WriteLine("\nInga inlägg att visa.");
                return;
            }
            Console.WriteLine("\nAlla inlägg (nyast först): ");

            var sortedPost = postList.OrderByDescending(i => i.PostDate);

            foreach (var post in sortedPost)
            {
                Console.WriteLine($"Datum: {post.PostDate.ToString("MM/dd/yyyy")}, Titel: {post.PostTitle}, Innehåll: {post.BlogPost}");
            }
        }
        /*
         * När man söker efter titel, hur "accurate" måste sökningen vara, kan det räcka med att man skriver in 3 bokstäver/siffror och så får man upp resterande
         * inlägg som har dem i sig i titeln, eller måste det bara vara just ETT inlägg som dyker upp? Exempel: Någon skriver in i programmet där dem vill använda
         * ordet 'MAT', så som Matbord, Matråd, Matrecept, Matlista. Då kommer alla komma upp om man inte blir mer specifik, hur mycket påverkar det?.
         */
        public void SavedPost(PostContent content)
        {
            postList.Add(content);
        }
        public void SearchPost()
        {

        }
        public void DeletePost()
        {
            Console.WriteLine("\nAnge titel för inlägget du vill ta bort.");
            string PostDelete = Console.ReadLine();

            var deletePost = postList.FirstOrDefault(PostContent => PostContent.PostTitle.Equals(PostDelete, StringComparison.OrdinalIgnoreCase));

            if (PostDelete != null)
            {
                postList.Remove(deletePost);
                Console.WriteLine("Inlägget har tagits bort.");
            }
            else
            {
                Console.WriteLine("Inlägget kunde inte hittas.");
            }
        }
        public static void SavePostToFile()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(postSave))
                {
                    foreach (var post in postHanterare.GetPostsFromList())
                    {
                        sw.WriteLine($"{post.PostDate.ToString("MM/dd/yyyy")}, {post.PostTitle}, {post.BlogPost}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid sparande till fil: {ex.Message}");
            }
        }

        public static void SearchPostByTitle()
        {
            Console.WriteLine("Ange del av titeln för inlägget du vill söka efter:");
            string searchTerm = Console.ReadLine();

            List<PostContent> matchingPosts = new List<PostContent>();
            foreach (var post in postList)
            {
                if (post.PostTitle.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    matchingPosts.Add(post);
                }
            }

            if (matchingPosts.Count > 0)
            {
                Console.WriteLine("Matchande inlägg:");
                foreach (var post in matchingPosts)
                {
                    Console.WriteLine($"Datum: {post.PostDate.ToString("MM/dd/yyyy")}, Titel: {post.PostTitle}, Innehåll: {post.BlogPost}");
                }
            }
            else
            {
                Console.WriteLine("Inga matchande inlägg hittades.");
            }
        }

        public List<PostContent> GetPostsFromList()
        {
            return postList;
        }
    }
}


