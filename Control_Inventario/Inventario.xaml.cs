using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Control_Inventario.Models;

namespace Control_Inventario
{
    public partial class Inventario : ContentPage
    {
        public static ObservableCollection<Producto> Productos { get; set; }

        public Inventario()
        {
            InitializeComponent();

            // Si usas SQLite en App.Database, cargamos en OnAppearing.
            // Si no, inicializamos con algunos ejemplos.
            if (Productos == null)
            {
                Productos = new ObservableCollection<Producto>
                {
                    new Producto
                    {
                        Id = 1,
                        Nombre = "Cementos",
                        Cantidad = 520,
                        Proveedor = "Quintinos",
                        PrecioUnitario = 10.5,
                        Categoria = "Construcción",
                        FechaIngreso = DateTime.Now.AddDays(-5),
                        Descripcion = "Cemento gris de alta resistencia",
                        Ubicacion = "Almacén A1",
                        StockMinimo = 50
                    }
                };
            }

            ProductosCollection.ItemsSource = Productos;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Si tienes App.Database configurado, cargamos desde SQLite aquí:
            try
            {
                if (App.Database != null)
                {
                    var list = await App.Database.GetProductosAsync();
                    Productos.Clear();
                    foreach (var p in list.OrderBy(p => p.Id))
                        Productos.Add(p);
                }
            }
            catch
            {
                // Si algo falla, dejamos la lista en memoria (no queremos que la app se cierre)
            }
        }

        private async void OnProductoSelected(object sender, SelectionChangedEventArgs e)
        {
            var seleccionado = e.CurrentSelection.FirstOrDefault() as Producto;
            if (seleccionado != null)
            {
                await Navigation.PushAsync(new DetalleProductoPage(seleccionado));
                ((CollectionView)sender).SelectedItem = null;
            }
        }

        private async void OnAgregarProducto(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroProductoPage());
        }

        private async void OnEditarProducto(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var producto = btn?.BindingContext as Producto;
            if (producto != null)
            {
                await Navigation.PushAsync(new RegistroProductoPage(producto));
            }
        }

        private async void OnEliminarProducto(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var producto = btn?.BindingContext as Producto;
            if (producto == null) return;

            bool ok = await DisplayAlert("Eliminar", $"¿Eliminar {producto.Nombre}?", "Sí", "No");
            if (!ok) return;

            try
            {
                if (App.Database != null && producto.Id != 0)
                    await App.Database.DeleteProductoAsync(producto);
            }
            catch {}

            if (Productos.Contains(producto))
                Productos.Remove(producto);
        }
    }
}
