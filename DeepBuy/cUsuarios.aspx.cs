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
    public partial class cUsuarios : System.Web.UI.Page
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
                Expression<Func<Usuario, bool>> filtro = x => true;
                BLL.RepositorioBase<Usuario> repositorio = new BLL.RepositorioBase<Usuario>();

                int id;
                switch (BuscarPorDropDownList.SelectedIndex)
                {
                    case 0:
                        filtro = c => true;
                        break;
                    case 1://ID
                        id = Convert.ToInt32(FiltroTextBox.Text);
                        filtro = c => c.UsuarioId == id;
                        break;
                    case 2://Nombre
                        filtro = c => c.Nombre.Contains(FiltroTextBox.Text);
                        break;
                    case 3://Apellido
                        filtro = c => c.Apellido.Contains(FiltroTextBox.Text);
                        break;
                    case 4://Email
                        filtro = c => c.Email.Contains(FiltroTextBox.Text);
                        break;
                }

                DatosGridView.DataSource = repositorio.GetList(filtro);
                DatosGridView.DataBind();
            }
        }
    }
}