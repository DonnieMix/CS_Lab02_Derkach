using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CS_Lab02_Derkach.ViewModels;

namespace CS_Lab02_Derkach.Views
{
    /// <summary>
    /// Interaction logic for CalendarView.xaml
    /// </summary>
    public partial class CalendarView : Window
    {
        private CalendarViewModel _viewModel;
        public CalendarView()
        {
            _viewModel = new CalendarViewModel(this);
            InitializeComponent();
        }
        
        private void BProceed_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.BProceed_Click(sender, e);
        }
    }
}
