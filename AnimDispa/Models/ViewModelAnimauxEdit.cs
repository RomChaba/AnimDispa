using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimDispa.Models
{
    public class ViewModelAnimauxEdit {
        
        public IEnumerable<Races> lesRaces { get; set; }

        public IEnumerable<Types> lesTypes { get; set; }

        public IEnumerable<Departements> lesDepartements { get; set; }
        
        public IEnumerable<StatutsAnimaux> LesStatutsAnimaux { get; set; }

        public Animaux animal { get; set; }
    }
}