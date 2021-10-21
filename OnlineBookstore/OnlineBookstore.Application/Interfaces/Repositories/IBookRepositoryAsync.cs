using OnlineBookstore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.Application.Interfaces.Repositories
{
    public interface IBookRepositoryAsync : IGenericRepositoryAsync<Book>
    {
        Task<bool> IsUniqueBarcodeAsync(string barcode);
    }
}
