using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using StolowkaSQL.ViewModels;

namespace StolowkaSQL.Commands
{
    class AddDataCommand : ICommand
    {
        private AddWindowViewModel viewModel;

        public AddDataCommand(AddWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            if (!String.IsNullOrEmpty(viewModel.Id) &&
                !String.IsNullOrEmpty(viewModel.Position) &&
                !String.IsNullOrEmpty(viewModel.Name))
                return true;
            else
                return false;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            viewModel.AddToDatabase();
        }
    }
}
