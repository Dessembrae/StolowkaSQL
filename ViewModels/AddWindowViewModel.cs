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
        public MainWindowViewModel mainWindowViewModel { get; set; }
        public ICommand AddCommand { get; private set; }
        public List<GrupyStructure> grupyList { get; set; }
        private GrupyStructure _selectedGroup;
        public GrupyStructure SelectedGroup
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
        private string _grupa;
        public string Grupa 
        {
            get { return _grupa; }
            set { _grupa = value; OnPropertyChanged("Grupa"); } 
        }
        private string _pozycja;
        public string Pozycja 
        {
            get { return _pozycja; }
            set { _pozycja = value; OnPropertyChanged("Pozycja"); } 
        }
        private string _nazwa;
        public string Nazwa 
        {
            get { return _nazwa; }
            set { _nazwa = value; OnPropertyChanged("Nazwa"); } 
        }

        public AddWindowViewModel(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
            grupyList = mainWindowViewModel.grupyList;
            SelectedGroup = grupyList.ElementAt(0);
            AddCommand = new AddDataCommand(this);
        }


        public void AddToDatabase()
        {
            Console.WriteLine(SelectedGroup.Opis);
            mainWindowViewModel.AddRecordToDatabase(Id, SelectedGroup.Klucz, Pozycja, Nazwa);
        }
        
    }
}
