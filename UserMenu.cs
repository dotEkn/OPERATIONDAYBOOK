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
            Console.WriteLine("[1] Write a post." +
                "\n [2] Search for a older post." +
                "\n [3] Delete an old post.");

				menuSelect = Console.ReadLine();

            //Try catch system som fångar upp om man skulle skriva fel alternativ så kommer man tillbaka och kan göra rätt.
            

        }
    }
}
