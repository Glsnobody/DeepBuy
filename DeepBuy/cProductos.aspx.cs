using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeepBuy.UI.Consultas
{
    public partial class cProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(FiltroTextBox.Text) && BuscarPorDropDownList.SelectedIndex != 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Debe escribir el criterio')", true);
            }
            else
            {
                Expression<Func<Producto, bool>> filtro = x => true;
                BLL.RepositorioBase<Producto> repositorio = new BLL.RepositorioBase<Producto>();

                int id;
                switch (BuscarPorDropDownList.SelectedIndex)
                {
                    case 0:
                        filtro = c => true;
                        break;
                    case 1://ID
                        id = Convert.ToInt32(FiltroTextBox.Text);
                        filtro = c => c.ProductoId == id;
                        break;
                    case 2://Descripcion
                        filtro = c => c.Descripcion.Contains(FiltroTextBox.Text);
                        break;
                    case 3://Precio
                        filtro = c => c.Precio.Equals(FiltroTextBox.Text);
                        break;
                    case 4://Email
                        filtro = c => c.Inventario.Equals(FiltroTextBox.Text);
                        break;
                }

                DatosGridView.DataSource = repositorio.GetList(filtro);
                DatosGridView.DataBind();
            }
        }
    }
}