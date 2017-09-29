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

namespace RygOgRejs.Gui
{
    /// <summary>
    /// Interaction logic for EditJourney.xaml
    /// </summary>
    public partial class EditJourney : UserControl
    {
        Journey journey;

        public EditJourney(Journey journey)
        {
            InitializeComponent();
            this.journey = journey;
        }

        public void Update(Journey newJourney)
        {
            journey = newJourney;
            // Update data

        }
    }
}
