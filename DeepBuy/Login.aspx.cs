using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeepBuy
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Admin> repositorio = new RepositorioBase<Admin>();
            Expression<Func<Admin, bool>> filtrar = x => true;
            Admin user = new Admin();

            filtrar = t => t.Username.Equals(userTextbox.Text) && t.Password.Equals(passTextbox.Text);
            if (repositorio.GetList(filtrar).Count() != 0)
                FormsAuthentication.RedirectFromLoginPage(user.Username, true);
            else
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('Credenciales incorrectas');", addScriptTags: true);
        }
    }
}