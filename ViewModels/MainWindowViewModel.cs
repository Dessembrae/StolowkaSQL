using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows.Input;
using StolowkaSQL.Models;
using StolowkaSQL.Commands;
using StolowkaSQL.Views;
using System.Windows;

namespace StolowkaSQL.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region ICommands
        public ICommand PreviousCommand { get; private set; }
        public ICommand NextCommand { get; private set; }
        public ICommand FirstCommand { get; private set; }
        public ICommand LastCommand { get; private set; }
        public ICommand ResetCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand AddWindowCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }
        #endregion
        #region Fields and Properties
        AddWindowViewModel addWindowViewModel;

        static string connstring = "datasource = datasource;port=port;username=username;password=password";
        public List<GrupyStructure> grupyList { get; set; }
        public CollectionViewSource viewList { get; set; }
        public ObservableCollection<Food> foodList { get; set; }
        public ObservableCollection<Food> foodComparerList { get; set; }
        MySqlConnection conDataBase = new MySqlConnection(connstring);
        DataTable dbataset;
        int itemPerPage = 15;
        int itemcount;

        private int _currentPageIndex;
        public int CurrentPageIndex
        {
            get { return _currentPageIndex; }
            set { _currentPageIndex = value; OnPropertyChanged("CurrentPage"); }
        }
        public int CurrentPage
        {
            get { return _currentPageIndex + 1; }
        }
        private int _totalPage;
        public int TotalPage
        {
            get { return _totalPage; }
            set { _totalPage = value; OnPropertyChanged("TotalPage"); }
        }
        #endregion

        public MainWindowViewModel()
        {
            
            foodList = new ObservableCollection<Food>();
            foodComparerList = new ObservableCollection<Food>();
            viewList = new CollectionViewSource();

            WorkWithDatabase();

            PopulateComboBox();

            CurrentPageIndex = 0;
            CalculateTotalPages();

            viewList.Source = foodList;
            viewList.Filter += new FilterEventHandler(view_Filter);

            NextCommand = new NextPageCommand(this);
            PreviousCommand = new PreviousPageCommand(this);
            FirstCommand = new FirstPageCommand(this);
            LastCommand = new LastPageCommand(this);
            ResetCommand = new ResetRecordsCommand(this);
            UpdateCommand = new UpdateRecordsCommand(this);
            AddWindowCommand = new AddNewWindowCommand(this);
            CloseCommand = new CloseWindowCommand(this);

            addWindowViewModel = new AddWindowViewModel(this);
        }

        #region Pagination Methods
        public void ShowNextPage()
        {
            CurrentPageIndex++;
            viewList.View.Refresh();
        }

        public void ShowPreviousPage()
        {
            CurrentPageIndex--;
            viewList.View.Refresh();
        }

        public void ShowFirstPage()
        {
            CurrentPageIndex = 0;
            viewList.View.Refresh();
        }

        public void ShowLastPage()
        {
            CurrentPageIndex = TotalPage - 1;
            viewList.View.Refresh();
        }

        void view_Filter(object sender, FilterEventArgs e)
        {
            //int index = foodList.IndexOf((Food)e.Item);
            int index = Int32.Parse(((Food)e.Item).id) - 1;
            if (index >= itemPerPage * CurrentPageIndex && index < itemPerPage * (CurrentPageIndex + 1))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }

        private void CalculateTotalPages()
        {
            TotalPage = (itemcount / itemPerPage);
            if (itemcount % itemPerPage != 0)
            {
                TotalPage += 1;
            }
        }
        #endregion   


        public void PopulateComboBox()
        {
            //grupyList
            grupyList = new List<GrupyStructure>();
            MySqlCommand cmdDataBase = new MySqlCommand("SELECT * from baza.danych", conDataBase);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                dbataset = new DataTable();
                sda.Fill(dbataset);

                foreach (DataRow row in dbataset.Rows)
                {
                    grupyList.Add(new GrupyStructure(row["klucz"].ToString(), row["opis"].ToString()));
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Błąd - PopulateComboBox");
            }
        }

        private void WorkWithDatabase()
        {
            foodList.Clear();
            foodComparerList.Clear();
            MySqlCommand cmdDataBase = new MySqlCommand("select * from baza.danych", conDataBase);

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                dbataset = new DataTable();
                sda.Fill(dbataset);

                foreach (DataRow row in dbataset.Rows)
                {
                    Food jadlo = new Food(row["Id"].ToString(),
                                        row["nazwa"].ToString(),
                                        Convert.ToBoolean(row["activ"].ToString()),
                                        Convert.ToBoolean(row["daniednia"].ToString()));
                    foodList.Add(jadlo);
                    foodComparerList.Add(jadlo.DeepCopy());
                }
                itemcount = foodList.Count;
            }
            catch (Exception)
            {
                Console.WriteLine("Bład - WorkWithDatabase");
            }            
        }

        public void UpdateDatabase()
        {
            for(int i = 0; i < foodList.Count; i++)
            {
                if (!foodList.ElementAt(i).Equals(foodComparerList.ElementAt(i)))
                {
                    Food recordToUpdate = foodList.ElementAt(i);

                    string query = String.Format("UPDATE baza.danych SET activ={0}, daniednia={1}, nazwa='{2}' WHERE Id='{3}'",
                        recordToUpdate.active.ToString(), recordToUpdate.danieDnia, recordToUpdate.nazwa, recordToUpdate.id);
                    MySqlDataAdapter dAdap = new MySqlDataAdapter();
                    dAdap.UpdateCommand = new MySqlCommand(query, conDataBase);
                    conDataBase.Open();
                    dAdap.UpdateCommand.ExecuteNonQuery();
                    conDataBase.Close();
                }
            }
        }

        public void ResetAllRecords()
        {
            foreach (Food danie in foodList)
            {
                if (danie.active == true || danie.danieDnia == true)
                {
                    danie.active = false;
                    danie.danieDnia = false;
                    string query = String.Format("UPDATE baza.danych SET activ={0}, daniednia={1}, nazwa='{2}' WHERE Id='{3}'",
                        danie.active.ToString(), danie.danieDnia, danie.nazwa, danie.id);
                    MySqlDataAdapter dAdap = new MySqlDataAdapter();
                    dAdap.UpdateCommand = new MySqlCommand(query, conDataBase);
                    conDataBase.Open();
                    dAdap.UpdateCommand.ExecuteNonQuery();
                    conDataBase.Close();
                    viewList.View.Refresh();
                }

            }
        }

        public void AddRecordToDatabase(string id, string grupa, string pozycja, string nazwa)
        {
            try
            {
                string query = String.Format("INSERT INTO baza.danych(Id, grupa, nazwa, pozycja) VALUES({0}, {1}, '{2}', {3})", id, grupa, nazwa, pozycja);
                MySqlDataAdapter dAdap = new MySqlDataAdapter();
                dAdap.InsertCommand = new MySqlCommand(query, conDataBase);
                conDataBase.Open();
                dAdap.InsertCommand.ExecuteNonQuery();
                conDataBase.Close();
                WorkWithDatabase();
            }
            catch (Exception)
            {
                MessageBox.Show("Bląd - niepoprawne dane - AddRecordToDatabase");
            }
        }

        public void ShowAddWindow()
        {
            AddNewRecordWindow window = new AddNewRecordWindow();
            window.DataContext = addWindowViewModel;
            window.ShowDialog();
        }
    }
}
