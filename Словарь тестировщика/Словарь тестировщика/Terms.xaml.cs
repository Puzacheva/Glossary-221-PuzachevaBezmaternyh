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
    /// Логика взаимодействия для Terms.xaml
    
    public partial class Terms : Page
    {
        public Terms()
        {
            InitializeComponent();
            DataGridTerm.ItemsSource = Entities.GetContext().Термины.ToList();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("AddTerm.xaml", UriKind.Relative));
        }

        //Обновление таблицы с данными о пользователях при каждой перезагрузке страницы
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DataGridTerm.ItemsSource = Entities.GetContext().Термины.ToList();
            }
        }

    }
}
