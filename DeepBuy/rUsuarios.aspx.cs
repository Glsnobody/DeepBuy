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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            usuarioIdTextbox.Text = "0";
            nombreTextbox.Text = string.Empty;
            apellidoTextbox.Text = string.Empty;
            emailTextbox.Text = string.Empty;
            passwordTextbox.Text = string.Empty;
            ordenesTextbox.Text = "0";
        }

        private void LlenaCampos(Usuario usuario)
        {
            usuarioIdTextbox.Text = usuario.UsuarioId.ToString();
            nombreTextbox.Text = usuario.Nombre;
            apellidoTextbox.Text = usuario.Apellido;
            emailTextbox.Text = usuario.Email;
            passwordTextbox.Text = usuario.Password;
            ordenesTextbox.Text = usuario.Ordenes.ToString();
        }

        private Usuario LlenaClase()
        {
            var usuario = new Usuario();
            usuario.Nombre = nombreTextbox.Text;
            usuario.Apellido = apellidoTextbox.Text;
            usuario.Email = emailTextbox.Text;
            usuario.Password = passwordTextbox.Text;

            return usuario;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(usuarioIdTextbox.Text))
            {
                int id = Convert.ToInt32(usuarioIdTextbox.Text);
                if (id != 0)
                {
                    RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
                    Usuario usuario = repositorio.Buscar(id);

                    if (usuario != null)
                    {
                        LlenaCampos(usuario);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('No existe')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Seleccione un ID')", true);
                }
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(usuarioIdTextbox.Text);
            if (!(String.IsNullOrEmpty(nombreTextbox.Text) || String.IsNullOrEmpty(apellidoTextbox.Text) || String.IsNullOrEmpty(emailTextbox.Text) || String.IsNullOrEmpty(passwordTextbox.Text)))
            {
                RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
                if (id == 0)
                {
                    repositorio.Guardar(LlenaClase());
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Guardado con Exito')", true);
                }
                else
                {
                    if (repositorio.Buscar(id) != null)
                    {
                        Usuario usuario = repositorio.Buscar(int.Parse(usuarioIdTextbox.Text));

                        usuario.UsuarioId = int.Parse(usuarioIdTextbox.Text);
                        usuario.Nombre = nombreTextbox.Text;
                        usuario.Apellido = apellidoTextbox.Text;
                        usuario.Email = emailTextbox.Text;
                        usuario.Password = nombreTextbox.Text;

                        repositorio.Modificar(usuario);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Modificado con Exito')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('No existe una categoria con ese ID, no puede modificarse')", true);
                    }
                }
            }
            else if (id == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Rellene todos los campos')", true);
            }
            Limpiar();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(usuarioIdTextbox.Text);
            if (id != 0)
            {
                RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
                if (repositorio.Buscar(id) != null)
                {
                    if (repositorio.Eliminar(id))
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Eliminado con Exito')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('No se pudo eliminar')", true);
                    }
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('No existe')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Seleccione un ID')", true);
            }
        }
    }
}