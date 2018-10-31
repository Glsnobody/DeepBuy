using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Orden
    {
        [Key]
        public int OrdenId { get; set; }
        public DateTime FechaOrden { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int ClienteId { get; set; }
        public int Cantidad { get; set; }
        public float SubTotal { get; set; }
        public float Itbis { get; set; }
        public float Total { get; set; }

        public virtual ICollection<OrdenDetalle> Detalle { get; set; }

        public Orden()
        {
            this.Detalle = new List<OrdenDetalle>();
            OrdenId = 0;
            FechaOrden = DateTime.Now;
            FechaEntrega = DateTime.Now;
            ClienteId = 0;
            Cantidad = 1;
            SubTotal = 0f;
            Itbis = 0f;
            Total = 0f;
        }

        public void AgregarDetalle(int ordenDetalleId, int ordenId, int productoId, int cantidad, int precio, float importe)
        {
            this.Detalle.Add(new OrdenDetalle(ordenDetalleId, ordenId, productoId, cantidad, precio, importe));
        }
    }
}
