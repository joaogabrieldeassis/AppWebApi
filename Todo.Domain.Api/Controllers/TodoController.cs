using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    [Authorize]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable GetAll([FromServices] ITodoRepository todoRepository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return todoRepository.GetAll(user);
        }
        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone([FromServices] ITodoRepository todoRepository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return todoRepository.GetAllDone(user);
        }
        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUnDone([FromServices] ITodoRepository todoRepository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return todoRepository.GetAllUndone(user);
        }
        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDoneForToday([FromServices] ITodoRepository todoRepository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return todoRepository.GetByPeriod(user, DateTime.Now.Date,true);
        }
        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDoneForTomorrow([FromServices] ITodoRepository todoRepository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return todoRepository.GetByPeriod(user, DateTime.Now.Date.AddDays(1), true);
        }
        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUnDoneForTomorrow([FromServices] ITodoRepository todoRepository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return todoRepository.GetByPeriod(user, DateTime.Now.Date.AddDays(1), true);
        }
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateTodoCommand command,[FromServices] TodoHandler handler)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            command.User = user;
            return (GenericCommandResult)handler.Handle(command);
        }
        [Route("")]
        [HttpPut]
        public GenericCommandResult CreatePut([FromBody] UpdateTodoCommand command, [FromServices] TodoHandler handler)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }
        [Route("mark-as-done")]
        [HttpPut]
        public GenericCommandResult MarkAsDone([FromBody] MarkTodoAsDoneCommand command, [FromServices] TodoHandler handler)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }
        [Route("mark-as-undone")]
        [HttpPut]
        public GenericCommandResult MarkAsUnDone([FromBody] MarkTodoAsUndoneCommand command, [FromServices] TodoHandler handler)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}