using Dobrin_Serov_Hotel.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Dobrin_Serov_Hotel
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static HotelEntities context = new HotelEntities();

        public static User currentUser;
    }
}
