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
        private List<PostContent> listPost = new List<PostContent>();

        static string postSave = "posts.txt"; // Filnamnet där posten sparas.

        public void ShowPost()
        {
            if (listPost.Count == 0)
            {
                Console.WriteLine("\nInga inlägg att visa.");
                return;
            }
            Console.WriteLine("\nAlla inlägg (nyast först): ");

            var sortedPost = listPost.OrderByDescending(i => i.dateTime);

            foreach (var post in sortedPost)
            {
                Console.WriteLine($"Datum: {post.dateTime}, Titel: {post.postTitle}, Innehåll: {post.Content}");
            }
        }
        public void SavedPost(PostContent content)
        {
            listPost.Add(content);
        }
        public void DeletePost()
        {
            Console.WriteLine("\nAnge titel för inlägget du vill ta bort.");
            string PostDelete = Console.ReadLine();

            var deletePost = listPost.FirstOrDefault(post => post.postTitle.Equals(PostDelete, StringComparison.OrdinalIgnoreCase));

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
    }
}


