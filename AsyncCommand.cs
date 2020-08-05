using System;
using System.Windows.Input;
using System.Threading.Tasks;


namespace WpfFrontEndProto
{

    // TODO - Create a generic version of this
    public class AsyncCommand<T> : IAsyncCommand<T>
    {
        public event EventHandler CanExecuteChanged;

        private bool _isExecuting;
        private readonly Func<T, Task> _execute;
        private readonly Func<bool> _canExecute;
        private readonly IErrorHandler _errorHandler;

		public AsyncCommand(
			Func<T, Task> execute,
			Func<bool> canExecute = null,
            IErrorHandler errorHandler = null)
        {

			_execute = execute;
            _canExecute = canExecute;
            _errorHandler = errorHandler;
        }

	    public bool CanExecute()
        {
            return !_isExecuting && (_canExecute?.Invoke() ?? true);
        }

        public async Task ExecuteAsync(T arg)
        {
            if (CanExecute())
            {
                try
                {
                    _isExecuting = true;
                    await _execute(arg);
                }
                finally
                {
                    _isExecuting = false;
                }
            }

            RaiseCanExecuteChanged();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #region Explicit implementations
        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        void ICommand.Execute(object parameter)
        {
            ExecuteAsync((T)parameter).FireAndForgetSafeAsync(_errorHandler);
        }
        #endregion
    }
}