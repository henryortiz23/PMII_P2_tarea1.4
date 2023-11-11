using SQLite;

namespace Ejercicio_1._4.Models
{
    public class Imagenes
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public byte[] imagen { get; set; }

        [MaxLength(50)]
        public string descripcion { get; set; }
    }
}