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
    public class AuthorRepositoryAsync : GenericRepositoryAsync<Author>, IAuthorRepositoryAsync
    {
        private readonly DbSet<Author> _authors;

        public AuthorRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _authors = dbContext.Set<Author>();
        }

        public Task<bool> IsUniqueNameAsync(string name)
        {
            return _authors
                .AllAsync(p => p.Name != name);
        }
    }
}
