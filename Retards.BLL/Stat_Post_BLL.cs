namespace Retards.BLL;

public class Stat_Post_BLL
{
    public int Id { get; set; }
    public int IdStats { get; set; } // cle etrangere de la liaison avec la table Stats
    public string Titre { get; set; }
    public int NombreCommentaires { get; set; }
    public int NombreVues { get; set; }
    public int NombreLikes { get; set; }
    public int NombreSuperlikes { get; set; }
    public DateTime DateCreation { get; set; }
    public string PseudoAuteur { get; set; }
    
    //constructeur sans Id
    public Stat_Post_BLL(int idStats, string titre, int nombreCommentaires, int nombreVues, int nombreLikes,
        int nombreSuperlikes, DateTime dateCreation, string pseudoAuteur)
    {
        IdStats = idStats;
        Titre = titre;
        NombreCommentaires = nombreCommentaires;
        NombreVues = nombreVues;
        NombreLikes = nombreLikes;
        NombreSuperlikes = nombreSuperlikes;
        DateCreation = dateCreation;
        PseudoAuteur = pseudoAuteur;
    }
    
    //constructeur avec Id
    public Stat_Post_BLL(int id, int idStats, string titre, int nombreCommentaires, int nombreVues, int nombreLikes,
        int nombreSuperlikes, DateTime dateCreation, string pseudoAuteur)
        : this(idStats, titre, nombreCommentaires, nombreVues, nombreLikes, nombreSuperlikes, dateCreation, pseudoAuteur)
    {
        Id = id;
    }
}