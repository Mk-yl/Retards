using Retards.DAL.BDD;

namespace Retards.BLL;

public class Stats_BLL
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
    
    
    // Liste des statistiques des comptes
    public List<Stat_Compte_BLL> ComptePostantPLus { get; set; }
    
    public List<Stat_Compte_BLL> CompteCommentantPLus { get; set; }
    
    // liste des statistiques des  villes
    public List<Stat_Ville_BLL> VilleActives { get; set; }
    
    // liste des postes les plus likés
    public List<Stat_Post_BLL> PostesPlusLikes { get; set; }
    
    // liste des postes les plus Superlikés
    public List<Stat_Post_BLL> PostesPlusSuperlikes { get; set; }
    
    // liste des postes les plus commentés
    public List<Stat_Post_BLL> PostesPlusCommentes { get; set; }
    
    // liste des postes les plus vus
    public List<Stat_Post_BLL> PostesPlusVus { get; set; }
    
    
    // constructeur sans Id
    public Stats_BLL(DateTime dateDebut, DateTime dateFin, int nbrCreaCmpt,int nbrConnCmpt,int nbrCreaPost,  int nbrCommMpost, int nbrVueMpost, int nbrLikeMpost , List<Stat_Compte_BLL> comptePostantPLus , List<Stat_Compte_BLL> compteCommentantPLus, List<Stat_Ville_BLL> villeActives, List<Stat_Post_BLL> postesPlusLikes, List<Stat_Post_BLL> postesPlusSuperlikes, List<Stat_Post_BLL> postesPlusCommentes, List<Stat_Post_BLL> postesPlusVus)
    {
        DateDebut = dateDebut;
        DateFin = dateFin;
        NbrCreaCmpt = nbrCreaCmpt;
        NbrConnCmpt = nbrConnCmpt;
        NbrCreaPost = nbrCreaPost;
        NbrCommMpost = nbrCommMpost;
        NbrVueMpost = nbrVueMpost;
        NbrLikeMpost = nbrLikeMpost;
        ComptePostantPLus = comptePostantPLus;
        CompteCommentantPLus = compteCommentantPLus;
        VilleActives = villeActives;
        PostesPlusLikes = postesPlusLikes;
        PostesPlusSuperlikes = postesPlusSuperlikes;
        PostesPlusCommentes = postesPlusCommentes;
        PostesPlusVus = postesPlusVus;
    }
  
   
    
    // constructeur avec Id
    public Stats_BLL(int id, DateTime dateDebut, DateTime dateFin, int nbrCreaCmpt, int nbrConnCmpt, int nbrCreaPost,  int nbrCommMpost, int nbrVueMpost, int nbrLikeMpost, List<Stat_Compte_BLL> comptePostantPLus , List<Stat_Compte_BLL> compteCommentantPLus, List<Stat_Ville_BLL> villeActives, List<Stat_Post_BLL> postesPlusLikes, List<Stat_Post_BLL> postesPlusSuperlikes, List<Stat_Post_BLL> postesPlusCommentes, List<Stat_Post_BLL> postesPlusVus)
        : this(dateDebut, dateFin, nbrCreaCmpt, nbrConnCmpt,nbrCreaPost , nbrCommMpost, nbrVueMpost, nbrLikeMpost,comptePostantPLus, compteCommentantPLus, villeActives, postesPlusLikes, postesPlusSuperlikes, postesPlusCommentes, postesPlusVus)
    {
        Id = id;
    }
    
}