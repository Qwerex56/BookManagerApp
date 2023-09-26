using Common.EFCore.Models;

namespace LibrarySimService.Interfaces;


public interface IBookService
{
    IEnumerable<Book> GetAllBooks();
    Book? GetBookById(int bookId);
    bool CreateBook(Book book);
    bool UpdateTitle(int bookId, string newTitle);
    bool DeleteBook(int bookId);
}