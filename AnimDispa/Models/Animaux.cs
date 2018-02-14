using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimDispa.Models
{
    public class Animaux {
        
        public int Id { get; set; }
        public string Nom { get; set; }
        public float Poids { get; set; }
        public string Couleur { get; set; }
        public string Tatouage { get; set; }
        public string Puce { get; set; }
        public string PhotoPrincipale { get; set; }
        public Comptes IdComptes { get; set; }
        public Races IdRaces { get; set; }
        public StatutsAnimaux IdStatutsAnimaux { get; set; }
        public Villes IdVilles { get; set; }

        public Animaux(int id, string nom, float poids, string couleur, string tatouage, string puce, string photoPrincipale)
        {
            Id = id;
            Nom = nom;
            Poids = poids;
            Couleur = couleur;
            Tatouage = tatouage;
            Puce = puce;
            PhotoPrincipale = photoPrincipale;
        }
    }
}