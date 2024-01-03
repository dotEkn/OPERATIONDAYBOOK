﻿using System;
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
            Console.Clear();

            if (postList.Count == 0)
            {
                Console.WriteLine("Inga inlägg att visa.");
                return;
            }
            Console.WriteLine("Alla inlägg (nyast först): ");

            var sortedPost = postList.OrderByDescending(i => i.PostDate);

            foreach (var post in sortedPost)
            {
                Console.WriteLine($"\nDatum: {post.PostDate.ToString("MM/dd/yyyy")}, Titel: {post.PostTitle}, Innehåll: {post.BlogPost}");
            }
        }
                /*
        * När man söker efter titel, hur "accurate" måste sökningen vara, kan det räcka med att man skriver in 3 bokstäver/siffror och så får man upp resterande
        * inlägg som har dem i sig i titeln, eller måste det bara vara just ETT inlägg som dyker upp? Exempel: Någon skriver in i programmet där dem vill använda
        * ordet 'MAT', så som Matbord, Matråd, Matrecept, Matlista. Då kommer alla komma upp om man inte blir mer specifik, hur mycket påverkar det?.
        */
        public static void SearchPostByTitle()
        {
            Console.Clear();
            Console.WriteLine("Ange del av titeln för inlägget du vill söka efter:");
            string SearchMatch = Console.ReadLine();

            List<PostContent> matchingPosts = new List<PostContent>();
            foreach (var post in postList)
            {
                if (post.PostTitle.IndexOf(SearchMatch, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    matchingPosts.Add(post);
                }
            }

            if (matchingPosts.Count > 0)
            {
                Console.WriteLine("\nMatchande inlägg:");
                foreach (var post in matchingPosts)
                {
                    Console.WriteLine($"\nDatum: {post.PostDate.ToString("MM/dd/yyyy")}, Titel: {post.PostTitle}, Innehåll: {post.BlogPost}");
                }
            }
            else
            {
                Console.WriteLine("\nInga matchande inlägg hittades.");
            }
        }


        public static void DeletePost()
        {
            Console.Clear();

            Console.WriteLine("\nAnge titel för inlägget du vill ta bort. Titelnamnet måste vara precist.");
            string PostDelete = Console.ReadLine();

            var deletePost = postList.FirstOrDefault(PostContent => PostContent.PostTitle.Equals(PostDelete, StringComparison.OrdinalIgnoreCase));

            if (PostDelete != null)
            {
                postList.Remove(deletePost);
                Console.WriteLine("\nInlägget har tagits bort.");
            }
            else
            {
                Console.WriteLine("\nInlägget kunde inte hittas.");
            }
        }
        public static void SavePostToFile()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(postSave, true))
                {
                    foreach (var post in postHanterare.GetPostsFromList())
                    {
                        sw.WriteLine($"{post.PostDate.ToString("MM/dd/yyyy")}, {post.PostTitle}, {post.BlogPost}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nFel vid sparande till fil: {ex.Message}");
            }
        }

        public List<PostContent> GetPostsFromList()
        {
            return postList;
        }
    }

}


