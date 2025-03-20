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

namespace Dobrin_Serov_Hotel.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для RoomsListPage.xaml
    /// </summary>
    public partial class RoomsListPage : Page
    {
        public RoomsListPage()
        {
            InitializeComponent();

            RoomsLb.ItemsSource = App.context.Room.ToList();
        }

        private void FilterByCategoryCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
