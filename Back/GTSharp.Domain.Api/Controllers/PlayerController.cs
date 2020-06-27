using System;
using System.Linq;
using System.Collections.Generic;
using GTSharp.Domain.Commands.Input;
using GTSharp.Domain.Commands.Output;
using GTSharp.Domain.Entities;
using GTSharp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GTSharp.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/players")]
    [Authorize]
    public class PlayerController : ControllerBase
    {
        [Route("")]
        // [HttpPost]
        // public GenericCommandResult Create([FromBody] CreatePlayerCommand command, [FromServices] PlayerHandler handler)
        // {
        //     command.Email = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
        //     command.Name = User.Claims.FirstOrDefault(x => x.Type == "name")?.Value;
        //     command.Avatar = User.Claims.FirstOrDefault(x => x.Type == "picture")?.Value;
        //     return (GenericCommandResult)handler.Handle(command);
        // }


        [Route("{id:guid}")]
        [HttpGet]
        public Player GetById([FromServices] IPlayerRepository repository, Guid id)
        {
            return repository.GetById(id);
        }

        [Route("all")]
        [HttpGet]
        public IEnumerable<Player> GetAll([FromServices] IPlayerRepository repository)
        {
            return repository.GetAll();
        }
    }
}