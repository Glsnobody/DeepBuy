using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class OrdenDetalle
    {
        [Key]
        public int OrdenDetalleId { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public float Importe { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Producto Producto { get; set; }

        public OrdenDetalle()
        {
            OrdenDetalleId = 0;
            OrdenId = 0;
        }

        public OrdenDetalle(int ordenDetalleId, int ordenId, int productoId, int cantidad, int precio, float importe)
        {
            OrdenDetalleId = ordenDetalleId;
            OrdenId = ordenId;
            ProductoId = productoId;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }
    }
}
