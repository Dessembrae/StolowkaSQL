using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using StolowkaSQL.ViewModels;

namespace StolowkaSQL.Commands
{
    class NextPageCommand : ICommand
    {
        private MainWindowViewModel viewModel;

        public NextPageCommand(MainWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            if (viewModel.TotalPage - 1 > viewModel.CurrentPageIndex)
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
            viewModel.ShowNextPage();
        }
    }
}
