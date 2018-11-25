using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeepBuy.UI.Registros
{
    public partial class rProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            productoIdTextbox.Text = "0";
            descripcionTextbox.Text = string.Empty;
            precioTextbox.Text = "0";
            inventarioTextbox.Text = "0";
        }

        private void LlenaCampos(Producto producto)
        {
            productoIdTextbox.Text = producto.ProductoId.ToString();
            descripcionTextbox.Text = producto.Descripcion;
            precioTextbox.Text = producto.Precio.ToString();
            inventarioTextbox.Text = producto.Inventario.ToString();
        }

        private Producto LlenaClase()
        {
            var producto = new Producto();
            producto.Descripcion = descripcionTextbox.Text;
            producto.Precio = float.Parse(precioTextbox.Text);
            producto.Inventario = int.Parse(inventarioTextbox.Text);

            return producto;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(productoIdTextbox.Text))
            {
                int id = Convert.ToInt32(productoIdTextbox.Text);
                if (id != 0)
                {
                    RepositorioBase<Producto> repositorio = new RepositorioBase<Producto>();
                    Producto producto = repositorio.Buscar(id);

                    if (producto != null)
                    {
                        LlenaCampos(producto);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "toastr_message", script: "toastr['error']('No existe');", addScriptTags: true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "toastr_message", script: "toastr['warning']('Seleccione un ID');", addScriptTags: true);
                }
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int id = Convert.ToInt32(productoIdTextbox.Text);
                if (!(String.IsNullOrEmpty(descripcionTextbox.Text) || String.IsNullOrEmpty(precioTextbox.Text) || String.IsNullOrEmpty(inventarioTextbox.Text)))
                {
                    RepositorioBase<Producto> repositorio = new RepositorioBase<Producto>();
                    if (id == 0)
                    {
                        repositorio.Guardar(LlenaClase());
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "toastr_message", script: "toastr['success']('Guardado con Exito');", addScriptTags: true);
                    }
                    else
                    {
                        if (repositorio.Buscar(id) != null)
                        {
                            Producto producto = repositorio.Buscar(int.Parse(productoIdTextbox.Text));

                            producto.ProductoId = int.Parse(productoIdTextbox.Text);
                            producto.Descripcion = descripcionTextbox.Text;
                            producto.Precio = float.Parse(precioTextbox.Text);

                            repositorio.Modificar(producto);

                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "toastr_message", script: "toastr['success']('Modificado con Exito');", addScriptTags: true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "toastr_message", script: "toastr['error']('No existe un producto con ese ID, no puede modificarse');", addScriptTags: true);
                        }
                    }
                }
                else if (id == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "toastr_message", script: "toastr['warning']('Debe rellenar todos los campos');", addScriptTags: true);
                }
                Limpiar();
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(productoIdTextbox.Text);
            if (id != 0)
            {
                RepositorioBase<Producto> repositorio = new RepositorioBase<Producto>();
                if (repositorio.Buscar(id) != null)
                {
                    if (repositorio.Eliminar(id))
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "toastr_message", script: "toastr['success']('Eliminado con Exito');", addScriptTags: true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "toastr_message", script: "toastr['error']('No se pudo eliminar');", addScriptTags: true);
                    }
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "toastr_message", script: "toastr['error']('No existe');", addScriptTags: true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "toastr_message", script: "toastr['warning']('Seleccione un ID');", addScriptTags: true);
            }
        }
    }
}