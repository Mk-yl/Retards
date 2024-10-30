using System;


namespace Retards.DTO;

public class Stats_DTO
{
    public int Id { get; set; }
    public DateTime DateDebut { get; set; }
    public DateTime DateFin { get; set; }
        
    // Nombre de creations de comptes
    public int NbrCreaCmpt { get; set; }
    
    // Nombre de connection de comptes
    public int NbrConnCmpt { get; set; }
    
    // Nombre  de creation de posts
    public int NbrCreaPost { get; set; }
    
    // Nombre de commentaires Moyen postés
    public int NbrCommMpost { get; set; }
        
    // Nombre de vue Moyen postés
    public int NbrVueMpost { get; set; }
        
    // Nombre de like Moyen postés
    public int NbrLikeMpost { get; set; }
    
    // Liste des posts
    public List<Stat_Compte_DTO> ComptesPostantLePlus { get; set; }
    
    // Liste des commentaires
    public List<Stat_Compte_DTO> ComptesCommentantLePlus { get; set; }
    
    
    // Liste des villes
    public List<Stat_Ville_DTO> VillesActives { get; set; }
    
    // Liste des posts les plus likés
    public List<Stat_Post_DTO> PostsLesPlusLikes { get; set; }
    
    // Liste des posts les plus Superlikés
    public List<Stat_Post_DTO> PostsLesPlusSuperlikes { get; set; }
    
    // Liste des posts les plus commentés
    public List<Stat_Post_DTO> PostsLesPlusCommentes { get; set; }
    
    // Liste des posts les plus vus
    public List<Stat_Post_DTO> PostsLesPlusVus { get; set; }
    
    
    
}




