using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimDispa.Models {

    public class Config {

        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Value { get; set; }

        public Config(int id, string libelle, string value)
        {
            Id = id;
            Libelle = libelle;
            Value = value;
        }
    }
}