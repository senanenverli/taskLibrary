class Program
{
    static void Main()
    {
        try
        {
            Library library = new Library(5);

            Book book1 = new Book("Book1", "Author1", 100);
            Book book2 = new Book("Book2", "Author2", 150);
            Book book3 = new Book("Book3", "Author3", 120);

            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);

            Book retrievedBook = library.GetBookById(6);
            retrievedBook.ShowInfo();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }
}