using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Data_Structures_And_Algorithm.Helpers;
using Data_Structures_And_Algorithm.SortingAlgorithms;

namespace Data_Structures_And_Algorithm
{
    public class Program : ConsoleReadKeyClearBehavior
    {
        public static bool ReturnToMainMenu { get; set; }

        public static void Main(string[] args)
        {
            ReturnToMainMenu = false;
            ShowMainMenu();
            Console.ResetColor();
        }

        private static readonly Dictionary<int, string> MainMenuOptions = new Dictionary<int, string>()
        {
            { 1, "Go to Sorting Menu" },
            { 2, "Exit" }
        };

        private static void ShowMainMenu()
        {
            Console.WriteLine("***MAIN MENU***\n\nChoose an option from the menu to get started...\n");
            foreach (KeyValuePair<int, string> option in MainMenuOptions)
                Console.WriteLine($"{option.Key}.) {option.Value}");
            Console.WriteLine();
            NavigateUsersRequest();
        }

        private static void NavigateUsersRequest()
        {
            int request = (int)GetUsersRequest(0);
            Console.Clear();
            switch (request)
            {
                case 1:
                    Sorting.ShowSortingMenu();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    ReadKeyAndClear();
                    Main(new string[] { });
                    break;
            }
        }

        private static object GetUsersRequest(int attempts)
        {
            if (attempts > 0)
            {
                Console.WriteLine("\nYour input is invalid. Try again.\n");
                ReadKeyAndClear();
                ShowMainMenu();
            }
            int request = 0;
            if (Int32.TryParse(Console.ReadLine(), out request) && MainMenuOptions.Keys.Contains(request))
                return request;
            return GetUsersRequest(++attempts);
        }
    }
}
