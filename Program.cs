﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPERATIONDAYBOOK
{
    internal class Program
    {
        static PostHanterare postHanterare = new PostHanterare();
        
        static void Main(string[] args)
        {
            //Kör menyn när man ska starta programmet.
            UserMenu userMenu = new UserMenu();
            userMenu.menuSelect();
        }
    }
}
