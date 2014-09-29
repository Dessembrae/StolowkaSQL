using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using StolowkaSQL.Commands;
using MySql.Data.MySqlClient;
using StolowkaSQL.Models;

namespace StolowkaSQL.ViewModels
{
    public class AddWindowViewModel : BaseViewModel
    {
        private MainWindowViewModel mainViewModel { get; set; }
        public ICommand AddCommand { get; private set; }
        public List<DishGroupStructure> GroupList { get; set; }

        private DishGroupStructure _selectedGroup;
        public DishGroupStructure SelectedGroup
        {
            get { return _selectedGroup; }
            set { _selectedGroup = value; OnPropertyChanged("SelectedGroup"); }
        }

        private string _id;
        public string Id 
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }

        private string _group;
        public string Group 
        {
            get { return _group; }
            set { _group = value; OnPropertyChanged("Group"); } 
        }

        private string _position;
        public string Position 
        {
            get { return _position; }
            set { _position = value; OnPropertyChanged("Position"); } 
        }

        private string _name;
        public string Name 
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); } 
        }

        public AddWindowViewModel(MainWindowViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            GroupList = mainViewModel.groupList;
            SelectedGroup = GroupList.ElementAt(0);

            AddCommand = new AddDataCommand(this);
        }

        public void AddToDatabase()
        {
            Console.WriteLine(SelectedGroup.Description);
            mainViewModel.AddRecordToDatabase(Id, SelectedGroup.Key, Position, Name);
        }
        
    }
}
