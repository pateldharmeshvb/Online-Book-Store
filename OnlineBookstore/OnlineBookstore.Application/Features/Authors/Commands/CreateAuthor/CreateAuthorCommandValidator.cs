using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using OnlineBookstore.Application.Interfaces.Repositories;
using OnlineBookstore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBookstore.Application.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        private readonly IAuthorRepositoryAsync AuthorRepository;

        public CreateAuthorCommandValidator(IAuthorRepositoryAsync AuthorRepository)
        {
            this.AuthorRepository = AuthorRepository;

            RuleFor(p => p.Topic)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniqueNameAsync).WithMessage("{PropertyName} already exists.");


            RuleFor(p => p.Dob)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();
        }

        private async Task<bool> IsUniqueNameAsync(string name, CancellationToken cancellationToken)
        {
            return await AuthorRepository.IsUniqueNameAsync(name);
        }
    }
}
