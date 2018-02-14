using AnimDispa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimDispa.DAL
{
    public class DbAnimaux
    {
        #region Singleton

        private static DbAnimaux _instance;
        public static DbAnimaux GetInstance()
        {
            if (_instance == null)
                _instance = new DbAnimaux();
            return _instance;
        }

        #endregion

        #region Requêtes const

        private const string RQT_GET_ONE_ANIMAUX = "SELECT * FROM Animaux WHERE id = @id";
        
        private const string RQT_ADD_RACE = "INSERT INTO Animaux VALUES (@nom, @poids, @couleur, @tatouage, @puce, @idComptes, @idRaces, @idStatuts, @idVille, @photoMain)";

        /*private const string RQT_GET_LAST_ADDED = "SELECT IDENT_CURRENT('Course')";*/

        #endregion

        #region Public methods

        public int AddAnimaux(Animaux animaux)
        {
            if (race == null) return 0;

            int retour = 0;

            try
            {
                var instance = new DbTools();

                // Préparation d'une transaction
                var transac = instance.CreerTransaction();

                // Exécution de la requête d'ajout + on l'inclut dans la transaction
                var commandAdd = instance.CreerRequete(RQT_ADD_RACE);
                instance.CreerParametre(commandAdd, "@title", race.Title);
                instance.CreerParametre(commandAdd, "@description", race.Description);
                instance.CreerParametre(commandAdd, "@datestart", race.DateStart);
                instance.CreerParametre(commandAdd, "@dateend", race.DateEnd);
                instance.CreerParametre(commandAdd, "@ville", race.Town);
                commandAdd.Transaction = transac;
                commandAdd.ExecuteNonQuery();

                // Exécution de la requête de recupération du dernier id ajouté + on l'inclut dans la transaction
                var commandSelect = instance.CreerRequete(RQT_GET_LAST_ADDED);
                commandSelect.Transaction = transac;

                retour = Convert.ToInt32(commandSelect.ExecuteScalar());
                if (retour > 0)
                {
                    transac.Commit();
                }
                else
                {
                    transac.Rollback();
                }
            }
            catch (Exception)
            {
                retour = 0;
            }

            return retour;
        }

        public List<Race> GetRace()
        {
            List<Race> list = new List<Race>();

            var instance = new DbTools();
            var command = instance.CreerRequete(RQT_GET_RACE);

            DbDataReader reader = command.ExecuteReader();
            return this.BuildRaceList(reader);
        }

        public Race GetRace(int id)
        {
            var instance = new DbTools();
            var command = instance.CreerProcedureStockee(RQT_GET_RACE_PS);
            instance.CreerParametre(command, "@id", id, ParameterDirection.Input, DbType.Int32);

            DbDataReader reader = command.ExecuteReader();
            return this.BuildRace(reader);
        }

        #endregion

        #region Private methods

        private List<Race> BuildRaceList(DbDataReader reader)
        {
            List<Race> list = new List<Race>();

            while (reader.Read())
            {
                var raceId = reader.GetInt32(reader.GetOrdinal("CId"));

                Race r;
                if (list.All(x => x.Id != raceId))
                {
                    r = new Race
                    {
                        Id = raceId,
                        Title = reader.GetString(reader.GetOrdinal("CTitre")),
                        Description = reader.GetString(reader.GetOrdinal("CDescription")),
                        DateStart = reader.GetDateTime(reader.GetOrdinal("CDateStart")),
                        DateEnd = reader.GetDateTime(reader.GetOrdinal("CDateEnd")),
                        Town = reader.GetString(reader.GetOrdinal("CVille")),
                        Competitors = new List<Competitor>(),
                        Organisers = new List<Organizer>()
                    };
                    list.Add(r);
                }
                else
                {
                    r = list.Single(x => x.Id == raceId);
                }

                // Récupération du type de participans
                var isCompetitor = reader.GetBoolean(reader.GetOrdinal("PctEstCompetiteur"));
                var isOrganiser = reader.GetBoolean(reader.GetOrdinal("PctEstOrganisateur"));
                if (isCompetitor)
                {
                    Competitor c = new Competitor
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("PId")),
                        Nom = reader.GetString(reader.GetOrdinal("PNom")),
                        Prenom = reader.GetString(reader.GetOrdinal("PPrenom")),
                        Email = reader.GetString(reader.GetOrdinal("PEmail")),
                        Phone = reader.GetString(reader.GetOrdinal("PTelephone")),
                        DateNaissance = reader.GetDateTime(reader.GetOrdinal("PDateNaissance")),
                        Race = r
                    };
                    r.Competitors.Add(c);
                }

                if (isOrganiser)
                {
                    Organizer o = new Organizer
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("PId")),
                        Nom = reader.GetString(reader.GetOrdinal("PNom")),
                        Prenom = reader.GetString(reader.GetOrdinal("PPrenom")),
                        Email = reader.GetString(reader.GetOrdinal("PEmail")),
                        Phone = reader.GetString(reader.GetOrdinal("PTelephone")),
                        DateNaissance = reader.GetDateTime(reader.GetOrdinal("PDateNaissance"))
                    };
                    r.Organisers.Add(o);
                }
            }

            return list;
        }

        private Race BuildRace(DbDataReader reader)
        {
            // On lit la première ligne
            var result = reader.Read();

            Race r = null;
            if (result)
            {
                // On construit l'objet
                r = new Race
                {
                    Id = reader.GetInt32(reader.GetOrdinal("CId")),
                    Title = reader.GetString(reader.GetOrdinal("CTitre")),
                    Description = reader.GetString(reader.GetOrdinal("CDescription")),
                    DateStart = reader.GetDateTime(reader.GetOrdinal("CDateStart")),
                    DateEnd = reader.GetDateTime(reader.GetOrdinal("CDateEnd")),
                    Town = reader.GetString(reader.GetOrdinal("CVille"))
                };
            }

            return r;
        }

        #endregion
    }
}