using System;
using Xamarin.Forms;
using Control_Inventario.Models;

namespace Control_Inventario
{
    public partial class RegistroProductoPage : ContentPage
    {
        private Producto productoExistente;

        public RegistroProductoPage(Producto producto = null)
        {
            InitializeComponent();

            productoExistente = producto;

            if (productoExistente != null)
            {
                NombreEntry.Text = productoExistente.Nombre;
                CantidadEntry.Text = productoExistente.Cantidad.ToString();
                ProveedorEntry.Text = productoExistente.Proveedor;
                DescripcionEntry.Text = productoExistente.Descripcion;
                PrecioEntry.Text = productoExistente.PrecioUnitario.ToString();
                CategoriaEntry.Text = productoExistente.Categoria;
                FechaIngresoPicker.Date = productoExistente.FechaIngreso == default ? DateTime.Now : productoExistente.FechaIngreso;
                UbicacionEntry.Text = productoExistente.Ubicacion;
                StockMinimoEntry.Text = productoExistente.StockMinimo.ToString();
            }
            else
            {
                FechaIngresoPicker.Date = DateTime.Now;
            }
        }

        private async void OnGuardarProducto(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NombreEntry.Text))
            {
                await DisplayAlert("Error", "El nombre es obligatorio.", "OK");
                return;
            }

            if (!int.TryParse(CantidadEntry.Text, out int cantidad))
            {
                await DisplayAlert("Error", "Cantidad inválida.", "OK");
                return;
            }

            if (!double.TryParse(PrecioEntry.Text, out double precio))
            {
                precio = 0;
            }

            if (!int.TryParse(StockMinimoEntry.Text, out int stockMin))
            {
                stockMin = 0;
            }

            if (productoExistente == null)
            {
                var nuevo = new Producto
                {
                    Nombre = NombreEntry.Text.Trim(),
                    Cantidad = cantidad,
                    Proveedor = ProveedorEntry.Text?.Trim(),
                    Descripcion = DescripcionEntry.Text?.Trim(),
                    PrecioUnitario = precio,
                    Categoria = CategoriaEntry.Text?.Trim(),
                    FechaIngreso = FechaIngresoPicker.Date,
                    Ubicacion = UbicacionEntry.Text?.Trim(),
                    StockMinimo = stockMin
                };

                try
                {
                    if (App.Database != null)
                    {
                        await App.Database.SaveProductoAsync(nuevo);
                    }
                }
                catch
                {
                    // Esto es para que no se bloquee la app por errores de BD
                }

                if (!Inventario.Productos.Contains(nuevo))
                    Inventario.Productos.Add(nuevo);
            }
            else
            {
                productoExistente.Nombre = NombreEntry.Text.Trim();
                productoExistente.Cantidad = cantidad;
                productoExistente.Proveedor = ProveedorEntry.Text?.Trim();
                productoExistente.Descripcion = DescripcionEntry.Text?.Trim();
                productoExistente.PrecioUnitario = precio;
                productoExistente.Categoria = CategoriaEntry.Text?.Trim();
                productoExistente.FechaIngreso = FechaIngresoPicker.Date;
                productoExistente.Ubicacion = UbicacionEntry.Text?.Trim();
                productoExistente.StockMinimo = stockMin;

                try
                {
                    if (App.Database != null)
                    {
                        await App.Database.SaveProductoAsync(productoExistente);
                    }
                }
                catch
                {
                    // Esto es para que no se bloquee la app por errores de BD
                }

                var idx = Inventario.Productos.IndexOf(productoExistente);
                if (idx >= 0)
                {
                    Inventario.Productos[idx] = productoExistente;
                }
            }

            await Navigation.PopAsync();
        }
    }
}
