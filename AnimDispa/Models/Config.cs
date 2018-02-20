using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AnimDispa.Models {

    [Table("Config")]

    public class Config {

        public int Id { get; set; }
        public string Libelle { get; set; }
        public bool Value { get; set; }

        public Config(int id, string libelle, bool value)
        {
            Id = id;
            Libelle = libelle;
            Value = value;
        }

        public Config() {
            
        }
    }
}