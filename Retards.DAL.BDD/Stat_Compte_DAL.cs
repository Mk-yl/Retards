namespace Retards.DAL.BDD;

public class Stat_Compte_DAL
{
    public int Id { get; set; }
    public int IdStats { get; set; } // cle etrangere de la liaison avec la table Stats
    public string Pseudo { get; set; }
    public int NombrePosts { get; set; }
    public int NombreCommentaires { get; set; }
    
    
    
    //constructeur sans Id
    public Stat_Compte_DAL(int idStats, string pseudo, int nombrePosts, int nombreCommentaires)
    {
        IdStats = idStats;
        Pseudo = pseudo;
        NombrePosts = nombrePosts;
        NombreCommentaires = nombreCommentaires;
    }
    
    
    
    
    //constructeur avec Id
    public Stat_Compte_DAL(int id, int idStats, string pseudo, int nombrePosts, int nombreCommentaires)
        : this(idStats, pseudo, nombrePosts, nombreCommentaires)
    {
        Id = id;
    }
    
    
}