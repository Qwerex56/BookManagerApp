using Common.EFCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySim.Controllers;

[ApiController]
[Route("api/Book")]
public class BookController : ControllerBase
{
    private readonly LibraryContext _db;
    
    public BookController(LibraryContext injectedContext)
    {
        _db = injectedContext;
    }

    [HttpGet(Name = "GetLibraryBooks")]
    public IEnumerable<Book> Get()
    {
        var books = _db.Books.OrderBy(b => b.Author);
        return books;
    }

    [HttpPost(Name = "PostLibraryBooks")]
    public void Post(string title, string author, int year)
    {
        _db.Books.Add(new Book
        {
            Title = title,
            Author = author,
            Year = year
        });

        _db.SaveChanges();
    }

    [HttpDelete(Name = "DeleteLibraryBook")]
    public void Delete(string title)
    {
        _db.Books.RemoveRange(_db.Books.Where(b => b.Title == title));
        _db.SaveChanges();
    }
}