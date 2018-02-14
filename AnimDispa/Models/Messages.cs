using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimDispa.Models
{
    public class Messages
    {
        public Messages(int id, string libelle, DateTime date)
        {
            Id = id;
            Libelle = libelle;
            Date = date;
        }

        public int Id { get; set; }
        public string Libelle { get; set; }
        public DateTime Date { get; set; }
        public Comptes IdComptes { get; set; }
        public Animaux IdAnimaux { get; set; }
        public Messages IdMessages { get; set; }
    }
}