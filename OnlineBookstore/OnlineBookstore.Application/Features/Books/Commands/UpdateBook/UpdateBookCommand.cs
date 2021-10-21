using MediatR;
using OnlineBookstore.Application.Exceptions;
using OnlineBookstore.Application.Interfaces.Repositories;
using OnlineBookstore.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBookstore.Application.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Response<int>>
        {
            private readonly IBookRepositoryAsync _bookRepository;
            public UpdateBookCommandHandler(IBookRepositoryAsync bookRepository)
            {
                _bookRepository = bookRepository;
            }
            public async Task<Response<int>> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
            {
                var book = await _bookRepository.GetByIdAsync(command.Id);

                if (book == null)
                {
                    throw new ApiException($"Book Not Found.");
                }
                else
                {
                    book.Name = command.Name;
                    book.Rate = command.Rate;
                    book.Description = command.Description;
                    await _bookRepository.UpdateAsync(book);
                    return new Response<int>(book.Id);
                }
            }
        }
    }
}
