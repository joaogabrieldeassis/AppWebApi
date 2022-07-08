using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Queries;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlersTests
{
    [TestClass]
    public class TodoQueriesTests
    {
        private List<TodoItem> _items;
        public TodoQueriesTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("1º do dia", "joao", DateTime.Now));
            _items.Add(new TodoItem("2º do dia", "Mariana", DateTime.Now));
            _items.Add(new TodoItem("3º do dia", "pai", DateTime.Now));
            _items.Add(new TodoItem("4º do dia", "joao", DateTime.Now));

        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_apenas_o_nome_do_joao()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("joao"));
            Assert.AreEqual(2, result);
        }


    }
}