namespace Retards.DAL.BDD;

public class Stat_Post_DAL_Depot : Depot_DAL<Stat_Post_DAL>
{
    private string type;
    
    public Stat_Post_DAL_Depot(string t)
    {
        type = t;
        
    }
    
    public override Stat_Post_DAL Insert(Stat_Post_DAL entity)
    { 
        OuvrirConnexion();
        
        Commande.CommandText = "INSERT INTO StatPost (id_Stats, titre, nombreCommentaires, nombreVues, nombreLikes, nombreSuperlikes, dateCreation, pseudoAuteur, type) VALUES (@id_Stats, @titre, @nombreCommentaires, @nombreVues, @nombreLikes, @nombreSuperlikes, @dateCreation, @pseudoAuteur , @type); SELECT SCOPE_IDENTITY()";
        Commande.Parameters.AddWithValue("@id_Stats", entity.IdStats);
        Commande.Parameters.AddWithValue("@titre", entity.Titre);
        Commande.Parameters.AddWithValue("@nombreCommentaires", entity.NombreCommentaires);
        Commande.Parameters.AddWithValue("@nombreVues", entity.NombreVues);
        Commande.Parameters.AddWithValue("@nombreLikes", entity.NombreLikes);
        Commande.Parameters.AddWithValue("@nombreSuperlikes", entity.NombreSuperlikes);
        Commande.Parameters.AddWithValue("@dateCreation", entity.DateCreation);
        Commande.Parameters.AddWithValue("@pseudoAuteur", entity.PseudoAuteur);
        Commande.Parameters.AddWithValue("@type", type);
        
        entity.Id = Convert.ToInt32(Commande.ExecuteScalar());
        
        FermerConnexion();
        
        return entity;
    }

    public override Stat_Post_DAL? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Stat_Post_DAL> GetAll()
    {
        throw new NotImplementedException();
        
    }

    public override Stat_Post_DAL GetBetweenDates(DateTime dateDebut, DateTime dateFin)
    {
        throw new NotImplementedException();
    }
    
    public IEnumerable<Stat_Post_DAL> GetStatPostByid (int id)
    {
        OuvrirConnexion();
        
        List<Stat_Post_DAL> statPost = new List<Stat_Post_DAL>();
        
        Commande.CommandText = "SELECT id, id_Stats, titre, nombreCommentaires, nombreVues, nombreLikes, nombreSuperlikes, dateCreation, pseudoAuteur FROM StatPost WHERE id_Stats = @id AND type = @type";
        Commande.Parameters.AddWithValue("@id", id);
        Commande.Parameters.AddWithValue("@type", type);
        var reader = Commande.ExecuteReader();
        while (reader.Read())
            statPost.Add(new Stat_Post_DAL(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetDateTime(7), reader.GetString(8)));
        
        reader.Close();
        reader.Dispose();
        
        FermerConnexion();
        
        return statPost;
    }
    
}