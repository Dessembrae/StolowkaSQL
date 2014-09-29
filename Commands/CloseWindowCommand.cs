using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using StolowkaSQL.ViewModels;
using System.Windows;

namespace StolowkaSQL.Commands
{
    class CloseWindowCommand : ICommand
    {
        MainWindowViewModel mainWindowViewModel;

        public CloseWindowCommand(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            Console.WriteLine("zamykanie programu....");
            Window window = parameter as Window;
            window.Close();
        }
    }
}
