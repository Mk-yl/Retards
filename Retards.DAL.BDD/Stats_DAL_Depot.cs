using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Retards.DAL.BDD
{
    public class Stats_DAL_Depot : Depot_DAL<Stats_DAL>
    {
       
       

        public override Stats_DAL Insert(Stats_DAL entity)
        {
            OuvrirConnexion();

            // Insérer l'entité Stats_DAL
            Commande.CommandText = "INSERT INTO Stats (dateDebut, dateFin, NbrCreaCmpt, NbrConnCmpt, NbrCreaPost,  NbrCommMpost, NbrVueMpost, NbrLikeMpost) VALUES (@dateDebut, @dateFin, @nbrCreaCmpt, @NbrConnCmpt, @NbrCreaPost ,@NbrCommMpost, @NbrVueMpost, @NbrLikeMpost); SELECT SCOPE_IDENTITY()";
            Commande.Parameters.AddWithValue("@dateDebut", entity.DateDebut);
            Commande.Parameters.AddWithValue("@dateFin", entity.DateFin);
            Commande.Parameters.AddWithValue("@nbrCreaCmpt", entity.NbrCreaCmpt);
            Commande.Parameters.AddWithValue("@NbrConnCmpt", entity.NbrConnCmpt);
            Commande.Parameters.AddWithValue("@NbrCreaPost", entity.NbrCreaPost);
            Commande.Parameters.AddWithValue("@NbrCommMpost", entity.NbrCommMpost);
            Commande.Parameters.AddWithValue("@NbrVueMpost", entity.NbrVueMpost);
            Commande.Parameters.AddWithValue("@NbrLikeMpost", entity.NbrLikeMpost);
            entity.Id = Convert.ToInt32(Commande.ExecuteScalar());

            
            FermerConnexion();
            return entity;
        }

        
        public override Stats_DAL GetById(int id)
        {
            OuvrirConnexion();
            
            Stats_DAL stats = null;
            
            Commande.CommandText = "SELECT id, dateDebut, dateFin, NbrCreaCmpt, NbrConnCmpt,NbrCreaPost,NbrCommMpost, NbrVueMpost, NbrLikeMpost FROM stats WHERE Id = @id";
            Commande.Parameters.AddWithValue("@id", id);
            var reader = Commande.ExecuteReader();
            if (reader.Read())
                stats = new Stats_DAL(id, reader.GetDateTime(1), reader.GetDateTime(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8));
            
            reader.Close();
            reader.Dispose();
            
            FermerConnexion();
            
            return stats;
        }

        public override IEnumerable<Stats_DAL> GetAll()
        {
            OuvrirConnexion();

            List<Stats_DAL> StatCompte = new List<Stats_DAL>();
            
            Commande.CommandText = "SELECT * FROM Stats";
            var reader = Commande.ExecuteReader();
            while (reader.Read())
                StatCompte.Add(new Stats_DAL(reader.GetInt32(0), reader.GetDateTime(1), reader.GetDateTime(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8)));
            
            
            reader.Close();
            reader.Dispose();
            
            FermerConnexion();
            return StatCompte;
        }
        
        public override Stats_DAL GetBetweenDates(DateTime dateDebut, DateTime dateFin)
        {
            OuvrirConnexion();
            
            Stats_DAL stats = null;
            
            Commande.CommandText = "SELECT id, dateDebut, dateFin, NbrCreaCmpt, NbrConnCmpt, NbrCreaPost,NbrCommMpost, NbrVueMpost, NbrLikeMpost FROM Stats WHERE dateDebut = @dateDebut AND dateFin = @dateFin";
            Commande.Parameters.AddWithValue("@dateDebut", dateDebut);
            Commande.Parameters.AddWithValue("@dateFin", dateFin);
            var reader = Commande.ExecuteReader();
            if (reader.Read())
                stats = new Stats_DAL(reader.GetInt32(0), reader.GetDateTime(1), reader.GetDateTime(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8));
            
            reader.Close();
            reader.Dispose();
            
            FermerConnexion();
            
            return stats;
        }
        
        // fonction pour supprimer une stats dans la base de données avec comme paramètre l'id de la stats
        public void DeleteStats(int id)
        {
            OuvrirConnexion();
            
            // on supprime dabord dans les tables qui ont une clé étrangère avec la table Stats
            Commande.CommandText = "DELETE FROM StatPost WHERE id_Stats = @id";
            Commande.Parameters.AddWithValue("@id", id);
            Commande.ExecuteNonQuery();
            
            Commande.CommandText = "DELETE FROM StatVille WHERE id_Stats = @id";
           
            Commande.ExecuteNonQuery();
            
            Commande.CommandText = "DELETE FROM StatCompte WHERE id_Stats = @id";
          
            Commande.ExecuteNonQuery();
            
            
            Commande.CommandText = "DELETE FROM Stats WHERE Id = @id";
          
            Commande.ExecuteNonQuery();
            
            
            FermerConnexion();
            
        }
        
        
    }
}
