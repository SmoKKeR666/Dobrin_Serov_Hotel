using Dobrin_Serov_Hotel.AppData;
using Dobrin_Serov_Hotel.Model;
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
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        int loginAttemptCount = 0;

        public AuthorizationWindow()
        {
            InitializeComponent();

            BlockingUserByDate();
        }

        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Validation() == true)
            {
                Authentication();
            }    
        }

        /// <summary>
        /// Метод валидации введённых данных.
        /// </summary>
        /// <returns></returns>
        public bool Validation()
        {
            if (LoginTb.Text == string.Empty && PasswordPb.Password == string.Empty)
            {
                FeedBack.Warning("Поля для ввода не должны быть пустыми. Введите логин и пароль!");
                return false;
            }
            else if (LoginTb.Text == string.Empty)
            {
                FeedBack.Warning("Поля для ввода не должны быть пустыми. Введите логин!");
                return false;
            }
            else if (PasswordPb.Password == string.Empty)
            {
                FeedBack.Warning("Поля для ввода не должны быть пустыми. Введите пароль!");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Метод для аутентификации пользователя.
        /// </summary>
        public void Authentication()
        {
            App.currentUser = App.context.User.FirstOrDefault(user => user.Login ==
                LoginTb.Text && user.Password == PasswordPb.Password);

            if (App.currentUser == null)
            {
                loginAttemptCount++;

                FeedBack.Error($"Вы ввели неверный логин или пароль. Пожалуйста проверьте ещё раз введённые данные. Осталось попыток: {loginAttemptCount} из 3");

                if (loginAttemptCount == 3)
                {
                    // App.currentUser.IsBlocked = true;
                    loginAttemptCount = 0;
                    FeedBack.Error($"Вы заблокированы! Обратитесь к администратору!");
                    Close();
                }
            }
            else if (App.currentUser.IsBlocked == true)
            {
                FeedBack.Error("Вы заблокированы. Обратитесь к администратору!");
            }
            else if (App.currentUser.IsActivated == false)
            {
                ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow();
                changePasswordWindow.Show();
                Hide();
            }
            else
            {
                FeedBack.Information("Вы успешно авторизовались");

                switch (App.currentUser.IdRole)
                {
                    case 1:
                        AdministratorWindow administratorWindow = new AdministratorWindow();
                        administratorWindow.Show();
                        break;
                    case 2:
                        UserWindow userWindow = new UserWindow();
                        userWindow.Show();
                        break;
                    case 3:
                        FeedBack.Error("Роль пользователя не найдена! Доступ запрещён.");
                        break;
                }
            }
        }

        /// <summary>
        /// Метод для блокировки  пользователя по дате.
        /// </summary>
        public void BlockingUserByDate()
        {
            foreach (var user in App.context.User)
            {
                if (user.RegistrationDate.AddMonths(1) <= DateTime.Now.Date && !user.IsActivated)
                {
                    user.IsBlocked = true;
                }
            }

            App.context.SaveChanges();
        }
    }
}
