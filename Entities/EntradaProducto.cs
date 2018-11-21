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
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public int ProductoId { get; set; }
        public virtual Producto Producto { get; set; }

        public EntradaProducto()
        {
            EntradaId = 0;
            Fecha = DateTime.Now;
            Cantidad = 0;
            ProductoId = 0;
        }

        public EntradaProducto(int entradaId, DateTime fecha, int cantidad, int productoId)
        {
            EntradaId = entradaId;
            Fecha = fecha;
            Cantidad = cantidad;
            ProductoId = productoId;
        }
    }
}
