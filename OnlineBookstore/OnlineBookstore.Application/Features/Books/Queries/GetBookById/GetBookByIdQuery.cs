using MediatR;
using OnlineBookstore.Application.Exceptions;
using OnlineBookstore.Application.Interfaces.Repositories;
using OnlineBookstore.Application.Wrappers;
using OnlineBookstore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBookstore.Application.Features.Books.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<Response<Domain.Entities.Book>>
    {
        public int Id { get; set; }
        public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Response<Domain.Entities.Book>>
        {
            private readonly IBookRepositoryAsync _bookRepository;
            public GetBookByIdQueryHandler(IBookRepositoryAsync bookRepository)
            {
                _bookRepository = bookRepository;
            }
            public async Task<Response<Domain.Entities.Book>> Handle(GetBookByIdQuery query, CancellationToken cancellationToken)
            {
                var book = await _bookRepository.GetByIdAsync(query.Id);
                if (book == null) throw new ApiException($"Book Not Found.");
                return new Response<Domain.Entities.Book>(book);
            }
        }
    }
}
