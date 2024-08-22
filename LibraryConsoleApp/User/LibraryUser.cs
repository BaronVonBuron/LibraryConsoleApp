using System.Text;

namespace LibraryConsoleApp.User;

public class LibraryUser
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public List<Book.Book> BorrowedBooks { get; set; }
    
    public LibraryUser(string name, string email, string address, string phoneNumber)
    {
        Name = name;
        Email = email;
        Address = address;
        PhoneNumber = phoneNumber;
        BorrowedBooks = new();
    }
    
    public void BorrowBook(Book.Book book)
    {
        BorrowedBooks.Add(book);
    }
    
    public void ReturnBook(Book.Book book)
    {
        BorrowedBooks.Remove(book);
    }
    
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine($"Name: {Name}");
        sb.AppendLine($"Email: {Email}");
        sb.AppendLine($"Address: {Address}");
        sb.AppendLine($"Phone number: {PhoneNumber}");
        sb.AppendLine("Borrowed books:");
        foreach (var book in BorrowedBooks)
        {
            sb.AppendLine(book.ToString());
        }
        return sb.ToString();
    }
}