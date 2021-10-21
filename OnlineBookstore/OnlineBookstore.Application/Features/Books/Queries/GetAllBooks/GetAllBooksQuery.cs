using AutoMapper;
using MediatR;
using OnlineBookstore.Application.DTOs.Book;
using OnlineBookstore.Application.Features.Books.Queries.GetAllBooks;
using OnlineBookstore.Application.Filters;
using OnlineBookstore.Application.Interfaces.Repositories;
using OnlineBookstore.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBookstore.Application.Features.Books.Queries.GetAllBook
{
    public class GetAllBooksQuery : IRequest<PagedResponse<IEnumerable<GetAllBooksViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllBookQueryHandler : IRequestHandler<GetAllBooksQuery, PagedResponse<IEnumerable<GetAllBooksViewModel>>>
    {
        private readonly IBookRepositoryAsync _bookRepository;
        private readonly IMapper _mapper;
        public GetAllBookQueryHandler(IBookRepositoryAsync bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllBooksViewModel>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllBooksParameter>(request);
            var book = await _bookRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var bookViewModel = _mapper.Map<IEnumerable<GetAllBooksViewModel>>(book);
            return new PagedResponse<IEnumerable<GetAllBooksViewModel>>(bookViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
