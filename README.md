# 📇 Contact Management System

A simple, clean, and production-grade **Console-based Contact Manager**
built in **C# (.NET)**.\
The application allows you to **add, update, delete, search, export, and
import contacts** with persistent storage.

## 🚀 Features

### 🔹 Core Functionalities

-   Add new contacts\
-   View all contacts\
-   Search contacts by name or phone\
-   Update existing contact\
-   Delete contact\
-   Persistent storage using local file system\
-   Auto-incrementing contact ID

### 🔹 CSV Support

-   Export all contacts to a CSV file\
-   Import contacts from an external CSV\
-   Automatically merges imported contacts\
-   Validates structure before import

### 🔹 Clean Architecture

-   **Models** (Contact.cs)\
-   **Services** (ContactService.cs, CsvService.cs)\
-   **Utils** (ConsoleUI.cs)\
-   **FileStorage** for persistent local saving

## 📁 Project Structure

    Contact_Management/
    ├── Models/
    │   └── Contact.cs
    ├── Services/
    │   ├── ContactService.cs
    │   └── CsvService.cs
    ├── Utils/
    │   └── ConsoleUI.cs
    ├── FileStorage.cs
    ├── Program.cs
    ├── README.md
    └── .gitignore

## 🛠️ Tech Stack

-   C#
-   .NET / .NET Core
-   File I/O for persistent storage\
-   CSV parsing\
-   Object-Oriented Design

## ▶️ How to Run

### 1. Clone the Repository

    git clone https://github.com/<your-username>/<your-repo>.git
    cd Contact_Management

### 2. Build the Project

    dotnet build

### 3. Run the Application

    dotnet run

## 📤 Export Contacts to CSV

Exports all contacts to:

    ./contacts_export.csv

## 📥 Import Contacts from CSV

Place a CSV file containing:

    Id,Name,Phone,Email,Address

Then provide the file path inside the program when prompted.

## 🧪 Sample CSV Format

    1,John Doe,9876543210,john@example.com,New York
    2,Alice Smith,9123456789,alice@gmail.com,California

## 🔮 Future Enhancements

-   JSON database support\
-   Tag-based contact grouping\
-   Search by email & address\
-   Duplicate entry detection\
-   Colored terminal output\
-   Undo last operation

## 📜 License

MIT License

## 🤝 Contributing

Pull requests are welcome.

