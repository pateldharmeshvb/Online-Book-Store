using AutoMapper;
using MediatR;
using OnlineBookstore.Application.DTOs.Author;
using OnlineBookstore.Application.Features.Authors.Queries.GetAllAuthors;
using OnlineBookstore.Application.Filters;
using OnlineBookstore.Application.Interfaces.Repositories;
using OnlineBookstore.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBookstore.Application.Features.Authors.Queries.GetAllAuthor
{
    public class GetAllAthorsQuery : IRequest<PagedResponse<IEnumerable<GetAllAuthorsViewModel>>>
    {
        public string Name { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAthorsQuery, PagedResponse<IEnumerable<GetAllAuthorsViewModel>>>
    {
        private readonly IAuthorRepositoryAsync _AuthorRepository;
        private readonly IMapper _mapper;
        public GetAllAuthorQueryHandler(IAuthorRepositoryAsync AuthorRepository, IMapper mapper)
        {
            _AuthorRepository = AuthorRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllAuthorsViewModel>>> Handle(GetAllAthorsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllAuthorsParameter>(request);
            var Author = await _AuthorRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var AuthorViewModel = _mapper.Map<IEnumerable<GetAllAuthorsViewModel>>(Author);
            return new PagedResponse<IEnumerable<GetAllAuthorsViewModel>>(AuthorViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
