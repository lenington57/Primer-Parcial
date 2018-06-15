using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroPrimerParcial.Entidades
{
    public class GruposDetalle
    {
        [Key]
        public int Id { get; set; }

        public int GrupoId { get; set; }

        public int PersonaId { get; set; }

        public string Cargo { get; set; }


        [ForeignKey("PersonaId")]//Llave Foránea.
        public virtual Personas Personas { get; set; }

        public GruposDetalle()
        {
            Id = 0;
            GrupoId = 0;
            PersonaId = 0;
            Cargo = string.Empty;
        }
        //Recordar que es opcional.
        public GruposDetalle(int id, int grupoId, int personaId, string cargo)
        {
            this.Id = id;
            this.GrupoId = grupoId;
            this.PersonaId = personaId;
            this.Cargo = cargo;
        }
    }
}
