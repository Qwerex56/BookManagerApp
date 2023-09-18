using Common.EFCore.Models;
using LibrarySimService.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySim.Controllers;

[ApiController]
[Route("api/Book")]
public class BookController : ControllerBase
{
    private readonly BookService _bookService;

    public BookController(BookService injectedContext)
    {
        _bookService = injectedContext;
    }

    [HttpGet(Name = "GetLibraryBooks")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
    public IActionResult Get()
    {
        var allBooks = _bookService.GetAllBooks();
        return Ok(allBooks);
    }

    [HttpPost(Name = "AddLibraryBook")]
    public IActionResult Post(string author, string title, int? year)
    {
        var book = new Book
        {
            Author = author,
            Title = title,
            Year = year
        };
        var response = _bookService.CreateBook(book);
        
        return Ok();
    }

    [HttpPost("newBook")]
    public IActionResult CreateBook([FromBody]Book book)
    {
        var result = _bookService.CreateBook(book);
        if (!result)
        {
            return BadRequest();
        }
        
        return Ok();
    }

    [HttpDelete(Name = "DeleteBookById")]
    public IActionResult DeleteById(int bookId)
    {
        var result = _bookService.DeleteBook(bookId);
        if (!result)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpDelete("id/{bookIds}" ,Name = "DeleteBooksByIds")]
    public IActionResult DeleteByIds(IEnumerable<int> bookIds)
    {
        if (bookIds.Select(bookId => _bookService.DeleteBook(bookId)).Any(result => !result))
        {
            return BadRequest();
        }
    
        return Ok();
    }
}