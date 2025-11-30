using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Contact_Management.Services
{
    public static class FileStorage
    {
        private static readonly string filePath = "contacts.json";
        private static readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        public static List<Contact_Management.Models.Contact> Load()
        {
            if (!File.Exists(filePath))
                return new List<Contact_Management.Models.Contact>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Contact_Management.Models.Contact>>(json) 
                   ?? new List<Contact_Management.Models.Contact>();
        }

        public static void Save(List<Contact_Management.Models.Contact> contacts)
        {
            string json = JsonSerializer.Serialize(contacts, jsonOptions);
            File.WriteAllText(filePath, json);
        }
    }
}
