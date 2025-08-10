using Control_Inventario.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Control_Inventario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inventario : ContentPage
    {
        public ObservableCollection<Producto> Productos { get; set; }
        
        public Inventario()
        {
            InitializeComponent();
            Productos = new ObservableCollection<Producto> 
            {
                new Producto { Id = 1, Nombre = "Laptop HP", Cantidad = 10, Proveedor = "TechWorld" },
                new Producto { Id = 2, Nombre = "Teclado Razer Mecánico", Cantidad = 25, Proveedor = "KeyMasters" },
                new Producto { Id = 3, Nombre = "Mouse logitech Inalámbrico", Cantidad = 40, Proveedor = "ClickPro" },
                new Producto { Id = 4, Nombre = "Monitor Dell 24''", Cantidad = 8, Proveedor = "VisionTech" }
            };

            listaProductos.ItemsSource = Productos;
        }

        private async void OnAgregarProductoClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RegistroProductoPage(Productos));
        }
    }
}