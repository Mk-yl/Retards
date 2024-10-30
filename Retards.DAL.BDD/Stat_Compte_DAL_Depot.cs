namespace Retards.DAL.BDD;

public  class Stat_Compte_DAL_Depot : Depot_DAL<Stat_Compte_DAL> 
{
    private string type;

    public Stat_Compte_DAL_Depot(string t)
    {
        type = t;
        
    }
    
    
    public override Stat_Compte_DAL Insert(Stat_Compte_DAL entity)
    {
        OuvrirConnexion();
        Commande.CommandText = "INSERT INTO StatCompte (id_Stats, pseudo, nombrePosts, nombreCommentaires, type) VALUES (@id_Stats, @pseudo, @nombrePosts, @nombreCommentaires, @type); SELECT SCOPE_IDENTITY()";
        Commande.Parameters.AddWithValue("@id_Stats", entity.IdStats);
        Commande.Parameters.AddWithValue("@pseudo", entity.Pseudo);
        Commande.Parameters.AddWithValue("@nombrePosts", entity.NombrePosts);
        Commande.Parameters.AddWithValue("@nombreCommentaires", entity.NombreCommentaires);
        Commande.Parameters.AddWithValue("@type", type);

        entity.Id = Convert.ToInt32(Commande.ExecuteScalar());
        FermerConnexion();
        return entity;
    }


    public override Stat_Compte_DAL? GetById(int id)
    {
        OuvrirConnexion();
        
        Stat_Compte_DAL StatCompte = null;
        
        Commande.CommandText = "SELECT id, id_Stats, pseudo, nombrePosts, nombreCommentaires FROM StatCompte WHERE Id = @id";
        Commande.Parameters.AddWithValue("@id", id);
        var reader = Commande.ExecuteReader();
        if (reader.Read())
            StatCompte = new Stat_Compte_DAL(id, reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4));
            
        reader.Close();
        reader.Dispose();
            
        FermerConnexion();
            
        return StatCompte;
        
        
    }

    public override IEnumerable<Stat_Compte_DAL> GetAll()
    {
        OuvrirConnexion();
        
        List<Stat_Compte_DAL> statCompte = new List<Stat_Compte_DAL>();
        
        Commande.CommandText = "SELECT * FROM StatCompte WHERE type = 'Post'";
        var reader = Commande.ExecuteReader();
        while (reader.Read())
            statCompte.Add(new Stat_Compte_DAL(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4)));
        
        reader.Close();
        reader.Dispose();
        
        FermerConnexion();
        
        return statCompte;
        
    }

    public override Stat_Compte_DAL GetBetweenDates(DateTime dateDebut, DateTime dateFin)
    {
        throw new NotImplementedException();

    }
    
    // fonction qui retoure la liste de posts avec comme parametre id
    
    public  IEnumerable<Stat_Compte_DAL> GetstatCompteById(int id)
    {
        OuvrirConnexion();
        
        List<Stat_Compte_DAL> StatCompte = new List<Stat_Compte_DAL>();
        
        Commande.CommandText = "SELECT id, id_Stats, pseudo, nombrePosts, nombreCommentaires FROM StatCompte WHERE id_Stats = @id and type = @type";
        Commande.Parameters.AddWithValue("@id", id);
        Commande.Parameters.AddWithValue("@type",type );
        var reader = Commande.ExecuteReader();
        while (reader.Read())
            StatCompte.Add(new Stat_Compte_DAL(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4)));
        
        reader.Close();
        reader.Dispose();
        
        FermerConnexion();
        
        return StatCompte;
        
    }
}