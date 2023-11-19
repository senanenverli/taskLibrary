using ConsoleApp21;

public class Book : IEntity
{
    public int Id { get; private set; }
    public string Name { get; }
    public string AuthorName { get; }
    public int PageCount { get; }
    public bool IsDeleted { get; private set; } = false;
    public static int Count { get; internal set; }

    public Book(string name, string authorName, int pageCount)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(authorName) || pageCount <= 0)
            throw new ArgumentException("Name, authorName, and pageCount are required.");

        Name = name;
        AuthorName = authorName;
        PageCount = pageCount;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Book ID: {Id}, Name: {Name}, Author: {AuthorName}, PageCount: {PageCount}, IsDeleted: {IsDeleted}");
    }

    public static bool operator >(Book b1, Book b2)
    {
        return b1.PageCount > b2.PageCount;
    }

    public static bool operator <(Book b1, Book b2)
    {
        return b1.PageCount < b2.PageCount;
    }
}