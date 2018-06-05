using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using RegistroPrimerParcial.Entidades;

namespace RegistroPrimerParcial.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Grupos> Grupos { get; set; }

        public Contexto() : base("ConStr")
        {
        }
    }
}
