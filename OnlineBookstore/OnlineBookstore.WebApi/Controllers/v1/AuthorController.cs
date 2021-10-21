using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Application.Features.Books.Commands;
using OnlineBookstore.Application.Features.Authors.Commands.CreateAuthor;
using OnlineBookstore.Application.Features.Authors.Commands.DeleteAuthorById;
using OnlineBookstore.Application.Features.Authors.Commands.UpdateAuthor;
using OnlineBookstore.Application.Features.Authors.Queries.GetAllAuthor;
using OnlineBookstore.Application.Features.Authors.Queries.GetAllAuthors;
using OnlineBookstore.Application.Features.Authors.Queries.GetAuthorById;
using OnlineBookstore.Application.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineBookstore.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AuthorController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllAuthorsParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllAthorsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetAuthorByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Post(CreateAuthorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> Put(int id, UpdateAuthorCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteAuthorByIdCommand { Id = id }));
        }
    }
}
