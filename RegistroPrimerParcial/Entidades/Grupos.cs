using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RegistroPrimerParcial.Entidades
{
    public class Grupos
    {
        [Key]//Llave primaria.

        public int GrupoId { get; set; }

        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; }

        public int Cantidad { get; set; }

        public int GrupoCant { get; set; }

        public float Integrantes { get; set; }

        //Constructor
        public Grupos()
        {
            GrupoId = 0;
            Fecha = DateTime.Now;
            Descripcion = string.Empty;
            Cantidad = 0;
            GrupoCant = 0;
            Integrantes = 0;
        }

    }
}
