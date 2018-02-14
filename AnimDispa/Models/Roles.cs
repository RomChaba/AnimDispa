namespace AnimDispa.Models
{
    public class Roles
    {
        public Roles(int id, string libelle)
        {
            Id = id;
            Libelle = libelle;
        }

        public int Id { get; set; }
        public string Libelle { get; set; }
    }
}