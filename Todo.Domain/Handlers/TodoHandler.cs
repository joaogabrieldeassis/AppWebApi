using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : Notifiable,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MarkTodoAsDoneCommand>,
        IHandler<MarkTodoAsUnDoneCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            //Cria uma tarefa
            var todo = new TodoItem(command.Title, command.User, command.Date);

            //Salva no banco
            _repository.Create(todo);
            return new GenericCommandResult(true, "Tarefa salva", todo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)

        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "A atualização não pode ser concluida", command.Notifications);

            //Recupera o usuario
            var todo = _repository.GetById(command.Id, command.User);

            //Altera o usuario 
            todo.UpdateTitle(command.Title);

            //salva no banco
            _repository.Update(todo);

            return new GenericCommandResult(true, "As alterações foram salvas com sucesso", command.Notifications);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Não foi possivel Marcar a tarefa como concluida", command.Notifications);

            //Recupera o usuario
            var todo = _repository.GetById(command.Id, command.User);

            //Marca a tarefa como concluida
            todo.MarkAsDone();

            _repository.Update(todo);

            return new GenericCommandResult(true, "A tarefa foi marcada como concluida com sucesso", command.Notifications);
        }

        public ICommandResult Handle(MarkTodoAsUnDoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Não foi possivel atualizar a tarefa", command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);

            todo.MarkAsUndone();

            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa alterada com sucesso", command.Notifications);


        }
    }
}