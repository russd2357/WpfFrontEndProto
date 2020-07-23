using System.Windows.Input;
using System.Threading.Tasks;

namespace WpfFrontEndProto
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();
        bool CanExecute();
    }
}
