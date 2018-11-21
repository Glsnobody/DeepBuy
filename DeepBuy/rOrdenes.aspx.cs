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
    public partial class rOrdenes : System.Web.UI.Page
    {
        RepositorioOrden repositorio = new RepositorioOrden();
        List<OrdenDetalle> Detalle = new List<OrdenDetalle>();

        protected void Page_Load(object sender, EventArgs e)
        {
            DatosGridView.Visible = true;
            DatosGridView.DataBind();
        }

        void Limpiar()
        {
            ordenIdTextbox.Text = "0";
            fechaTextbox.Text = DateTime.Today.ToString();
            usuarioIdTextbox.Text = "1";
            DatosGridView.Visible = true;
            DatosGridView.DataBind();
        }

        private Orden LlenaClase()
        {
            var Entidad = new Orden();

            Entidad.UsuarioId = int.Parse(usuarioIdTextbox.Text);
            Entidad.Detalle = Detalle;

            return Entidad;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ordenIdTextbox.Text == "0")
            {
                repositorio.Guardar(LlenaClase());
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Guardado con exito.')", true);
            }
            else
            {
                Orden orden = repositorio.Buscar(int.Parse(ordenIdTextbox.Text));

                orden = LlenaClase();

                repositorio.Modificar(orden);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Modificado con Exito.')", true);
            }
            Limpiar();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {

        }
    }
}