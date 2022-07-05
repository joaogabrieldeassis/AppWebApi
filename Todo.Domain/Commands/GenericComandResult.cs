using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class GenericComandResult : ICommandResult
    {
        public GenericComandResult() { }
        public GenericComandResult(bool success, string mensagem, string data)
        {
            Success = success;
            Mensagem = mensagem;
            Data = data;
        }

        public bool Success { get; set; }
        public string Mensagem { get; set; }
        public string Data { get; set; }
    }
}