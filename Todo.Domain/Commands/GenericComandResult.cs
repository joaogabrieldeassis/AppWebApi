using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult() { }
        public GenericCommandResult(bool success, string mensagem, object data)
        {
            Success = success;
            Mensagem = mensagem;
            Data = data;
        }

        public bool Success { get; set; }
        public string Mensagem { get; set; }
        public object Data { get; set; }
    }
}