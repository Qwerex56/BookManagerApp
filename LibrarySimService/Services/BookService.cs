using System.Collections.Immutable;
using Common.EFCore.Models;
using LibrarySimService.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibrarySimService.Services;

public class BookService : IBookService
{
    private readonly LibraryContext _bookDb;

    public BookService(LibraryContext context)
    {
        _bookDb = context;
    }
    
    public IEnumerable<Book> GetAllBooks()
    {
        return _bookDb.Books.ToImmutableList();
    }

    public Book? GetBookById(int bookId)
    {
        return _bookDb.Books.FirstOrDefault(b => b.BookId == bookId);
    }

    public bool CreateBook(Book book)
    {
        // TODO:
        // book params validation
        if (book.Title.Length <= 0 || book.Author.Length <= 0)
        {
            return false;
        }

        _bookDb.Books.Add(book);
        _bookDb.SaveChanges();
        return true;
    }

    public bool UpdateTitle(int bookId, string newTitle)
    {
        var book = GetBookById(bookId);
        if (book is null)
        {
            return false;
        }

        book.Title = newTitle;
        _bookDb.SaveChanges();
        return true;
    }

    public bool DeleteBook(int bookId)
    {
        var book = _bookDb.Books.Find(bookId);
        if (book is null)
        {
            return false;
        }

        _bookDb.Books.Remove(book);
        _bookDb.SaveChanges();
        return true;
    }
}