using MediatR;
using OnlineBookstore.Application.Exceptions;
using OnlineBookstore.Application.Interfaces.Repositories;
using OnlineBookstore.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBookstore.Application.Features.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Topic { get; set; }
        public DateTime Dob { get; set; }
        public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Response<int>>
        {
            private readonly IAuthorRepositoryAsync _AuthorRepository;
            public UpdateAuthorCommandHandler(IAuthorRepositoryAsync AuthorRepository)
            {
                _AuthorRepository = AuthorRepository;
            }
            public async Task<Response<int>> Handle(UpdateAuthorCommand command, CancellationToken cancellationToken)
            {
                var Author = await _AuthorRepository.GetByIdAsync(command.Id);

                if (Author == null)
                {
                    throw new ApiException($"Author Not Found.");
                }
                else
                {
                    Author.Name = command.Name;
                    Author.Topic = command.Topic;
                    Author.Dob = command.Dob;
                    await _AuthorRepository.UpdateAsync(Author);
                    return new Response<int>(Author.AuthorId);
                }
            }
        }
    }
}
