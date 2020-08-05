using System.Windows.Input;
using System.Threading.Tasks;

namespace WpfFrontEndProto
{
    //TODO  Create a generic version of this
    public interface IAsyncCommand<T> : ICommand
    {
        Task ExecuteAsync(T arg);
        bool CanExecute();
    }
}
