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
using RygOgRejs.Entities;
using System.Text.RegularExpressions;
using RygOgRejs.DataAccess;

namespace RygOgRejs.Gui
{
    /// <summary>
    /// Interaction logic for AddJourney.xaml
    /// </summary>
    public partial class AddJourney : UserControl
    {
        /// <summary>
        /// Gets the recently created journey
        /// </summary>
        public static Journey Journey { get; private set; }

        public AddJourney()
        {
            InitializeComponent();
        }

        private void CreateJourneyButton(object sender, RoutedEventArgs e)
        {
            if(CanCreate())
            {
                JourneyRepository repository = new JourneyRepository();
                Journey = new Journey(Journey.GetDestinationFromText(destinationDropdown.Text), departureDate.SelectedDate.Value, firstClassCheckbox.IsChecked.Value, int.Parse(adultsTextbox.Text), int.Parse(childrenTextbox.Text), double.Parse(luggageTextbox.Text));
                repository.Save(Journey);
                MessageBox.Show("Rejse tilføjet");
            }
        }

        private bool CanCreate()
        {
            if(departureDate.SelectedDate == null)
            {
                return false;
            }

            if(!Regex.IsMatch(adultsTextbox.Text, @"^[0-9]+$") || adultsTextbox.Text == string.Empty)
            {
                return false;
            }

            if(!Regex.IsMatch(childrenTextbox.Text, @"^[0-9]+$") || childrenTextbox.Text == string.Empty)
            {
                return false;
            }

            if(!Regex.IsMatch(luggageTextbox.Text, @"^[0-9.]+$") || luggageTextbox.Text == string.Empty)
            {
                return false;
            }

            if(!Regex.IsMatch(fornavnTextbox.Text, @"^[ a-zA-Z.]+$") || fornavnTextbox.Text == string.Empty)
            {
                return false;
            }

            if(!Regex.IsMatch(efternavnTextbox.Text, @"^[ a-zA-Z.]+$") || efternavnTextbox.Text == string.Empty)
            {
                return false;
            }

            if(!Regex.IsMatch(emailTextbox.Text, @"^[a-zA-Z.]+$") || emailTextbox.Text == string.Empty)
            {
                return false;
            }

            if(!Regex.IsMatch(telefonTextbox.Text, @"^[0-9]+$") || telefonTextbox.Text == string.Empty)
            {
                return false;
            }

            return true;
        }

        private void LuggageTextbox_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdateVisualPrice();
        }

        private void UpdateVisualPrice()
        {
            int adults = 0;
            int children = 0;
            double extraLuggage = 0;

            if(!int.TryParse(adultsTextbox.Text, out adults) || !int.TryParse(childrenTextbox.Text, out children) || !double.TryParse(luggageTextbox.Text, out extraLuggage))
            {
                return;
            }

            if(extraLuggage > 25)
            {
                extraLuggage -= 25;
            }
            else
            {
                extraLuggage = 0;
            }

            PriceDetails priceDetails = new PriceDetails(Journey.GetDestinationFromText(destinationDropdown.Text), adults, children, firstClassCheckbox.IsChecked.Value, extraLuggage);
            totalPrisMomsLbl.Content = $"Total pris med moms: {priceDetails.GetTotalWithTax():N2}kr";
            totalPrisUdenMomsLbl.Content = $"Total pris uden moms: {priceDetails.GetTotalWithoutTax():N2}kr";
        }

        private void AdultsTextbox_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdateVisualPrice();
        }

        private void ChildrenTextbox_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdateVisualPrice();
        }

        private void FirstClassCheckbox_Click(object sender, RoutedEventArgs e)
        {
            UpdateVisualPrice();
        }
    }
}
