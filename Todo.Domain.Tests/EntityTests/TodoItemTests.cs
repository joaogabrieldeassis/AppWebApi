using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class TodoItemTests
    {
        private readonly TodoItem _todo = new TodoItem("Tarefa", "joao", DateTime.Now);

        [TestMethod]
        public void Dado_Um_Novo_Todo_O_Mesmo_Nao_Pode_Ser_Concluido()
        {
            Assert.AreEqual(_todo.Done, false);
        }


    }
}