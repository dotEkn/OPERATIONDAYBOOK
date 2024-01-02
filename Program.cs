using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPERATIONDAYBOOK
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            //Kör menyn när man ska starta programmet.
            UserMenu userMenu = new UserMenu();
            userMenu.menuSelect();
        }
    }
}
