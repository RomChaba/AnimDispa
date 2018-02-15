using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AnimDispa.Models
{
    public class Races { 

        public int Id { get; set; }
        public string Libelle { get; set; }
        public int IdType { get; set; }
        [ForeignKey(nameof(IdType))]
        public virtual Types Type { get; set; }
        public virtual ICollection<Animaux> LesAnimaux { get; set; }

        public Races() {

        }

        public Races(int id, string libelle) {
            Id = id;
            Libelle = libelle;
        }
    }
}