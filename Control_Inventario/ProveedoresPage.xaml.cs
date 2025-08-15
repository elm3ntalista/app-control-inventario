using System.Linq;
using Xamarin.Forms;

namespace Control_Inventario
{
    public partial class ProveedoresPage : ContentPage
    {
        public ProveedoresPage()
        {
            InitializeComponent();
            CargarProveedores();
        }

        private void CargarProveedores()
        {
            var productos = Inventario.Productos;

            var proveedores = productos
                .Where(p => !string.IsNullOrWhiteSpace(p.Proveedor))
                .GroupBy(p => p.Proveedor)
                .Select(g => new
                {
                    NombreProveedor = g.Key,
                    TotalProductos = g.Count()
                })
                .ToList();

            ProveedoresCollection.ItemsSource = proveedores;
        }
    }
}
