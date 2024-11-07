using DEMO.Windows;
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

namespace DEMO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Переменные для страниц, инициализируются сразу
        private readonly Page partnersCatalogPage = new partnersCatalog();
        private readonly Page partnerManagementPage = new partnerManagement();
        private readonly Page salesStatisticsPage = new salesStatistics(); 
        private readonly Page welcomePage = new welcome();
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = welcomePage;
        }

        private void partnersCatalog_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = partnersCatalogPage;
        }

        private void partnerManagement_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = partnerManagementPage;
        }

        private void salesStatistics_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = salesStatisticsPage;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = welcomePage;
        }
    }
}
