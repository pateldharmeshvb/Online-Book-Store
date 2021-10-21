using MediatR;
using OnlineBookstore.Application.Exceptions;
using OnlineBookstore.Application.Interfaces.Repositories;
using OnlineBookstore.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBookstore.Application.Features.Authors.Commands.DeleteAuthorById
{
    public class DeleteAuthorByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteAuthorByIdCommandHandler : IRequestHandler<DeleteAuthorByIdCommand, Response<int>>
        {
            private readonly IAuthorRepositoryAsync _AuthorRepository;
            public DeleteAuthorByIdCommandHandler(IAuthorRepositoryAsync AuthorRepository)
            {
                _AuthorRepository = AuthorRepository;
            }
            public async Task<Response<int>> Handle(DeleteAuthorByIdCommand command, CancellationToken cancellationToken)
            {
                var Author = await _AuthorRepository.GetByIdAsync(command.Id);
                if (Author == null) throw new ApiException($"Author Not Found.");
                await _AuthorRepository.DeleteAsync(Author);
                return new Response<int>(Author.AuthorId);
            }
        }
    }
}
