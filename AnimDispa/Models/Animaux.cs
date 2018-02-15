using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AnimDispa.Models
{
    [Table("Animaux")]
    public class Animaux {
        
        public int Id { get; set; }
        public string Nom { get; set; }
        public decimal Poids { get; set; }
        public string Couleur { get; set; }
        public string Tatouage { get; set; }
        public string Puce { get; set; }
        public string PhotoPrincipale { get; set; }
        
        public int IdVille { get; set; }
        [ForeignKey(nameof(IdVille))]
        public virtual Villes Ville { get; set; }

        public int IdRaces { get; set; }
        [ForeignKey(nameof(IdRaces))]
        public virtual Races Race { get; set; }

        public int IdCompte { get; set; }
        [ForeignKey(nameof(IdCompte))]
        public virtual Comptes Compte { get; set; }

        public int idStatut { get; set; }
        [ForeignKey(nameof(idStatut))]
        public virtual StatutsAnimaux StatutAnimal { get; set; }




        public Animaux()
        {

        }

        public Animaux(int id, string nom, decimal poids, string couleur, string tatouage, string puce, string photoPrincipale)
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