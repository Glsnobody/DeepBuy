using System;
using BLL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeepBuy.Tests
{
    [TestClass]
    public class RepositorioBaseTests
    {
        RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
        Usuario usuario = new Usuario();

        [TestMethod]
        public void Guardar()
        {
            Assert.IsTrue(repositorio.Guardar(usuario));
        }

        [TestMethod]
        public void Buscar()
        {
            var usuario_var = repositorio.Buscar(1);

            Assert.IsNotNull(usuario_var);
        }

        [TestMethod]
        public void Modificar()
        {
            repositorio.Guardar(usuario);
            usuario.Nombre = "Prueba";
            Assert.IsTrue(repositorio.Modificar(usuario));
        }

        [TestMethod]
        public void Eliminar()
        {
            Assert.IsTrue(repositorio.Eliminar(1));
        }
    }
}
