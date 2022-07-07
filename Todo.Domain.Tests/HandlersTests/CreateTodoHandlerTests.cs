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
        private readonly CreateTodoCommand _comandINvalido = new CreateTodoCommand("Fazer sua lição", "Joao cabeção", DateTime.Now);
        private readonly TodoHandler _todoHandler = new TodoHandler(new FakeTodoRepository());
        public CreateTodoHandlerTests()
        {

        }

        [TestMethod]
        public void Dado_Um_Comando_Invalido_Deve_Interromper_A_Execucao()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Dado_Um_Comando_Valido_deve_Criar_A_Tarefa()
        {
            Assert.Fail();
        }
    }
}