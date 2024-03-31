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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Словарь_тестировщика
{
    /// Логика взаимодействия для AddTerm.xaml 

    public partial class AddTerm : Page
    {

        private Термины _currentTerm = new Термины();

        public AddTerm()
        {
            InitializeComponent();
            DataContext = _currentTerm;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentTerm.Понятие))
                errors.AppendLine("Укажите термин!");
            if (string.IsNullOrWhiteSpace(_currentTerm.Определение))
                errors.AppendLine("Укажите определение!");
            if (string.IsNullOrWhiteSpace(_currentTerm.Источник))
                errors.AppendLine("Укажите источник!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentTerm.Понятие == null & _currentTerm.Определение == null & _currentTerm.Источник == null)
                Entities.GetContext().Термины.Add(_currentTerm);

            try
            {
                Entities.GetContext().SaveChanges();
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
