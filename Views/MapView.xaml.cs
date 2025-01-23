using System.Windows;
using System.Windows.Forms.Integration;
using System.Windows.Forms.Integration;

namespace FuelStationWPF.Views
{
    public partial class MapView : Window
    {
        public MapView()
        {
            InitializeComponent();
            Loaded += (s, e) => WebBrowserControl.Navigate("https://www.bing.com/maps");
        }
    }
}