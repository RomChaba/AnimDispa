using System.Collections.Generic;

namespace AnimDispa.Models
{
    public class Roles
    {

        public Roles()
        {

        }

        public Roles(int id, string libelle, string couleur)
        {
            Id = id;
            Libelle = libelle;
            Couleur = couleur;
        }

        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Couleur { get; set; }

        public virtual ICollection<Comptes> LesComptes { get; set; }
    }
}