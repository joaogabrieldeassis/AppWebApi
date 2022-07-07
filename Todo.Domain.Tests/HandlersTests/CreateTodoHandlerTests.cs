using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlersTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        private readonly CreateTodoCommand _Invalid = new CreateTodoCommand("", "", DateTime.Now);
        private readonly CreateTodoCommand _Valid = new CreateTodoCommand("Lição", "Joao", DateTime.Now);
        private TodoHandler _handler = new TodoHandler(new FakeTodoRepository());
        public CreateTodoHandlerTests() { }

        [TestMethod]
        public void Dado_Um_Comando_Invalido_Deve_Interromper_A_Execucao()
        {
            var result = (GenericCommandResult)_handler.Handle(_Invalid);
            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        public void Dado_Um_Comando_Valido_deve_Criar_A_Tarefa()
        {
            var result = (GenericCommandResult)_handler.Handle(_Valid);
            Assert.AreEqual(result.Success, true);
        }
    }
}