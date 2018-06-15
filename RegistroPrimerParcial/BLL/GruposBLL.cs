using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Entity;
using RegistroPrimerParcial.DAL;
using RegistroPrimerParcial.Entidades;

namespace RegistroPrimerParcial.BLL
{

    public class GruposBLL
    {
        //Agregar una nueva entidad a la base de datos.
        public static bool Guardar(Grupos grupos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Grupos.Add(grupos) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

       //Modificar entidad en la base datos.
        public static bool Modificar(Grupos grupos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //recorrer el detalle
                foreach (var item in grupos.Detalle)
                {
                    //Muy importante indicar que pasara con la entidad del detalle
                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                    contexto.Entry(item).State = estado;
                }

                contexto.Entry(grupos).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        //Eliminar una entidad en la base de datos
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Grupos grupos = contexto.Grupos.Find(id);
                contexto.Grupos.Remove(grupos);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                    contexto.Dispose();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        //Buscar una entidad en la base de datos
        public static Grupos Buscar(int id)
        {
            Grupos grupos = new Grupos();
            Contexto contexto = new Contexto();

            try
            {
                grupos = contexto.Grupos.Find(id);

                grupos.Detalle.Count();
                //Cargar los nombres de las personas
                foreach (var item in grupos.Detalle)
                {
                    //forzando la persona a cargarse
                    string s = item.Personas.Nombres;
                }

                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return grupos;
        }

        //Lista de entidades.
        public static List<Grupos> GeTList(Expression<Func<Grupos, bool>> expression)
        {
            List<Grupos> grupos = new List<Grupos>();
            Contexto contexto = new Contexto();
            try
            {
                grupos = contexto.Grupos.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return grupos;
        }
    }
}
