using System;
using System.Collections.Generic;
using Contact_Management.Services;
using Contact_Management.Utils;

namespace Contact_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ContactService();

            var actions = new Dictionary<string, Action>
            {
                {"1", service.AddContact},
                {"2", service.ViewAll},
                {"3", service.Search},
                {"4", service.Update},
                {"5", service.Delete},
                {"7", service.ExportCsv},
                {"8", service.ImportCsv},
                {"9", ConsoleColorDemo}
            };

            ConsoleUI.Header("=== Contact Management System ===");

            while (true)
            {
                ConsoleUI.Info("\n1. Add Contact");
                ConsoleUI.Info("2. View All");
                ConsoleUI.Info("3. Search");
                ConsoleUI.Info("4. Update");
                ConsoleUI.Info("5. Delete");
                ConsoleUI.Info("6. Exit");
                ConsoleUI.Info("7. Export Contacts (CSV)");
                ConsoleUI.Info("8. Import Contacts (CSV)");
                ConsoleUI.Info("9. Show UI Color Demo");

                Console.Write("\nChoose option: ");
                string choice = Console.ReadLine();

                if (choice == "6")
                {
                    ConsoleUI.Success("Goodbye!");
                    break;
                }

                if (actions.ContainsKey(choice))
                    actions[choice]();
                else
                    ConsoleUI.Error("Invalid option!");
            }
        }

        private static void ConsoleColorDemo()
        {
            ConsoleUI.Header("=== Color Demo ===");
            ConsoleUI.Success("Success → Operation completed successfully");
            ConsoleUI.Error("Error → Something went wrong");
            ConsoleUI.Warning("Warning → Be careful here");
            ConsoleUI.Info("Info → Just an informational message");
        }
    }
}
