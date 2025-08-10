using Control_Inventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Control_Inventario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroProductoPage : ContentPage
    {
        private readonly System.Collections.ObjectModel.ObservableCollection<Producto> _productos;

        public RegistroProductoPage(System.Collections.ObjectModel.ObservableCollection<Producto> productos)
        {
            InitializeComponent();
            _productos = productos;
        }

        private async void OnGuardarClicked(object sender, EventArgs e)
        {
            // Validacion de campos
            if (string.IsNullOrWhiteSpace(entryId.Text) ||
                string.IsNullOrWhiteSpace(entryNombre.Text) ||
                string.IsNullOrWhiteSpace(entryCantidad.Text) ||
                string.IsNullOrWhiteSpace(entryProveedor.Text))
            {
                await DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
                return;
            }

            // Crear nuevo producto
            var nuevoProducto = new Producto
            {
                Id = int.Parse(entryId.Text),
                Nombre = entryNombre.Text,
                Cantidad = int.Parse(entryCantidad.Text),
                Proveedor = entryProveedor.Text
            };

            _productos.Add(nuevoProducto);

            await DisplayAlert("Éxito", "Producto agregado correctamente", "OK");
            await Navigation.PopAsync(); // Volver a la página anterior
        }
    }
}