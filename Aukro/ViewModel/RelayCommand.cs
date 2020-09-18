using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Aukro.ViewModel
{
    class RelayCommand : ICommand
    {
        Action<object> executeMethod;
        Func<object, bool> canexecuteMethod;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> executeMethod, Func<object, bool> canexecuteMethod)
        {
            this.executeMethod = executeMethod;
            this.canexecuteMethod = canexecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            executeMethod(parameter);
        }

    }
}
