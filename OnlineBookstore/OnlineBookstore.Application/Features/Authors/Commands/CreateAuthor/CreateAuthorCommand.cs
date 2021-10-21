using AutoMapper;
using MediatR;
using OnlineBookstore.Application.Interfaces.Repositories;
using OnlineBookstore.Application.Wrappers;
using OnlineBookstore.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBookstore.Application.Features.Authors.Commands.CreateAuthor
{
    public partial class CreateAuthorCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Topic { get; set; }
        public DateTime Dob { get; set; }
    }
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Response<int>>
    {
        private readonly IAuthorRepositoryAsync _AuthorRepository;
        private readonly IMapper _mapper;
        public CreateAuthorCommandHandler(IAuthorRepositoryAsync AuthorRepository, IMapper mapper)
        {
            _AuthorRepository = AuthorRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var Author = _mapper.Map<Author>(request);
            await _AuthorRepository.AddAsync(Author);
            return new Response<int>(Author.AuthorId);
        }
    }
}
