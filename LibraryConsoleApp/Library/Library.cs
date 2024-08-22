using System.Text.Json;
using LibraryConsoleApp.User;

namespace LibraryConsoleApp.Library;

public class Library
{
    public List<Book.Book> Books { get; set; } = new();
    public List<LibraryUser> Users { get; set; } = new();
    
    public void AddBook(Book.Book book)
    {
        Books.Add(book);
    }
    public void DeleteBook(string isbn)
    {
        Books.RemoveAll(book => book.ISBN == isbn);
    }
    public void UpdateBook(string isbn, Book.Book book)
    {
        foreach (var book1 in Books)
        {
            if (book1.ISBN == isbn)
            {
                book1.Title = book.Title;
                book1.Author = book.Author;
                book1.Year = book.Year;
                book1.ISBN = book.ISBN;
                book1.Borrowed = book.Borrowed;
            }
        }
    }
    public void BorrowBook(string isbn, string userName)
    {
        int index = Books.FindIndex(book => book.ISBN == isbn);
        Books[index].Borrowed = true;
        LibraryUser user = Users.Find(user => user.Name == userName);
        user.BorrowBook(Books[index]);
    }
    public void Save(string path)
    {
        string json = JsonSerializer.Serialize(Books, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
        string json1 = JsonSerializer.Serialize(Users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("users.json", json1);
    }
    public void Load(string path)
    {
        string json = File.ReadAllText(path);
        Books = JsonSerializer.Deserialize<List<Book.Book>>(json);
        string json1 = File.ReadAllText("users.json");
        Users = JsonSerializer.Deserialize<List<LibraryUser>>(json1);
        
    }
}