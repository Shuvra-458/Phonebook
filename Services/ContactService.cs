using System;
using System.Collections.Generic;
using System.Linq;
using Contact_Management.Models;
using Contact_Management.Utils;
using Contact_Management.Services;

namespace Contact_Management.Services
{
    public class ContactService
    {
        private List<Contact> contacts;
        private int nextId;

        public ContactService()
        {
            contacts = FileStorage.Load();
            nextId = contacts.Any() ? contacts.Max(c => c.Id) + 1 : 1;
        }

        public void AddContact()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter phone: ");
            string phone = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter address: ");
            string address = Console.ReadLine();

            contacts.Add(new Contact
            {
                Id = nextId++,
                Name = name,
                Phone = phone,
                Email = email,
                Address = address
            });

            FileStorage.Save(contacts);
            Console.WriteLine("Contact added!");
        }

        public void ViewAll()
        {
            if (!contacts.Any())
            {
                Console.WriteLine("No contacts found!");
                return;
            }

            Console.WriteLine("\n--- All Contacts ---");
            foreach (var c in contacts.OrderBy(c => c.Name))
                Console.WriteLine(c);
        }

        public void Search()
        {
            Console.Write("Search term: ");
            string term = Console.ReadLine()?.ToLower();

            var results = contacts
                .Where(c => c.Name.ToLower().Contains(term)
                        || c.Phone.Contains(term))
                .ToList();

            if (!results.Any())
            {
                Console.WriteLine("No results found!");
                return;
            }

            Console.WriteLine($"\nFound {results.Count}:");
            results.ForEach(Console.WriteLine);
        }

        public void Update()
        {
            Console.Write("Enter ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID!");
                return;
            }

            var c = contacts.FirstOrDefault(x => x.Id == id);
            if (c == null)
            {
                Console.WriteLine("Contact not found!");
                return;
            }

            Console.WriteLine($"Editing {c}\nEnter to keep existing");

            Console.Write($"Name [{c.Name}]: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name)) c.Name = name;

            Console.Write($"Phone [{c.Phone}]: ");
            string phone = Console.ReadLine();
            if (!string.IsNullOrEmpty(phone)) c.Phone = phone;

            Console.Write($"Email [{c.Email}]: ");
            string email = Console.ReadLine();
            if (!string.IsNullOrEmpty(email)) c.Email = email;

            Console.Write($"Address [{c.Address}]: ");
            string address = Console.ReadLine();
            if (!string.IsNullOrEmpty(address)) c.Address = address;

            FileStorage.Save(contacts);
            Console.WriteLine("Updated!");
        }

        public void Delete()
        {
            Console.Write("Enter ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID!");
                return;
            }

            var c = contacts.FirstOrDefault(x => x.Id == id);
            if (c == null)
            {
                Console.WriteLine("Not found!");
                return;
            }

            Console.WriteLine($"Delete {c}? (y/n)");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                contacts.Remove(c);
                FileStorage.Save(contacts);
                Console.WriteLine("Deleted!");
            }
        }

        public void ExportCsv()
        {
            Console.Write("Enter CSV File Export Path: ");
            string path = Console.ReadLine();

            CsvService.ExportToCsv(contacts, path);
            ConsoleUI.Success("Contacts exported Successfully!");
        }
        
        public void ImportCsv()
        {
            Console.Write("Enter CSV File Path: ");
            string path = Console.ReadLine();

            var imported = CsvService.ImportFromCsv(path);

            foreach (var c in imported)
            {
                c.Id = nextId++;
                contacts.Add(c);
            }
            FileStorage.Save(contacts);
            ConsoleUI.Success($"{imported.Count} contacts imported ");
        }
    }
}
