using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using TabStudents.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace TabStudents.ViewModels
{
   
    public partial class StudentsDetailViewModel : ObservableObject
    {

        [ObservableProperty]
        private string _title = string.Empty;

       
        [ObservableProperty]
        private StudentsModel _student;
       

        [ObservableProperty]
        private string _idd;
        [ObservableProperty]
        private string _firstNamee;
        [ObservableProperty]
        private string _lastNamee;
        
        public StudentsDetailViewModel(StudentsModel tabs)
        {
            if (tabs == null)
                throw new ArgumentNullException("student");

            _student = tabs;
            Idd = _student.Id.ToString();
            FirstNamee = _student.FirstName;
            LastNamee = _student.LastName;
           
        }
    }
}
