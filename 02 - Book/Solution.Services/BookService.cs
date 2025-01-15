using ErrorOr;
using Microsoft.EntityFrameworkCore;
using Solution.Core.Interfaces;
using Solution.Core.Models;
using Solution.DataBase;

namespace Solution.Services;

public class BookService(AppDbContext dbContext) : IBookService
{
    public async Task<ErrorOr<BookModel>> CreateAsync(BookModel book)
    {
        
        var isBookExists = await dbContext.Books.AnyAsync(x =>
            x.ISBN.ToLower() == book.ISBN.Value.ToLower());

        if (isBookExists)
        {
            return Error.Conflict(description: "A book with the same ISBN already exists.");
        }

        book.Id = Guid.NewGuid().ToString();

        BookEntity entity = book.ToEntity();

            await dbContext.Books.AddAsync(entity);
            await dbContext.SaveChangesAsync();

        return new BookModel(entity);
    }
}
