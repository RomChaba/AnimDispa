﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AnimDispa.Models
{
    public class Signalements {

        public int Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime Date { get; set; }
        public string Commentaire { get; set; }
        public int IdAnimaux { get; set; }
        [ForeignKey(nameof(IdAnimaux))]
        public virtual Animaux Animaux { get; set; }

        public Signalements()
        {

        }

        public Signalements(int id, string latitude, string longitude, DateTime date, string commentaire)
        {
            Id = id;
            Latitude = latitude;
            Longitude = longitude;
            Date = date;
            Commentaire = commentaire;
        }
    }
}