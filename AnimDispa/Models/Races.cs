using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimDispa.Models
{
    public class Races { 

        public int Id { get; set; }
        public string Libelle { get; set; }
        public Types IdType { get; set; }

        public Races(int id, string libelle) {
            Id = id;
            Libelle = libelle;
        }
    }
}