
using LibraryConsoleApp.Book;
using LibraryConsoleApp.Library;
using LibraryConsoleApp.User;

bool running = true;
Library library = new();
string path = "library.json";
library.Load(path);
while (running)
{
    Console.WriteLine("1. Add a book");
    Console.WriteLine("2. Delete a book");
    Console.WriteLine("3. Update a book");
    Console.WriteLine("4. Borrow a book");
    Console.WriteLine("5. Save and exit");
    Console.WriteLine("6. Exit without saving");
    Console.WriteLine("7. List all books");
    Console.WriteLine("8. Usermenu");
    Console.Write("Enter a number: ");
    string input = Console.ReadLine();
    switch (input)
    {
        case "1":
            CreateNewBook();
            break;
        case "2":
            DeleteBook();
            break;
        case "3":
            UpdateBook();
            break;
        case "4":
            BorrowABook();
            break;
        case "5":
            UpdateLibrary();
            running = false;
            break;
        case "6":
            running = false;
            break;
        case "7":
            ListAllBooks();
            break;
        case "8":
            UserMenu();
            break;
        default:
            Console.WriteLine("Invalid input");
            break;
    }
}

void ListAllBooks()
{
    foreach (var libraryBook in library.Books)
    {
        Console.WriteLine(libraryBook.ToString());
    }
}

void BorrowABook()
{
    Console.WriteLine("Enter the ISBN of the book you want to borrow");
    string isbnToBorrow = Console.ReadLine();
    Console.WriteLine("Enter your name");
    string userName = Console.ReadLine();
    library.BorrowBook(isbnToBorrow, userName);
    Console.WriteLine("Book borrowed");
    UpdateLibrary();
}

void UpdateBook()
{
    Console.WriteLine("Enter the ISBN of the book you want to update");
    string isbnToUpdate = Console.ReadLine();
    Console.Write("Enter the title: ");
    string titleToUpdate = Console.ReadLine();
    Console.Write("Enter the author: ");
    string authorToUpdate = Console.ReadLine();
    Console.Write("Enter the year: ");
    int yearToUpdate = int.Parse(Console.ReadLine());
    Console.Write("Enter the ISBN: ");
    string isbnNew = Console.ReadLine();
    Book bookToUpdate = new(titleToUpdate, authorToUpdate, yearToUpdate, isbnNew, false);
    library.UpdateBook(isbnToUpdate, bookToUpdate);
    Console.WriteLine("Book updated");
    UpdateLibrary();
}

void CreateNewBook()
{
    Console.Write("Enter the title: ");
    string title = Console.ReadLine();
    Console.Write("Enter the author: ");
    string author = Console.ReadLine();
    Console.Write("Enter the year: ");
    int year = int.Parse(Console.ReadLine());
    Console.Write("Enter the ISBN: ");
    string isbn = Console.ReadLine();
    Book book = new(title, author, year, isbn, false);
    library.AddBook(book);
    Console.WriteLine("Book added");
    UpdateLibrary();
}

void DeleteBook()
{
    Console.WriteLine("Enter the ISBN of the book you want to delete");
    string ISBN = Console.ReadLine();
    library.DeleteBook(ISBN);
    Console.WriteLine("Book deleted");
    UpdateLibrary();
}

void UpdateLibrary(){
    library.Save(path);
    library.Load(path);
}

void UserMenu()
{
    bool usermenu = true;
    while (usermenu)
    {
        Console.WriteLine("1. Add a user");
        Console.WriteLine("2. Delete a user");
        Console.WriteLine("3. Update a user");
        Console.WriteLine("4. List all users");
        Console.WriteLine("5. Exit");
        Console.Write("Enter a number: ");
        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                AddAUser();
                break;
            case "2":
                DeleteAUser();
                break;
            case "3":
                UpdateAUser();
                break;
            case "4":
                ListAllUsers();
                break;
            case "5":
                usermenu = false;
                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }
    }
}
void ListAllUsers()
{
    foreach (var libraryUser in library.Users)
    {
        Console.WriteLine(libraryUser.ToString());
    }
}

void UpdateAUser()
{
    Console.WriteLine("Enter the name of the user you want to update");
    string nameToUpdate = Console.ReadLine();
    Console.Write("Enter the name: ");
    string nameNew = Console.ReadLine();
    Console.Write("Enter the email: ");
    string emailNew = Console.ReadLine();
    Console.Write("Enter the address: ");
    string addressNew = Console.ReadLine();
    Console.Write("Enter the phone number: ");
    string phoneNumberNew = Console.ReadLine();
    LibraryUser userToUpdate = new(nameNew, emailNew, addressNew, phoneNumberNew);
    library.Users.RemoveAll(user => user.Name == nameToUpdate);
    library.Users.Add(userToUpdate);
    Console.WriteLine("User updated");
}

void DeleteAUser()
{
    Console.WriteLine("Enter the name of the user you want to delete");
    string nameToDelete = Console.ReadLine();
    library.Users.RemoveAll(user => user.Name == nameToDelete);
    Console.WriteLine("User deleted");
}
    
void AddAUser()
{
    Console.Write("Enter the name: ");
    string name = Console.ReadLine();
    Console.Write("Enter the email: ");
    string email = Console.ReadLine();
    Console.Write("Enter the address: ");
    string address = Console.ReadLine();
    Console.Write("Enter the phone number: ");
    string phoneNumber = Console.ReadLine();
    LibraryUser user = new(name, email, address, phoneNumber);
    library.Users.Add(user);
    Console.WriteLine("User added");
}