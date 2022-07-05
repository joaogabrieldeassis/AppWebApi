using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class CreateTodoComand : ICommand
    {
        public CreateTodoComand() { }
        public CreateTodoComand(string title, DateTime date, string user)
        {
            Title = title;
            Date = date;
            User = user;
        }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}