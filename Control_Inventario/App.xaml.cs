using Control_Inventario.Data;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Control_Inventario
{
    public partial class App : Application
    {
        static ProductoDatabase database;

        public static ProductoDatabase Database
        {
            get
            {
                if (database == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Productos.db3");
                    database = new ProductoDatabase(dbPath);
                }
                return database;
            }
        }

        public static IEnumerable<object> Productos { get; internal set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }
    }
}
