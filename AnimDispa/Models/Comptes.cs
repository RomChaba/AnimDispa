using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimDispa.Models
{
    public class Comptes
    {
        public Comptes(int id, string nom, string prenom, string login, string password, string mail, int telephone, string adresse, int codePostal, string ville)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Login = login;
            Password = password;
            Mail = mail;
            Telephone = telephone;
            Adresse = adresse;
            CodePostal = codePostal;
            Ville = ville;
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public int Telephone { get; set; }
        public string Adresse { get; set; }
        public int CodePostal { get; set; }
        public string Ville { get; set; }

        public StatutsComptes IdStatutsComptes { get; set; }
        public Roles IdRoles { get; set; }

        

    }

}