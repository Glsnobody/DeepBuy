using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public int Inventario { get; set; }

        public Producto()
        {
            ProductoId = 0;
            Descripcion = string.Empty;
            Precio = 0f;
            Inventario = 0;
        }

        public Producto(int productoId, string descripcion, float precio, int inventario)
        {
            ProductoId = productoId;
            Descripcion = descripcion;
            Precio = precio;
            Inventario = inventario;
        }
    }
}
