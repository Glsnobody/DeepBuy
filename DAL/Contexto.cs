using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<EntradaProducto> Entradas { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<OrdenDetalle> OrdenesDetalles { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}
