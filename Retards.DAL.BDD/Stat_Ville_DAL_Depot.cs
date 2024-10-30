namespace Retards.DAL.BDD;

public class Stat_Ville_DAL_Depot : Depot_DAL<Stat_Ville_DAL>
{
    public override Stat_Ville_DAL Insert(Stat_Ville_DAL entity)
    {
        OuvrirConnexion();
        Commande.CommandText = "INSERT INTO StatVille (id_Stats, nom, nombrePosts, nombreCommentaires, nombreVues, nombreLikes) VALUES (@id_Stats, @nom, @nombrePosts, @nombreCommentaires, @nombreVues, @nombreLikes); SELECT SCOPE_IDENTITY()";
        Commande.Parameters.AddWithValue("@id_Stats", entity.IdStats);
        Commande.Parameters.AddWithValue("@nom", entity.Nom);
        Commande.Parameters.AddWithValue("@nombrePosts", entity.NombrePosts);
        Commande.Parameters.AddWithValue("@nombreCommentaires", entity.NombreCommentaires);
        Commande.Parameters.AddWithValue("@nombreVues", entity.NombreVues);
        Commande.Parameters.AddWithValue("@nombreLikes", entity.NombreLikes);
        
        entity.Id = Convert.ToInt32(Commande.ExecuteScalar());
        FermerConnexion();
        return entity;
    
    }

    public override Stat_Ville_DAL? GetById(int id)
    {
        OuvrirConnexion();
        
       Stat_Ville_DAL StatVille = null;
        
        Commande.CommandText = "SELECT id, id_Stats, nom, nombrePosts, nombreCommentaires, nombreVues, nombreLikes FROM StatVille WHERE Id = @id";
        Commande.Parameters.AddWithValue("@id", id);
        var reader = Commande.ExecuteReader();
         if (reader.Read())
            StatVille = new Stat_Ville_DAL(id, reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6));
        
         reader.Close();
        reader.Dispose();
        
        FermerConnexion();
        
        return StatVille;
        
    }

    public override IEnumerable<Stat_Ville_DAL> GetAll()
    {
        OuvrirConnexion();
        
        List<Stat_Ville_DAL> StatVille = new List<Stat_Ville_DAL>();
        
        Commande.CommandText = "SELECT * FROM StatVille";
        var reader = Commande.ExecuteReader();
        while (reader.Read())
            StatVille.Add(new Stat_Ville_DAL(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6)));
        
        reader.Close();
        reader.Dispose();
        
        FermerConnexion();
        
        return StatVille;
    }

    public override Stat_Ville_DAL GetBetweenDates(DateTime dateDebut, DateTime dateFin)
    {
        throw new NotImplementedException();
    }
    
    public  IEnumerable<Stat_Ville_DAL> GetVilleByID(int id)
    {
        OuvrirConnexion();
        
        List<Stat_Ville_DAL> StatVille = new List<Stat_Ville_DAL>();
        
        Commande.CommandText = "SELECT * FROM StatVille WHERE id_Stats = @id";
        Commande.Parameters.AddWithValue("@id", id);
        var reader = Commande.ExecuteReader();
        while (reader.Read())
            StatVille.Add(new Stat_Ville_DAL(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6)));
        
        reader.Close();
        reader.Dispose();
        
        FermerConnexion();
        
        return StatVille;
    }
}
