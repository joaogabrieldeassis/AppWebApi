namespace Todo.Domain.Commands.Contracts
{
    public interface ICommand
    {
        void Validate();
    }
}