using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimDispa.Models
{
    public class ViewModelListeAnimaux {

        
        public IEnumerable<Animaux> animaux { get; set; }

        public IEnumerable<Types> LesTypes { get; set; }

        public IEnumerable<StatutsAnimaux> LesStatuts { get; set; }

        public string Nom { get; set; }

        public string IdStatut { get; set; }

        public string IdType { get; set; }
    }
}