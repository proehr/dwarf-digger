
namespace Common.Logic.CommandLogic
{
    public interface ICommand
    {
        void Execute();

        void Undo();
    }
}
