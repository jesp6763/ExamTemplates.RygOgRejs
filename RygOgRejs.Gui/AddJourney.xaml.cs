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

namespace RygOgRejs.Gui
{
    /// <summary>
    /// Interaction logic for AddJourney.xaml
    /// </summary>
    public partial class AddJourney : UserControl
    {
        public AddJourney()
        {
            InitializeComponent();
        }

        private void CreateJourneyButton(object sender, RoutedEventArgs e)
        {
            if(CanCreate())
            {
                Journey journey = new Journey(Journey.GetDestinationFromText(destinationDropdown.Text), departureDate.SelectedDate.Value, firstClassCheckbox.IsChecked.Value, adultsTextbox.Text, childrenTextbox.Text, luggageTextbox.Text);
            }
        }

        private bool CanCreate()
        {
            if(departureDate.SelectedDate == null)
            {
                return false;
            }

            if(!Regex.IsMatch(adultsTextbox.Text, @"^[0-9]$"))
            {
                return false;
            }

            if(!Regex.IsMatch(childrenTextbox.Text, @"^[0-9]$"))
            {
                return false;
            }

            if(!Regex.IsMatch(luggageTextbox.Text, @"^[0-9.]$"))
            {
                return false;
            }

            return true;
        }
    }
}
