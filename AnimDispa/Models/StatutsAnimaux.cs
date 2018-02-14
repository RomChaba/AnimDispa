using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimDispa.Models
{
    public class StatutsAnimaux {

        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Couleur { get; set; }
        public int Ordre { get; set; }

        public StatutsAnimaux(int id, string libelle, string couleur, int ordre)
        {
            Id = id;
            Libelle = libelle;
            Couleur = couleur;
            Ordre = ordre;
        }
    }
}