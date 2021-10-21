using AutoMapper;
using MediatR;
using OnlineBookstore.Application.Interfaces.Repositories;
using OnlineBookstore.Application.Wrappers;
using OnlineBookstore.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBookstore.Application.Features.Books.Commands.CreateBook
{
    public partial class CreateBookCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public int AuthorRefId { get; set; }
    }
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Response<int>>
    {
        private readonly IBookRepositoryAsync _bookRepository;
        private readonly IMapper _mapper;
        public CreateBookCommandHandler(IBookRepositoryAsync bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);
            await _bookRepository.AddAsync(book);
            return new Response<int>(book.BookId);
        }
    }
}
