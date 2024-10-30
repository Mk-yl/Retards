namespace Retards.DAL.BDD;


    public class Stats_DAL
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
        
        
        

        
        /// <summary>
        /// Constructeur sans Id
        /// </summary>
        /// <param name="dateDebut"></param>
        /// <param name="dateFin"></param>
        /// <param name="nbrCreaCmpt"></param>
        
        public Stats_DAL(DateTime dateDebut, DateTime dateFin, int nbrCreaCmpt, int nbrConnCmpt, int nbrCreaPost , int nbrCommMpost, int nbrVueMpost, int nbrLikeMpost)
        {
            DateDebut = dateDebut;
            DateFin = dateFin;
            NbrCreaCmpt = nbrCreaCmpt;
            NbrConnCmpt = nbrConnCmpt;
            NbrCreaPost = nbrCreaPost;
            NbrCommMpost = nbrCommMpost;
            NbrVueMpost = nbrVueMpost;
            NbrLikeMpost = nbrLikeMpost;
        }
        
       
        /// <summary>
        ///  Constructeur avec Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dateDebut"></param>
        /// <param name="dateFin"></param>
        /// <param name="nbrCreaCmpt"></param>
        public Stats_DAL(int id, DateTime dateDebut, DateTime dateFin, int nbrCreaCmpt, int nbrConnCmpt,int nbrCreaPost,int nbrCommMpost, int nbrVueMpost, int nbrLikeMpost)
            : this(dateDebut, dateFin, nbrCreaCmpt, nbrConnCmpt, nbrCreaPost, nbrCommMpost, nbrVueMpost, nbrLikeMpost)
        {
            Id = id;
        }

       
    }

    
