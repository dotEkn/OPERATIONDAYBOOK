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
        //Här skapas lista som sparar alla inlägg man skrivit.
        public static PostHanterare postHanterare = new PostHanterare();

        public static List<PostContent> postList = PostContent.postList;
        //Skapas en textfil.
        static string postSave = "posts.txt"; // Filnamnet där posten sparas.

        //Metod ShowPost som ska visa alla inlägg som finns sparade.
        public static void ShowPost()
        {
            Console.Clear();

            //If-sats som ska visa inlägg om det finns mer än 1 inlägg sparat annars ger den felmeddelande att inga inlägg finns att visa.
            if (postList.Count == 0)
            {
                Console.WriteLine("Inga inlägg att visa.");
                return;
            }
            Console.WriteLine("Alla inlägg (nyast först): ");

            //Här sorteras inläggen efter datum ordning.
            var sortedPost = postList.OrderByDescending(i => i.PostDate);

            //Presenteras inlägget som man har skrivit med datum, titel och innehåll.
            foreach (var post in sortedPost)
            {
                Console.WriteLine($"\nDatum: {post.PostDate.ToString("MM/dd/yyyy")}, Titel: {post.PostTitle}, Innehåll: {post.BlogPost}");
            }
        }

        public static void SearchPost()
        {
            /*
            * När man söker efter titel, hur "accurate" måste sökningen vara, kan det räcka med att man skriver in 3 bokstäver/siffror och så får man upp resterande
            * inlägg som har dem i sig i titeln, eller måste det bara vara just ETT inlägg som dyker upp? Exempel: Någon skriver in i programmet där dem vill använda
            * ordet 'MAT', så som Matbord, Matråd, Matrecept, Matlista. Då kommer alla komma upp om man inte blir mer specifik, hur mycket påverkar det?.
            */
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

            //Skapar en lista för att lagra matchande inlägg.
            List<PostContent> matchingPosts = new List<PostContent>();

            //Går igenom varje inlägg i postList listan och jämför titlarna med söktermen.
            foreach (var post in postList)
            {
                // Använd IndexOf för att söka efter delar av titeln som matchar söktermen
                // StringComparison.OrdinalIgnoreCase gör att sökningen är case-insensitive.
                if (post.PostTitle.IndexOf(SearchMatch, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    //Om titel innehåller sökterm så lägg till det inlägget i listan av matchade inlägg.
                    matchingPosts.Add(post);
                }
            }
            //IF-sats som skriver ut om det finns matchade inlägg.
            if (matchingPosts.Count > 0)
            {
                Console.WriteLine("\nMatchande inlägg:");
                foreach (var post in matchingPosts)
                {
                    //Skriver ut datum, titel och innehåll.
                    Console.WriteLine($"Datum: {post.PostDate.ToString("MM/dd/yyyy")}, Titel: {post.PostTitle}, Innehåll: {post.BlogPost}");
                }
            }
            else
            {
                Console.WriteLine("\nInga matchande inlägg hittades.");
            }
        }
        public void DeletePost()
        {
            //Frågar användaren efter titel på inlägget som ska tas bort. (Måste vara fullständigt titelnamn.)
            Console.WriteLine("\nAnge titel för inlägget du vill ta bort.");
            Console.Clear();

            Console.WriteLine("\nAnge titel för inlägget du vill ta bort. Titelnamnet måste vara precist.");
            string PostDelete = Console.ReadLine();

            // Sök efter det första inlägget med den angivna titeln i listan av inlägg. (postList)
            var deletePost = postList.FirstOrDefault(PostContent => PostContent.PostTitle.Equals(PostDelete, StringComparison.OrdinalIgnoreCase));

            //IF-Sats Om inlägg hittades med rätt titel.
            if (PostDelete != null)
            {
                //Tas inlägget bort.
                postList.Remove(deletePost);
                Console.WriteLine("\nInlägget har tagits bort.");
            }
            else
            {
                //Annars kommer felmeddelande att inlägg kunde ej hittas.
                Console.WriteLine("Inlägget kunde inte hittas.");
            }
        }
        public static void SavePostToFile()
        {
            //Använder try-catch när man skapat en fil och ska skicka data till filen.
            try
            {
                //Öppnar Streamwriter för att skriva till filen.
                using (StreamWriter sw = new StreamWriter(postSave))
                {
                    //loopar igenom varje inlägg som skapats och skriver till filen.
                    foreach (var post in postHanterare.GetPostsFromList())
                    {
                        //Skriver datum, titel och innehåll till filen.
                        sw.WriteLine($"{post.PostDate.ToString("MM/dd/yyyy")}, {post.PostTitle}, {post.BlogPost}");
                    }
                }
            }
            catch (Exception ex)
            {
                //Felhanterare som skriver ut felmeddelande om ett ej går att skriva till textfil.
                Console.WriteLine($"Fel vid sparande till fil: {ex.Message}");
            }
        }

        public List<PostContent> GetPostsFromList()
        {
            //Returerar listan med alla inlägg.
            return postList;
        }
    }

}


