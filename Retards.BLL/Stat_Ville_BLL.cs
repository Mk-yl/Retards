namespace Retards.BLL;

public class Stat_Ville_BLL
{
  public  int Id { get; set; }
   public int IdStats { get; set; } // cle etrangere de la liaison avec la table Stat_Compte
    public string Nom { get; set; }
  public  int NombrePosts { get; set; }
   public int NombreCommentaires { get; set; }
   public int NombreVues { get; set; }
   public int NombreLikes { get; set; }
    
    //constructeur sans Id
    public Stat_Ville_BLL(int idStats, string nom, int nombrePosts, int nombreCommentaires, int nombreVues, int nombreLikes)
    {
        IdStats = idStats;
        Nom = nom;
        NombrePosts = nombrePosts;
        NombreCommentaires = nombreCommentaires;
        NombreVues = nombreVues;
        NombreLikes = nombreLikes;
    }
    
    //constructeur avec Id
    
    public Stat_Ville_BLL(int id, int idStats, string nom, int nombrePosts, int nombreCommentaires, int nombreVues, int nombreLikes)
        : this(idStats, nom, nombrePosts, nombreCommentaires, nombreVues, nombreLikes)
    {
        Id = id;
    }
}