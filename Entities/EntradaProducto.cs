using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class EntradaProducto
    {
        [Key]
        public int EntradaId { get; set; }
        public string Fecha { get; set; }
        public int Cantidad { get; set; }
        public int ProductoId { get; set; }

        public EntradaProducto()
        {
            EntradaId = 0;
            Fecha = string.Empty;
            Cantidad = 0;
            ProductoId = 0;
        }

        public EntradaProducto(int entradaId, string fecha, int cantidad, int productoId)
        {
            EntradaId = entradaId;
            Fecha = fecha;
            Cantidad = cantidad;
            ProductoId = productoId;
        }
    }
}
