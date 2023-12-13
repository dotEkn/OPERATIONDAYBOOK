using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPERATIONDAYBOOK
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

        }
        static void Meny()
        {
            Console.Clear();
            Console.WriteLine("Välkommen till dagboken!");
            Console.WriteLine("Navigera med hjälp av siffror!");
            Console.WriteLine("1: Skapa ett inlägg!");
            Console.WriteLine("2: Sök efter inlägg!");
            Console.WriteLine("3: Radera ett inlägg!");

            string alternativ;
            alternativ = Console.ReadLine();


            switch(alternativ)
            {
                case "1":
                    Inlägg();
                    break;
                case "2":
                    Sök();
                    break;
                case "3":
                    Radera();
                    break;

            }
        }
        static void Inlägg()
        {
            //
        }
        static void Sök()
        {

        }
        static void Radera()
        {

        }
    }
}
