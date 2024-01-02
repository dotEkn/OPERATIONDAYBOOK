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
        static PostHanterare postHanterare = new PostHanterare();

        private List<Post> listPost = new List<Post>();

        static string postSave = "posts.txt"; // Filnamnet där posten sparas.

        public void ShowPost()
        {
            if (listPost.Count == 0)
            {
                Console.WriteLine("\nInga inlägg att visa.");
                return;
            }
            Console.WriteLine("\nAlla inlägg (nyast först): ");

            var sortedPost = listPost.OrderByDescending(i => i.PostDate);

            foreach (var post in sortedPost)
            {
                Console.WriteLine($"Datum: {post.PostDate}, Titel: {post.PostTitle}, Innehåll: {post.PostContent}");
            }
        }
        public void SavedPost(Post content)
        {
            listPost.Add(content);
        }
        public void DeletePost()
        {
            Console.WriteLine("\nAnge titel för inlägget du vill ta bort.");
            string PostDelete = Console.ReadLine();

            var deletePost = listPost.FirstOrDefault(PostContent => PostContent.PostTitle.Equals(PostDelete, StringComparison.OrdinalIgnoreCase));

            if (PostDelete != null)
            {
                listPost.Remove(deletePost);
                Console.WriteLine("Inlägget har tagits bort.");
            }
            else
            {
                Console.WriteLine("Inlägget kunde inte hittas.");
            }
        }
        static void SavePostToFile()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("Post.txt"))
                {
                    foreach (var post in postHanterare.GetPostsFromList())
                    {
                        sw.WriteLine($"{post.PostDate}, {post.PostTitle}, {post.PostContent}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid sparande till fil: {ex.Message}");
            }
        }
        public List<Post> GetPostsFromList()
        {
            return listPost;
        }
    }
}


