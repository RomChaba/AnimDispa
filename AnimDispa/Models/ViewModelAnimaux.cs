using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimDispa.Models
{
    public class ViewModelAnimaux {
        public Animaux animal { get; set; }
        public IEnumerable<Messages> lesMessages { get; set; }
    }
}