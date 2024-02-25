using Lab1Prokopchuk.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Lab1Prokopchuk.Views
{
    /// <summary>
    /// Interaction logic for BirthdayWindow.xaml
    /// </summary>
    public partial class BirthdayView : UserControl
    {
        private readonly BirthdayViewModel _viewModel;
        public BirthdayView()
        {
            InitializeComponent();
            DataContext = _viewModel = new BirthdayViewModel();
            datePicker.SelectedDate = DateTime.Today;
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = datePicker.SelectedDate;
            if (selectedDate != null)
            {
                _viewModel.UpdateDate = selectedDate.Value;
            }
        }
        private void BCheckBday_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ChooseDate();
        }

    }
}
