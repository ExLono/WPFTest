using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Test2.Command
{
    public sealed class RelayCommand : ICommand
    
    {
    
        private readonly Action<object> _action;        
        private readonly Func<object, bool> _func;        
        public RelayCommand(Action<object> action, Func<object, bool> func = null)        
        {        
            _action = action;            
            _func = func;            
        }

        #region Implementation of ICommand
        public bool CanExecute(object parameter)
        {
            if (_func is null) return true;
            return _func.Invoke(parameter);
        }

        /// <inheritdoc />
        public void Execute(object parameter) => _action.Invoke(parameter);
        /// <inheritdoc />
        public event EventHandler CanExecuteChanged;

        #endregion
    }
}

