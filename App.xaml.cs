using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace Delivery
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Проверка подключения к базе данных
            if (!CheckDatabaseConnection())
            {
                ShowDatabaseConnectionErrorDialog();
                Shutdown();
            }
            else
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
        }

        private bool CheckDatabaseConnection()
        {
            using (var dbContext = new AppDbContext())
            {
                try
                {
                    return dbContext.Database.CanConnect();
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        private void ShowDatabaseConnectionErrorDialog()
        {
            MessageBox.Show("Отсутствует связь с базой данных.", "Ошибка подключения", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
