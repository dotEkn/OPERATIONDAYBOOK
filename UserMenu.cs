using OPERATIONDAYBOOK;
using System;

public class UserMenu
{
	public UserMenu()
	{

	}

    public void MenuSelect()
	{

		//While loop som visar menu, menyn återkommer efter man fullbordat något av alternativen.
		int menuPick = 0;
		string menuSelect;

		while (true)
		{
            Console.WriteLine("\n [1] Skriv ett inlägg." +
                "\n [2] Visa gamla inlägg." +
                "\n [3] Leta efter specifikt inlägg." +
                "\n [4] Radera inlägg." +
                "\n [5] Avsluta program.");

            menuSelect = Console.ReadLine();

            //Try catch system som fångar upp om man skulle skriva fel alternativ så kommer man tillbaka och kan göra rätt.

            try
                    {
                if (!int.TryParse(menuSelect, out menuPick))
                {
                    throw new FormatException("Tryck mellan 1-5 för att avancera i menyn.");
                }
                if (menuPick is < 1 or > 5)
                {
                    throw new Exception("Alternativ är mellan 1 till 5.");
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
                    // Använder postcontent klassen som tar hand om att lägga till textfil när man trycker på alternativ 1.
                    PostContent.AddPost();
                    break;

                case 2:
                    // Använder PostHanterare klassen som visar alla inlägg man gjort om man trycker på alternativ 2.
                    PostManager.ShowPost();

                    break;

                case 3:
                    // Använder PostHanterare klassen som visar inlägg man vill söka på om man trycker på alternativ 3.
                    PostManager.SearchPost();
                    break;

                case 4:
                    // Använder PostHanterare klassen som raderar inlägg.
                    PostManager.DeletePost();
                    break;

                case 5:
                    // Använder PostHanterare klassen som sparar alla inlägg man skrivit i ett textdokument.
                    PostManager.SavePostToFile();
                    return;

                default:
                    break;
            }
        }
    }
}
