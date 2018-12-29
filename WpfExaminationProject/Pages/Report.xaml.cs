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
    /// Логика взаимодействия для Report.xaml
    /// </summary>
    public partial class Report : Page
    {
        ModelEntity db = new ModelEntity();

        public Report(newEquipment g)
        {
            InitializeComponent();
            ReportBind.DataContext = g;

            if (g.bitActive)
            { 
                bitActive.Foreground = new SolidColorBrush(Colors.Green);
                bitActive.Content = "Активная;";
            }
            else
            {
                bitActive.Foreground = new SolidColorBrush(Colors.Red);
                bitActive.Content = "Не активная;";
            }

            if (g.bitKTG)
            {
                bitKTG.Foreground = new SolidColorBrush(Colors.Green);
                bitKTG.Content = "Участвует при расчете КТГ;";
            }
            else
            {
                bitKTG.Foreground = new SolidColorBrush(Colors.Red);
                bitKTG.Content = "Не участвует при расчете КТГ;";
            }
            if (g.bitMeter)
            {
                bitMeter.Foreground = new SolidColorBrush(Colors.Green);
                bitMeter.Content = "Участвует в расчете мото-часов;";
            }
            else
            {
                bitMeter.Foreground = new SolidColorBrush(Colors.Red);
                bitMeter.Content = "Не участвует в расчете мото-часов;";
            }

            List<TableSelect> tableSelect = new List<TableSelect>();
          
                var joinTabs = (from ne in db.newEquipment
                            join tm in db.TrackMeter on ne.intEquipmentID equals tm.intEquipmentID
                            where ne.intGarageRoom == g.intGarageRoom
                            select new { intGarageRoom = ne.intGarageRoom, dMeterDate = tm.dMeterDate, intMeterReading = tm.intMeterReading, intTotalMeter = tm.intTotalMeter })
                            .ToList();
            foreach (var jt in joinTabs)
            { 
                TableSelect tableSelects = new TableSelect();
                tableSelects.intGarageRoom = jt.intGarageRoom;
                tableSelects.dMeterDate = jt.dMeterDate;
                tableSelects.intMeterReading = jt.intMeterReading;
                tableSelects.intTotalMeter = Convert.ToDouble(jt.intTotalMeter);
                tableSelect.Add(tableSelects);
            }
            TableMeters.ItemsSource = tableSelect;


        }
    }
}
