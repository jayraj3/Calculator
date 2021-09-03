
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Calculator.Common.Commands
{
    class RelayCommand : ICommand
    {
        #region Data members and accessors

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute(parameter);
        }
        readonly Predicate<object> canExecute;

        public void Execute(object parameter)
        {
            execute(parameter);
        }
        readonly Action<object> execute;

        #endregion

        #region Constructors
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            this.execute = execute;
            this.canExecute = canExecute;
        }

        #endregion
    }
}
