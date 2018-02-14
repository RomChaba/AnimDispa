namespace AnimDispa.Models
{
    public class StatutsComptes
    {
        public StatutsComptes()
        {

        }
        public StatutsComptes(int id, string libelle)
        {
            Id = id;
            Libelle = libelle;
        }

        public int Id { get; set; }
        public string Libelle { get; set; }

    }
}