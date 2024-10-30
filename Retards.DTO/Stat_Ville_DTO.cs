namespace Retards.DTO;

public class Stat_Ville_DTO
{
    public int Id { get; set; }
    public int IdStats { get; set; } // cle etrangere de la liaison avec la table Stat_Compte
    public string Nom { get; set; }
    
    public int NombrePosts { get; set; }
    
    public int NombreCommentaires { get; set; }
    
    public int NombreVues { get; set; }
    
    public int NombreLikes { get; set; }
    
    
    
}