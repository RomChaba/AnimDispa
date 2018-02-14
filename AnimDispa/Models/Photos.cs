using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimDispa.Models
{
    public class Photos {

        public int Id { get; set; }
        public string Libelle { get; set; }
        public Animaux IdAnimaux { get; set; }

        public Photos(int id, string libelle) {

            Id = id;
            Libelle = libelle;
        }
    }
}