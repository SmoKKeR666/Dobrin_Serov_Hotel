using Dobrin_Serov_Hotel.AppData;
using Dobrin_Serov_Hotel.Model;
using Dobrin_Serov_Hotel.View.Windows;
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
    /// Логика взаимодействия для UserListPage.xaml
    /// </summary>
    public partial class UserListPage : Page
    {
        public UserListPage()
        {
            InitializeComponent();

            UsersLv.ItemsSource = App.context.User.ToList();
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            AddNewUserWindow addNewUserWindow = new AddNewUserWindow();
            if (addNewUserWindow.ShowDialog() == true)
            {
                UsersLv.ItemsSource = App.context.User.ToList();
            }
        }

        private void UsersLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserDetailsGrid.DataContext = UsersLv.SelectedItem as User;
        }

        private void SaveChangesBtn_Click(object sender, RoutedEventArgs e)
        {
            App.context.SaveChanges();

            FeedBack.Information("Информация успешно изменена");
        }
    }
}
