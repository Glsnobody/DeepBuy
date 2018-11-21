﻿using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeepBuy.UI.Registros
{
    public partial class rEntradas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void Limpiar()
        {
            entradaIdTextbox.Text = "0";
            fechaTextbox.Text = string.Empty;
            productoIdTextbox.Text = "0";
            cantidadTextbox.Text = "0";
        }

        private void LlenaCampos(EntradaProducto entrada)
        {
            entradaIdTextbox.Text = entrada.EntradaId.ToString();
            fechaTextbox.Text = entrada.Fecha.ToString("yyyy-MM-dd");
            productoIdTextbox.Text = entrada.ProductoId.ToString();
            cantidadTextbox.Text = entrada.Cantidad.ToString();
        }

        private EntradaProducto LlenaClase()
        {
            var entrada = new EntradaProducto();
            entrada.Fecha = Convert.ToDateTime(fechaTextbox.Text);
            entrada.ProductoId = int.Parse(productoIdTextbox.Text);
            entrada.Cantidad = int.Parse(cantidadTextbox.Text);

            return entrada;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(entradaIdTextbox.Text))
            {
                int id = Convert.ToInt32(entradaIdTextbox.Text);
                if (id != 0)
                {
                    RepositorioEntrada repositorio = new RepositorioEntrada();
                    EntradaProducto entrada = repositorio.Buscar(id);

                    if (entrada != null)
                    {
                        LlenaCampos(entrada);
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
            int id = Convert.ToInt32(entradaIdTextbox.Text);
            if (!(productoIdTextbox.Text == "0" || cantidadTextbox.Text == "0" || String.IsNullOrEmpty(fechaTextbox.Text)))
            {
                RepositorioEntrada repositorio = new RepositorioEntrada();
                if (id == 0)
                {
                    repositorio.Guardar(LlenaClase());
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Guardado con Exito')", true);
                }
                else
                {
                    if (repositorio.Buscar(id) != null)
                    {
                        EntradaProducto entrada = repositorio.Buscar(int.Parse(entradaIdTextbox.Text));

                        entrada.ProductoId = int.Parse(entradaIdTextbox.Text);
                        entrada.Fecha = DateTime.Parse(fechaTextbox.Text);
                        entrada.Cantidad = int.Parse(cantidadTextbox.Text);

                        repositorio.Modificar(entrada);

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
            int id = Convert.ToInt32(entradaIdTextbox.Text);
            if (id != 0)
            {
                RepositorioEntrada repositorio = new RepositorioEntrada();
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