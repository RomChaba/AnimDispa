using AnimDispa.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace AnimDispa.DAL
{
    public class DbAnimaux {

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
        private const string RQT_GET_ALL_ANIMAUX = "SELECT * FROM Animaux";
        private const string RQT_ADD_ANIMAUX = "INSERT INTO Animaux VALUES (@nom, @poids, @couleur, @tatouage, @puce, @idComptes, @idRaces, @idStatuts, @idVille, @photoMain)";
        private const string RQT_GET_LAST_ADDED = "SELECT IDENT_CURRENT('Animaux')";

        #endregion

        #region Public methods

        public int Add(Animaux animaux) {
            if (animaux == null) return 0;

            int retour = 0;

            try {
                var instance = new DbTools();

                // Préparation d'une transaction
                var transac = instance.CreerTransaction();

                // Exécution de la requête d'ajout + on l'inclut dans la transaction
                var animal = instance.CreerRequete(RQT_ADD_ANIMAUX);
                instance.CreerParametre(animal, "@nom", animaux.Nom);
                instance.CreerParametre(animal, "@poids", animaux.Poids);
                instance.CreerParametre(animal, "@couleur", animaux.Couleur);
                instance.CreerParametre(animal, "@tatouage", animaux.Tatouage);
                instance.CreerParametre(animal, "@puce", animaux.Puce);
                instance.CreerParametre(animal, "@idComptes", animaux.IdComptes);
                instance.CreerParametre(animal, "@idRaces", animaux.IdRaces);
                instance.CreerParametre(animal, "@idStatuts", animaux.IdStatutsAnimaux);
                instance.CreerParametre(animal, "@idVille", animaux.IdVilles);
                instance.CreerParametre(animal, "@photoMain", animaux.PhotoPrincipale);
                animal.Transaction = transac;
                animal.ExecuteNonQuery();

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

        public List<Animaux> GetAll()
        {
            List<Animaux> list = new List<Animaux>();

            var instance = new DbTools();
            var command = instance.CreerRequete(RQT_GET_ALL_ANIMAUX);

            DbDataReader reader = command.ExecuteReader();
            return this.BuildAnimauxList(reader);
        }

        public Animaux GetOne(int id)
        {
            var instance = new DbTools();
            var animal = instance.CreerProcedureStockee(RQT_GET_ONE_ANIMAUX);
            instance.CreerParametre(animal, "@id", id, ParameterDirection.Input, DbType.Int32);

            DbDataReader reader = animal.ExecuteReader();
            return this.BuildAnimaux(reader);
        }

        #endregion

        #region Private methods

        private List<Animaux> BuildAnimauxList(DbDataReader reader)
        {
            List<Animaux> list = new List<Animaux>();

            while (reader.Read())
            {
                var animauxId = reader.GetInt32(reader.GetOrdinal("id"));

                Animaux a;
                if (list.All(x => x.Id != animauxId))
                {
                    a = new Animaux
                    {
                        Id = animauxId,
                        Nom = reader.GetString(reader.GetOrdinal("nom")),
                        Poids = reader.GetFloat(reader.GetOrdinal("poids")),
                        Couleur = reader.GetString(reader.GetOrdinal("couleur")),
                        Tatouage = reader.GetString(reader.GetOrdinal("tatouage")),
                        Puce = reader.GetString(reader.GetOrdinal("puce"))
                        /*,IdComptes = reader.Get(reader.GetOrdinal("CVille")),
                        Competitors = new List<Competitor>(),
                        Organisers = new List<Organizer>()*/
                    };
                    list.Add(a);
                }
                else
                {
                    a = list.Single(x => x.Id == animauxId);
                }
            }
            return list;
        }

        private Animaux BuildAnimaux(DbDataReader reader)
        {
            // On lit la première ligne
            var result = reader.Read();

            Animaux a = null;
            if (result)
            {
                // On construit l'objet
                a = new Animaux
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    Nom = reader.GetString(reader.GetOrdinal("nom")),
                    Poids = reader.GetFloat(reader.GetOrdinal("poids")),
                    Couleur = reader.GetString(reader.GetOrdinal("couleur")),
                    Tatouage = reader.GetString(reader.GetOrdinal("tatouage")),
                    Puce = reader.GetString(reader.GetOrdinal("puce"))
                };
            }

            return a;
        }

        #endregion
    }
}