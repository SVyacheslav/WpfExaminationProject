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
using WpfExaminationProject.Model;


namespace WpfExaminationProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        ModelEntity db = new ModelEntity();

        public MainPage()
        {
            InitializeComponent();
            MainTable.ItemsSource = db.newEquipment.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MF.NavigationService.Navigate(new Uri("Pages/InputDates.xaml", UriKind.Relative));
        }

        private void MainTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            newEquipment g = MainTable.SelectedItem as newEquipment;

            Report report = new Report(g);
            MainWindow.MF.NavigationService.Navigate(report);
        }
    }
}
