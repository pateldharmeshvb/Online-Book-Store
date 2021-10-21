using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Application.Interfaces.Repositories;
using OnlineBookstore.Domain.Entities;
using OnlineBookstore.Infrastructure.Persistence.Contexts;
using OnlineBookstore.Infrastructure.Persistence.Repository;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnlineBookstore.Application.Features.Books.Queries.GetAllBooks;

namespace OnlineBookstore.Infrastructure.Persistence.Repositories
{
    public class BookRepositoryAsync : GenericRepositoryAsync<Book>, IBookRepositoryAsync
    {
        private readonly DbSet<Book> _books;
        private readonly ApplicationDbContext _context;

        public BookRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _books = dbContext.Set<Book>();
            _context = dbContext;
        }

        public Task<bool> IsUniqueBarcodeAsync(string barcode)
        {
            return _books
                .AllAsync(p => p.Barcode != barcode);
        }
    }
}
