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
        AddWindowViewModel addWindowViewModel;

        public AddDataCommand(AddWindowViewModel addWindowViewModel)
        {
            this.addWindowViewModel = addWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            if (!String.IsNullOrEmpty(addWindowViewModel.Id) &&
                !String.IsNullOrEmpty(addWindowViewModel.Pozycja) &&
                !String.IsNullOrEmpty(addWindowViewModel.Nazwa))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            addWindowViewModel.AddToDatabase();
        }
    }
}
