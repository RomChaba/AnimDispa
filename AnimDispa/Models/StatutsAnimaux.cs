using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AnimDispa.Models
{
    [Table("StatutsAnimaux")]
    public class StatutsAnimaux {

        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Couleur { get; set; }
        public int Ordre { get; set; }
        public virtual ICollection<Animaux> LesAnimaux { get; set; }

        public StatutsAnimaux() {
            
        }

        public StatutsAnimaux(int id, string libelle, string couleur, int ordre)
        {
            Id = id;
            Libelle = libelle;
            Couleur = couleur;
            Ordre = ordre;
        }
    }
}