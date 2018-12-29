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

using WpfExaminationProject.Pages;

namespace WpfExaminationProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame MF { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MF = MainFrame;//set;
            MainFrame.Source = new Uri("Pages/MainPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void ListBoxItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainPage mainPage = new MainPage();
            MF.NavigationService.Navigate(mainPage);
        }
    }
}
