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
    /// Логика взаимодействия для InputDates.xaml
    /// </summary>
    public partial class InputDates : Page
    {
        ModelEntity db = new ModelEntity();

        public InputDates()
        {
            InitializeComponent();
            lbManufacturer.ItemsSource = db.TablesManufacturer.ToList();
            lbModel.ItemsSource = db.TablesModel.ToList();
            lbPrefix.ItemsSource = db.TablesSNPrefix.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MF.NavigationService.Navigate(new Uri("Pages/MainPage.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            newEquipment equipment = new newEquipment();
            equipment.intGarageRoom = lbintGarageRoom.Text;
            equipment.intManufacturerID = ((TablesManufacturer)lbManufacturer.SelectedItem).intManufacturerID;
            equipment.intModelID = ((TablesModel)lbModel.SelectedItem).intModelID;
            equipment.strManufYear = lbstrManufYear.Text;
            equipment.intSNPrefixID = ((TablesSNPrefix)lbPrefix.SelectedItem).intSNPrefixID;
            equipment.strSerialNo = lbstrSerialNo.Text;
            equipment.LastDate = Convert.ToDateTime(lbLastDate.SelectedDate);
            Double.TryParse(lbintLastMetered.Text, out double lm);
            equipment.intLastMetered = lm;
            Int32.TryParse(lbintTotalMetered.Text, out int tm);
            equipment.intTotalMetered = tm;
            equipment.bitActive = Convert.ToBoolean(chbbitActive.IsChecked);
            equipment.bitKTG = Convert.ToBoolean(chbbitKTG.IsChecked);
            equipment.bitPreservation = Convert.ToBoolean(chbbitPreservation.IsChecked);
            equipment.bitMeter = Convert.ToBoolean(chbbitMeter.IsChecked);
            equipment.bitMethodAmortization = Convert.ToBoolean(chbbitMethodAmortization.IsChecked);
            Double.TryParse(lbfloatFullPrice.Text, out double fp);
            equipment.floatFullPrice = fp;
            Int32.TryParse(lbintServiceLife.Text, out int sf);
            equipment.intServiceLife = sf;
            Int32.TryParse(lbintHoweverOddsAcceleration.Text, out int hoa);
            equipment.intHoweverOddsAcceleration = hoa;
            equipment.dateStartUpDate = Convert.ToDateTime(lbdateStartUpDate.SelectedDate);

            try
            {
                ModelEntity db = new ModelEntity();
                db.newEquipment.Add(equipment);
                db.SaveChanges();
                MessageBox.Show("Автомобиль добавлен успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Автомобиль не добавлен: " + ex.Message);
            }

        }
    }
}
