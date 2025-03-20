using Dobrin_Serov_Hotel.AppData;
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
using System.Windows.Shapes;

namespace Dobrin_Serov_Hotel.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public ChangePasswordWindow()
        {
            InitializeComponent();
        }

        private void ChangePasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword();
        }
        public void ChangePassword()
        {
            if (OldPasswordPb.Password != App.currentUser.Password)
            {
                FeedBack.Error("Неверно введён текущий пароль! Попробуйте снова.");
            }
            else if (OldPasswordPb.Password == NewPasswordPb.Password)
            {
                FeedBack.Error("Старый и новые пароли совпадают! Придумайте новый пароль.");
            }
            else if (NewPasswordPb.Password != AcceptNewPasswordPb.Password)
            {
                FeedBack.Error("Новые пароли не совпадают! Попробуйте снова.");
            }
            else
            {
                App.currentUser.Password = NewPasswordPb.Password;
                App.currentUser.IsActivated = true;

                App.context.SaveChanges();

                FeedBack.Information("Пароль успешно изменён!");
            }
        }
    }
}
