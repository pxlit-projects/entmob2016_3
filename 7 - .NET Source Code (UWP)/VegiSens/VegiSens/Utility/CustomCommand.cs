using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VegiSens.Utility
{
    public class CustomCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        //Properties
        private Action _action;
        private Predicate<object> canExecute;

        //Constructor
        public CustomCommand(Action action, Predicate<object> canExecute)
        {
            this._action = action;
            this.canExecute = canExecute;
        }

        //Can the action be excecuted?
        public bool CanExecute(object parameter)
        {
            bool b = canExecute == null ? true : canExecute(parameter);
            return b;
        }

        //Execute the action
        public void Execute(object parameter)
        {
            this._action();
        }
    }
}
