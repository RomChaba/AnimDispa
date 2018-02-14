using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimDispa.Models
{
    public class Types {
        public int Id { get; set; }
        public string Libelle { get; set; }

        public Types(int id, string libelle) {
            Id = id;
            Libelle = libelle;
        }

    }
}