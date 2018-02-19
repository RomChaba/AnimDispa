using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AnimDispa.Models
{
    public class Messages
    {
        public Messages() {                

        }
        
        public Messages(string libelle, DateTime date, Comptes compte, Animaux animal)
        {
            Libelle = libelle;
            Date = date;
            Compte = compte;
            Animal = animal;
        }

        public int Id { get; set; }
        public string Libelle { get; set; }
        public DateTime Date { get; set; }

        public int IdComptes { get; set; }
        [ForeignKey(nameof(IdComptes))]
        public virtual Comptes Compte { get; set; }

        public int IdAnimaux { get; set; }
        [ForeignKey(nameof(IdAnimaux))]
        public virtual Animaux Animal { get; set; }

    }
}