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
using System.Diagnostics;

namespace Словарь_тестировщика
{
    /// Логика взаимодействия для Terms.xaml
    
    public partial class Terms : Page
    {
        /// <summary>
        /// Этот метод является конструктором класса Terms;
        /// Инициализирует компоненты пользовательского интерфейса и
        /// загружает данные из таблицы Термины в элемент управления DataGrid для отображения.
        /// </summary>
        public Terms()
        {
            InitializeComponent();
            DataGridTerm.ItemsSource = Entities.GetContext().Термины.ToList();
        }

        /// <summary>
        /// Метод вызывается при нажатии кнопки Добавить
        /// Открывает страницу добавления нового термина
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("AddTerm.xaml", UriKind.Relative));
        }

        /// <summary>
        /// Метод вызывается при нажатии кнопки Справочная_система
        /// Открывает приложение справочной системы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Справочная_система_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("\"C:\\Users\\79260\\OneDrive\\Рабочий стол\\ПиТ\\ПР12\\help.chm\"");
        }

        /// <summary>
        /// Метод обновляет таблицы с данными о пользователях при каждой перезагрузке страницы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
