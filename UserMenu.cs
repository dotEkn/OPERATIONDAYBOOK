using OPERATIONDAYBOOK;
using System;

public class UserMenu
{
	public UserMenu()
	{

	}

    public void menuSelect()
	{

		//While loop som visar menu, menyn återkommer efter man fullbordat något av alternativen.
		int menuPick = 0;
		string menuSelect;

		while (true)
		{
            Console.WriteLine(" [1] Write a post." +
                "\n [2] Search for a older post." +
                "\n [3] Delete an old post." +
                "\n [4] Exit program.");

            menuSelect = Console.ReadLine();

            //Try catch system som fångar upp om man skulle skriva fel alternativ så kommer man tillbaka och kan göra rätt.

            try
                    {
                if (!int.TryParse(menuSelect, out menuPick))
                {
                    throw new FormatException("Press number 1 to 3 to advance in the menu.");
                }
                if (menuPick is < 1 or > 3)
                {
                    throw new Exception("Alternative is number 1 to 3");
                }
            }
            catch (ArgumentOutOfRangeException wrongMenu)
            {
                Console.WriteLine($"Error: {wrongMenu.Message}");
            }
            catch (ArgumentException wrongMenu)
            {
                Console.WriteLine($"Error: {wrongMenu.Message}");
            }
            catch (FormatException wrongMenu)
            {
                Console.WriteLine($"Error: {wrongMenu.Message}");
            }
            catch (Exception wrongMenu)
            {
                Console.WriteLine($"An unexpected error occurred: {wrongMenu.Message}");
            }


            //switch sats som ska t.ex lägga till person om hen trycker på 1.
            switch (menuPick)
            {
                case 1:
                    
                    PostContent.AddPost(); // Använder postcontent klassen som tar hand om att lägga till textfil när man trycker på alternativ 1.
                    break;

                case 2:

                    PostHanterare.SavePostToFile();

                    break;

                case 3:

                    break;

                case 4:

                    return;
                default:
                    break;
            }
        }
    }
}
