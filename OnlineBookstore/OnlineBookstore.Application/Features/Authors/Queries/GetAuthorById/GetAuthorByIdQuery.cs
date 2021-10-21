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

namespace OnlineBookstore.Application.Features.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQuery : IRequest<Response<Domain.Entities.Author>>
    {
        public int Id { get; set; }
        public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Response<Domain.Entities.Author>>
        {
            private readonly IAuthorRepositoryAsync _AuthorRepository;
            public GetAuthorByIdQueryHandler(IAuthorRepositoryAsync AuthorRepository)
            {
                _AuthorRepository = AuthorRepository;
            }
            public async Task<Response<Domain.Entities.Author>> Handle(GetAuthorByIdQuery query, CancellationToken cancellationToken)
            {
                var Author = await _AuthorRepository.GetByIdAsync(query.Id);
                if (Author == null) throw new ApiException($"Author Not Found.");
                return new Response<Domain.Entities.Author>(Author);
            }
        }
    }
}
