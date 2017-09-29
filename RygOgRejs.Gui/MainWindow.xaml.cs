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
using RygOgRejs.Services;
using RygOgRejs.Entities;
using RygOgRejs.DataAccess;

namespace RygOgRejs.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window
    {
        private UserControl currentUserControlCentre, currentUserControlRight;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnMenuFilesClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Vil du afslutte Ryg & Rejs?", "Luk Ryg & Rejs", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if(result == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        private void ButtonJourneys_Click(object sender, RoutedEventArgs e)
        {

            JourneyRepository repository = new JourneyRepository();
            List<Journey> journeys = repository.GetAll();
            currentUserControlCentre = new DataViewJourneys(journeys);
            userControlCentre.Content = currentUserControlCentre;

            // Subscribe to selection changed event
            DataViewJourneys dataViewJourneys = userControlCentre.Content as DataViewJourneys;
            dataViewJourneys.dataGridJourneys.SelectionChanged += DataGridJourneys_SelectionChanged;

            // Instantiate AddJourney user control
            currentUserControlRight = new AddJourney();
            userControlRight = currentUserControlRight;
        }

        private void DataGridJourneys_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(currentUserControlRight == null)
            {
                //currentUserControlRight = new EditJourney(journey);
                userControlRight.Content = currentUserControlRight;
            }
            else
            {
                if(currentUserControlRight.GetType() == typeof(EditJourney))
                {
                    // Get reference to datagrid
                    DataGrid dataGrid = (currentUserControlCentre as DataViewJourneys).dataGridJourneys;

                    // Update data user control
                    EditJourney editJourney = currentUserControlRight as EditJourney;
                    editJourney.Update(dataGrid.SelectedItem as Journey);
                }
            }
        }

        private void MenuHelpAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dette er et eksempel på løsning af S2 eksamensopgaven Ryg & Rejs", "Om Ryg & Rejs", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
    }
}