using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TabStudents.Models;
using TabStudents.ViewModels;
using TabStudents.Repository;

namespace TabStudents.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public IEnumerable<StudentsModel> Peoples => _studentsRepository.Peoples;

        public ObservableCollection<StudentsDetailViewModel> Tabs { get; } = new();

        private ObservableCollection<StudentsDetailViewModel> _items = new ObservableCollection<StudentsDetailViewModel>();

        private StudentsRepository _studentsRepository;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RemoveCommand))]
        private StudentsModel _selectedStudent;

        [ObservableProperty]
        private string _idd;
        [ObservableProperty]
        private string _firstNamee;
        [ObservableProperty]
        private string _lastNamee;

        public MainViewModel(StudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository ??
                                  throw new ArgumentNullException("studentsRepository");
           
        }
       
        //private bool HasSelectedCustomer() => SelectedCustomer != null;
        private bool _hasSelectedStudent;
        public bool HasSelectedStudent
        {
            get 
            {
                if (SelectedStudent != null)
                {
                    FirstNamee = SelectedStudent.FirstName;
                    LastNamee = SelectedStudent.LastName;

                    

                    StudentsDetailViewModel newTab;
                    newTab = new StudentsDetailViewModel(SelectedStudent)
                    {
                        Title = $"{FirstNamee + " " + LastNamee}"
                    };
                    Tabs.Add(newTab);
                   

                    this.CurrentPage = newTab;
                }
                return _hasSelectedStudent;
            }
            
        }
        private StudentsDetailViewModel _currentPage;


        public StudentsDetailViewModel CurrentPage
        {

            get { return _currentPage; }
            set
            {
                _currentPage = value;

                if (!_items.Contains(value))
                {
                    _items.Add(value);
                }

                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        [RelayCommand]
        private void CloseTab(StudentsDetailViewModel obj)
        {
            Tabs.Remove(obj);

        }

        [RelayCommand]
        private void Add()
        {
            var studentsModel = new StudentsModel();
            _studentsRepository.Add(studentsModel);
            SelectedStudent = studentsModel;
            OnPropertyChanged("StudentsModel");
        }



        [RelayCommand(CanExecute = "HasSelectedStudent")]
        private void Remove()
        {
            if (SelectedStudent != null)
            {
                _studentsRepository.Remove(SelectedStudent);
                SelectedStudent = null;
                OnPropertyChanged("StudentsModel");
            }
        }

        [RelayCommand]
        private void Save()
        {
           // _customerRepository.Commit();
        }

        [RelayCommand]
        private void Search(string textToSearch)
        {
            var coll = CollectionViewSource.GetDefaultView(Peoples);
            if (!string.IsNullOrWhiteSpace(textToSearch))
                coll.Filter = c => ((StudentsModel)c).LastName.ToLower().Contains(textToSearch.ToLower());
            else
                coll.Filter = null;
        }                
        
    }
}