using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroPrimerParcial.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RegistroPrimerParcial.Entidades;
using RegistroPrimerParcial.DAL;
using System.Linq.Expressions;

namespace RegistroPrimerParcial.BLL.Tests
{
    [TestClass()]
    public class GruposBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Grupos grupos = new Grupos();
            grupos.GrupoId = 1;
            grupos.Fecha = DateTime.Now;
            grupos.Descripcion = "Aplicados";
            grupos.Cantidad = 40;
            grupos.GrupoCant = 5;
            paso = BLL.GruposBLL.Guardar(grupos);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Grupos grupos = new Grupos();
            grupos.GrupoId = 1;
            grupos.Fecha = DateTime.Now;
            grupos.Descripcion = "Aplicados";
            grupos.Cantidad = 22;
            grupos.GrupoCant = 11;
            paso = BLL.GruposBLL.Modificar(grupos);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            Grupos grupos = new Grupos();
            int id;
            grupos.GrupoId = 1;
            grupos.Fecha = DateTime.Now;
            grupos.Descripcion = "Aplicados";
            grupos.Cantidad = 22;
            grupos.GrupoCant = 11;
            id = grupos.GrupoId;
            paso = BLL.GruposBLL.Eliminar(id);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 5;
            Contexto contexto = new Contexto();
            Grupos grupos = new Grupos();
            grupos = contexto.Grupos.Find(id);
            Assert.IsNotNull(id);
        }

        [TestMethod()]
        public void GeTListTest()
        {
            var list = GruposBLL.GeTList(g=>true);
            Assert.IsNotNull(list);
        }
    }
}