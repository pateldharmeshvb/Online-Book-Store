using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Application.Interfaces.Repositories;
using OnlineBookstore.Domain.Entities;
using OnlineBookstore.Infrastructure.Persistence.Contexts;
using OnlineBookstore.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.Infrastructure.Persistence.Repositories
{
    public class ProductRepositoryAsync : GenericRepositoryAsync<Book>, IBookRepositoryAsync
    {
        private readonly DbSet<Book> _products;

        public ProductRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _products = dbContext.Set<Book>();
        }

        public Task<bool> IsUniqueBarcodeAsync(string barcode)
        {
            return _products
                .AllAsync(p => p.Barcode != barcode);
        }
    }
}
