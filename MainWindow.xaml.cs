using System.Windows;
using System.Windows.Data;
using TabStudents.ViewModels;

namespace TabStudents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = App.Current.MainVM;
        }

    }
}
