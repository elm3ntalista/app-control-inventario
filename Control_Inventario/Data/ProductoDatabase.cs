using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Control_Inventario.Models;
using System;
using System.Text;

namespace Control_Inventario.Data
{
    public class ProductoDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ProductoDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Producto>().Wait();
        }

        public Task<List<Producto>> GetProductosAsync()
        {
            return _database.Table<Producto>().ToListAsync();
        }

        public Task<int> SaveProductoAsync(Producto producto)
        {
            if (producto.Id != 0)
            {
                return _database.UpdateAsync(producto);
            }
            else
            {
                return _database.InsertAsync(producto);
            }
        }

        public Task<int> DeleteProductoAsync(Producto producto)
        {
            return _database.DeleteAsync(producto);
        }
    }
}
