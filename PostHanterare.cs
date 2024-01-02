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
        public void SavedPost(PostContent content)
        {
            postList.Add(content);
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
        public List<PostContent> GetPostsFromList()
        {
            return postList;
        }
    }
}


