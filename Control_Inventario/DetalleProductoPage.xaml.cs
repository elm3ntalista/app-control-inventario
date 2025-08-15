using Xamarin.Forms;
using Control_Inventario.Models;
using System;

namespace Control_Inventario
{
    public partial class DetalleProductoPage : ContentPage
    {
        public DetalleProductoPage(Producto producto)
        {
            InitializeComponent();
            BindingContext = producto ?? new Producto { Nombre = "Sin datos", FechaIngreso = DateTime.Now };
        }

        private async void OnCerrar(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
