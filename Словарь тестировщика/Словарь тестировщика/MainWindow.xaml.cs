using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для MainWindow.xaml 
    public partial class MainWindow : Window
    {
        protected override void OnClosing(CancelEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти из приложения?", "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            frame.Navigate(new Terms()); // открытие страницы

        }

    }
}

