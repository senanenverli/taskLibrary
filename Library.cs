
using ConsoleApp21;

public class Library : IEntity
{
    public int Id { get; } 
    public int BookLimit { get; }
    public Book[] Books; 

    public Library(int bookLimit)
    {
        if (bookLimit <= 0)
            throw new ArgumentException("Book limit must be greater than zero.");

        BookLimit = bookLimit;
        Books = new Book[BookLimit];
        Id = 0; 
    }

    public void AddBook(Book book)
    {
        if (Id >= BookLimit)
        {
            throw new Utils.Exceptions.CapacityLimitException("Library is at full capacity.");
        }

        
        for (int i = 0; i < Id; i++)
        {
            if (Books[i] != null && !Books[i].IsDeleted && Books[i].Name == book.Name)
            {
                throw new Utils.Exceptions.AlreadyExistsException("Book with the same name already exists in the library.");
            }
        }

        book.Id = ++Id;
        Books[Id - 1] = book; 
    }

    public Book GetBookById(int id)
    {
        
        for (int i = 0; i < Id; i++)
        {
            if (Books[i] != null && Books[i].Id == id && !Books[i].IsDeleted)
            {
                return Books[i];
            }
        }

        throw new Utils.Exceptions.NotFoundException($"Book with ID {id} not found in the library.");
    }
}
