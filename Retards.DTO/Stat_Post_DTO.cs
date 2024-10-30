namespace Retards.DTO;

public class Stat_Post_DTO
{
    public int Id {get; set;}
    public int IdStats {get; set;} // cle etrangere de la liaison avec la table Stats
    public string Titre {get; set;}
    public int NombreCommentaires {get; set;}
    public int NombreVues {get; set;}
    public int NombreLikes {get; set;}
    public int NombreSuperlikes {get; set;}
    public DateTime DateCreation {get; set;}
    public string PseudoAuteur {get; set;}
    
}