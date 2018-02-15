using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AnimDispa.Models
{
    public class Villes {

        public int Id { get; set; }
        public string Libelle { get; set; }
        public int CodePostal { get; set; }


        public virtual ICollection<Animaux> LesAnimaux { get; set; }









        public Villes() {
            
        }

        public Villes(int id, string libelle, int cp)
        {
            Id = id;
            Libelle = libelle;
            CodePostal = cp;
        }
    }
}