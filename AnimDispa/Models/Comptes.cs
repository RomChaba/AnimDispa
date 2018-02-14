using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AnimDispa.Models
{
    public class Comptes
    {
        public Comptes()
        {

        }
        public Comptes(int id, string nom, string prenom, string login, string password, string mail, string telephone, string adresse, string codePostal, string ville)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Login = login;
            Password = password;
            Mail = mail;
            Tel = telephone;
            Adresse = adresse;
            CodePostal = codePostal;
            Ville = ville;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string Tel { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }


        [ForeignKey("Id")]
        public StatutsComptes IdStatutsComptes { get; set; }
        [ForeignKey("Id")]
        public Roles IdRoles { get; set; }



    }

}