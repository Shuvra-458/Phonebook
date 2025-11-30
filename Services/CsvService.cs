using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Contact_Management.Models;

namespace Contact_Management.Services
{
    public static class CsvService
    {
        private const string CsvFilePath = "contacts_export.csv";

        public static void ExportToCsv(List<Contact> contacts, string filePath = null)
        {
            filePath ??= CsvFilePath;


            var sb = new StringBuilder();
            sb.AppendLine("Id,Name,Phone,Email,Address");

            foreach (var c in contacts)
            {
                sb.AppendLine($"{c.Id},{c.Name},{c.Phone},{c.Email},{c.Address}");
            }

            File.WriteAllText(CsvFilePath, sb.ToString());
            Console.WriteLine($"Contacts exported to {filePath}");
        }

        public static List<Contact> ImportFromCsv(string filePath)
        {
            var imported = new List<Contact>();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("CSV file not found!");
                return imported;
            }

            var lines = File.ReadAllLines(filePath);

            for (int i = 1; i < lines.Length; i++)
            {
                var cols = lines[i].Split(',');
                if (cols.Length != 5) continue;

                imported.Add(new Contact
                {
                    Id = int.Parse(cols[0]),
                    Name = cols[1],
                    Phone = cols[2],
                    Email = cols[3],
                    Address = cols[4]
                });
            }

            Console.WriteLine($"Imported {imported.Count} contacts from CSV!");
            return imported;
        }
    }
}
