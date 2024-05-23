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

        /// <summary>
        /// Метод инициализирует элементы управления и связывает данные с текущим объектом термина.
        /// </summary>
        public AddTerm()
        {
            InitializeComponent();
            DataContext = _currentTerm;

        }

        /// <summary>
        /// Этот метод вызывается при нажатии кнопки Сохранить.
        /// Проверяет на заполненность все поля, если какое-то не заполнено, 
        /// показывает соответствующее сообщение.
        /// Если все поля заполнены и запись новая, добавляет ее в базу данных.
        /// В случае успешного сохранения возвращает на предыдущую страницу,
        /// в случае ошибки отображает соответствующее сообщение.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Этот метод вызывается при нажатии кнопки Отмена
        /// Возвращает на прошлую страницу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
