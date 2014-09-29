using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using StolowkaSQL.ViewModels;

namespace StolowkaSQL.Commands
{
    class PreviousPageCommand : ICommand
    {
        private MainWindowViewModel viewModel;

        public PreviousPageCommand(MainWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            if (viewModel.CurrentPageIndex == 0)
                return false;
            else
                return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            viewModel.ShowPreviousPage();
        }
    }
}
