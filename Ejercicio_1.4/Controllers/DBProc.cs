using Ejercicio_1._4.Models;
using SQLite;

namespace Ejercicio_1._4.Controllers
{
    public class DBProc : ContentPage
    {
        private readonly SQLiteAsyncConnection _connection;

        public DBProc()
        { }

        public DBProc(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            // todos objetos BD
            _connection.CreateTableAsync<Imagenes>().Wait();
        }

        /*  crud DBProc*/
        // create, read, update, delete

        public Task<int> AddImagen(Imagenes imagen)
        {
            if (imagen.id == 0)
            {
                return _connection.InsertAsync(imagen);
            }
            else
            {
                return _connection.UpdateAsync(imagen);
            }
        }

        public Task<List<Imagenes>> ListImagenes()
        {
            return _connection.Table<Imagenes>().ToListAsync();
        }

        public Task<Imagenes> GetImagenID(int id)
        {
            return _connection.Table<Imagenes>()
                .Where(p => p.id == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> DeleteImagen(Imagenes imagen)
        {
            return _connection.DeleteAsync(imagen);
        }
    }
}