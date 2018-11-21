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
    public partial class cEntradas : System.Web.UI.Page
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
                Expression<Func<EntradaProducto, bool>> filtro = x => true;
                BLL.RepositorioEntrada repositorio = new BLL.RepositorioEntrada();

                int id;
                switch (BuscarPorDropDownList.SelectedIndex)
                {
                    case 0:
                        filtro = c => true;
                        break;
                    case 1://ID
                        id = Convert.ToInt32(FiltroTextBox.Text);
                        filtro = c => c.EntradaId == id;
                        break;
                    case 2://ProductoId
                        id = Convert.ToInt32(FiltroTextBox.Text);
                        filtro = c => c.ProductoId == id;
                        break;
                    case 3://ProductoId
                        id = Convert.ToInt32(FiltroTextBox.Text);
                        filtro = c => c.Cantidad == id;
                        break;
                }

                DatosGridView.DataSource = repositorio.GetList(filtro);
                DatosGridView.DataBind();
            }
        }
    }
}