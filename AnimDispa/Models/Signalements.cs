using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimDispa.Models
{
    public class Signalements {

        public int Id { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public DateTime Date { get; set; }
        public string Commentaire { get; set; }
        public Animaux IdAnimaux { get; set; }
        
        public Signalements(int id, float latitude, float longitude, DateTime date, string commentaire)
        {
            Id = id;
            Latitude = latitude;
            Longitude = longitude;
            Date = date;
            Commentaire = commentaire;
        }
    }
}