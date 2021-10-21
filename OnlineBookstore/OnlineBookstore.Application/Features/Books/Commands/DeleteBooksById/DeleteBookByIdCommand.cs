using MediatR;
using OnlineBookstore.Application.Exceptions;
using OnlineBookstore.Application.Interfaces.Repositories;
using OnlineBookstore.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBookstore.Application.Features.Books.Commands.DeleteBookById
{
    public class DeleteBookByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteBookByIdCommandHandler : IRequestHandler<DeleteBookByIdCommand, Response<int>>
        {
            private readonly IBookRepositoryAsync _bookRepository;
            public DeleteBookByIdCommandHandler(IBookRepositoryAsync bookRepository)
            {
                _bookRepository = bookRepository;
            }
            public async Task<Response<int>> Handle(DeleteBookByIdCommand command, CancellationToken cancellationToken)
            {
                var book = await _bookRepository.GetByIdAsync(command.Id);
                if (book == null) throw new ApiException($"Book Not Found.");
                await _bookRepository.DeleteAsync(book);
                return new Response<int>(book.Id);
            }
        }
    }
}
