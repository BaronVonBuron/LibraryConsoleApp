namespace LibraryConsoleApp.Book;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public string ISBN { get; set; }
    public bool Borrowed { get; set; }
    
    public Book(string title, string author, int year, string isbn, bool borrowed)
    {
        Title = title;
        Author = author;
        Year = year;
        ISBN = isbn;
        Borrowed = borrowed;
    }
    
    public override string ToString()
    {
        return $"Title: {Title}, Author: {Author}, Year: {Year}, ISBN: {ISBN}, Borrowed: {Borrowed}";
    }
}