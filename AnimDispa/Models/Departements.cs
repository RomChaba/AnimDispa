using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AnimDispa.Models
{
    public class Departements
    {

        public int Id { get; set; }
        public string numero { get; set; }
        public string Libelle { get; set; }


        public virtual ICollection<Animaux> LesAnimaux { get; set; }









        public Departements() {
            
        }
        
    }
}