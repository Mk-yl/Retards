using System;
using Retards.DAL.BDD;
using Retards.DAL.API;
using Retards.DTO;


namespace Retards.BLL
{
    public class Stats_Depot : IStats_Depot <Stats_BLL>
    {
        
        private Stats_DAL_Depot _statsDal;
        
        
        public Stats_Depot(Stats_DAL_Depot statsDal)
        {
           this._statsDal = statsDal;
        }
        
        
        public Stats_Depot()
        :this(new Stats_DAL_Depot())
        {
            _statsDal = new Stats_DAL_Depot();
            _apiClient = new Client();
            _statComptePostantleplus = new Stat_Compte_DAL_Depot("Post");
            _statCompteCommentantleplus = new Stat_Compte_DAL_Depot("Commentaire");
            _statVilleDal = new Stat_Ville_DAL_Depot();
            
            _postesPlusLikes = new Stat_Post_DAL_Depot("Likes");
            _postesPlusSuperlikes = new Stat_Post_DAL_Depot("Superlikes");
            _postesPlusCommentes = new Stat_Post_DAL_Depot("Commentaires");
            _postesPlusVus = new Stat_Post_DAL_Depot("Vues"); 
        }
      
        
        
        private readonly Client _apiClient;
        private readonly Stat_Compte_DAL_Depot _statComptePostantleplus;
        private readonly Stat_Compte_DAL_Depot _statCompteCommentantleplus;
        private readonly Stat_Ville_DAL_Depot _statVilleDal;
        private readonly Stat_Post_DAL_Depot _postesPlusLikes;
        private readonly Stat_Post_DAL_Depot _postesPlusSuperlikes;
        private readonly Stat_Post_DAL_Depot _postesPlusCommentes;
        private readonly Stat_Post_DAL_Depot _postesPlusVus;
        

        public Stats_BLL GetStatBetweenDates(DateTime dateDebut, DateTime dateFin)
        {
            Stats_DAL stats = _statsDal.GetBetweenDates(dateDebut, dateFin);

            // récupère les stats des posts dans la base de données

            if (stats != null)
            {
                IEnumerable<Stat_Compte_DAL> statPost = _statComptePostantleplus.GetstatCompteById(stats.Id);

                IEnumerable<Stat_Compte_DAL> statCommentaires = _statCompteCommentantleplus.GetstatCompteById(stats.Id);
                
                IEnumerable<Stat_Ville_DAL> statVille = _statVilleDal.GetVilleByID(stats.Id);
                
                IEnumerable<Stat_Post_DAL> statPostLikes = _postesPlusLikes.GetStatPostByid(stats.Id);
                
                IEnumerable<Stat_Post_DAL> statPostSuperlikes = _postesPlusSuperlikes.GetStatPostByid(stats.Id);
                
                IEnumerable<Stat_Post_DAL> statPostCommentes = _postesPlusCommentes.GetStatPostByid(stats.Id);
                
                IEnumerable<Stat_Post_DAL> statPostVus = _postesPlusVus.GetStatPostByid(stats.Id);
                


                if (statPost != null)
                    return new Stats_BLL(stats.Id, stats.DateDebut, stats.DateFin,
                        stats.NbrCreaCmpt, stats.NbrConnCmpt, stats.NbrCreaPost, stats.NbrCommMpost,
                        stats.NbrVueMpost, stats.NbrLikeMpost,
                        new List<Stat_Compte_BLL>(statPost.Select(x =>
                                new Stat_Compte_BLL(x.Id, x.IdStats, x.Pseudo, x.NombrePosts, x.NombreCommentaires))
                            .ToList()),
                        new List<Stat_Compte_BLL>(statCommentaires.Select(x =>
                                new Stat_Compte_BLL(x.Id, x.IdStats, x.Pseudo, x.NombrePosts, x.NombreCommentaires))
                            .ToList()),
                        new List<Stat_Ville_BLL>(statVille.Select(x =>
                                new Stat_Ville_BLL(x.Id, x.IdStats, x.Nom, x.NombrePosts, x.NombreCommentaires,
                                    x.NombreVues, x.NombreLikes)).ToList()),
                        new List<Stat_Post_BLL>( statPostLikes.Select(x =>
                                new Stat_Post_BLL(x.Id, x.IdStats, x.Titre, x.NombreCommentaires, x.NombreVues,
                                    x.NombreLikes, x.NombreSuperlikes, x.DateCreation, x.PseudoAuteur)).ToList()),
                        new List<Stat_Post_BLL>(statPostSuperlikes.Select(x =>
                                new Stat_Post_BLL(x.Id, x.IdStats, x.Titre, x.NombreCommentaires, x.NombreVues,
                                    x.NombreLikes, x.NombreSuperlikes, x.DateCreation, x.PseudoAuteur)).ToList()),
                        new List<Stat_Post_BLL>(statPostCommentes.Select(x =>
                                new Stat_Post_BLL(x.Id, x.IdStats, x.Titre, x.NombreCommentaires, x.NombreVues,
                                    x.NombreLikes, x.NombreSuperlikes, x.DateCreation, x.PseudoAuteur)).ToList()),
                        new List<Stat_Post_BLL>(statPostVus.Select(x =>
                                new Stat_Post_BLL(x.Id, x.IdStats, x.Titre, x.NombreCommentaires, x.NombreVues,
                                    x.NombreLikes, x.NombreSuperlikes, x.DateCreation, x.PseudoAuteur)).ToList())
                        );
            }
            else
            {
                var nombreCreations = _apiClient.GetNombreCreationsCompte(new Periode_DTO
                    { DateDebut = dateDebut, DateFin = dateFin });
                var nombreConnexions = _apiClient.GetNombreConnexionsCompte(new Periode_DTO
                    { DateDebut = dateDebut, DateFin = dateFin });
                var nbrCreaPost = _apiClient.GetNombreCreationsPost(new Periode_DTO
                    { DateDebut = dateDebut, DateFin = dateFin });
                var nbrCommMpost = _apiClient.GetNombreCommentairesMoyenParPost(new Periode_DTO
                    { DateDebut = dateDebut, DateFin = dateFin });
                var nbrVueMpost = _apiClient.GetNombreVuesMoyenParPost(new Periode_DTO
                    { DateDebut = dateDebut, DateFin = dateFin });
                var nbrLikeMpost = _apiClient.GetNombreLikesMoyenParPost(new Periode_DTO
                    { DateDebut = dateDebut, DateFin = dateFin });


                Stats_DAL newData = new Stats_DAL(dateDebut, dateFin, nombreCreations, nombreConnexions,
                    nbrCreaPost, nbrCommMpost, nbrVueMpost, nbrLikeMpost);
                _statsDal.Insert(newData);

                int idInserer = newData.Id;

                var statPostantLePlusAPi = _apiClient
                    .GetComptesPostantLePlusAsync(new Periode_DTO { DateDebut = dateDebut, DateFin = dateFin }).Result;

                var statcommentairesPostantLePlusAPi = _apiClient
                    .GetComptesCommentantLePlusAsync(new Periode_DTO { DateDebut = dateDebut, DateFin = dateFin }).Result;
                
                var villesActives = _apiClient
                    .GetVillesActivesAsync(new Periode_DTO { DateDebut = dateDebut, DateFin = dateFin }).Result;
                
                var postesPlusLikes = _apiClient
                    .GetPostsLesPlusLikesAsync(new Periode_DTO { DateDebut = dateDebut, DateFin = dateFin }).Result;
                
                var postesPlusSuperlikes = _apiClient
                    .GetPostsLesPlusSuperLikesAsync(new Periode_DTO { DateDebut = dateDebut, DateFin = dateFin }).Result;

                var postesPlusCommentes = _apiClient
                    .GetPostsLesPlusCommentesAsync(new Periode_DTO { DateDebut = dateDebut, DateFin = dateFin }).Result;
                
                var postesPlusVus = _apiClient
                    .GetPostsLesPlusVusAsync(new Periode_DTO { DateDebut = dateDebut, DateFin = dateFin }).Result;

                foreach (var item in statPostantLePlusAPi)
                {
                    _statComptePostantleplus.Insert(new Stat_Compte_DAL(idInserer, item.Pseudo, item.NombrePosts,
                        item.NombreCommentaires));
                }

                foreach (var item in statcommentairesPostantLePlusAPi)
                {
                    _statCompteCommentantleplus.Insert(new Stat_Compte_DAL(idInserer, item.Pseudo, item.NombrePosts,
                        item.NombreCommentaires));
                }
                
                foreach (var item in villesActives)
                {
                    _statVilleDal.Insert(new Stat_Ville_DAL(idInserer, item.Nom, item.NombrePosts,
                        item.NombreCommentaires, item.NombreVues, item.NombreLikes));
                }
                
                foreach (var item in postesPlusLikes)
                {
                    _postesPlusLikes.Insert(new Stat_Post_DAL(idInserer, item.Titre, item.NombreCommentaires,
                        item.NombreVues, item.NombreLikes, item.NombreSuperLikes, item.DateCreation, item.PseudoAuteur));
                }
                
                foreach (var item in postesPlusSuperlikes)
                {
                    _postesPlusSuperlikes.Insert(new Stat_Post_DAL(idInserer, item.Titre, item.NombreCommentaires,
                        item.NombreVues, item.NombreLikes, item.NombreSuperLikes, item.DateCreation, item.PseudoAuteur));
                }
                
                foreach (var item in postesPlusCommentes)
                {
                    _postesPlusCommentes.Insert(new Stat_Post_DAL(idInserer, item.Titre, item.NombreCommentaires,
                        item.NombreVues, item.NombreLikes, item.NombreSuperLikes, item.DateCreation, item.PseudoAuteur));
                }
                
                foreach (var item in postesPlusVus)
                {
                    _postesPlusVus.Insert(new Stat_Post_DAL(idInserer, item.Titre, item.NombreCommentaires,
                        item.NombreVues, item.NombreLikes, item.NombreSuperLikes, item.DateCreation, item.PseudoAuteur));
                }


                return new Stats_BLL(idInserer, dateDebut, dateFin, nombreCreations, nombreConnexions, nbrCreaPost,
                    nbrCommMpost, nbrVueMpost, nbrLikeMpost,
                    statPostantLePlusAPi.Select(x =>
                            new Stat_Compte_BLL(idInserer, x.Pseudo, x.NombrePosts, x.NombreCommentaires))
                        .ToList(),
                    statcommentairesPostantLePlusAPi.Select(x =>
                            new Stat_Compte_BLL(idInserer, x.Pseudo, x.NombrePosts, x.NombreCommentaires))
                        .ToList(),
                    villesActives.Select(x =>
                            new Stat_Ville_BLL(idInserer, x.Nom, x.NombrePosts, x.NombreCommentaires, x.NombreVues,
                                x.NombreLikes)).ToList(),
                    postesPlusLikes.Select(x => 
                            new Stat_Post_BLL(idInserer, x.Titre, x.NombreCommentaires, x.NombreVues, x.NombreLikes,
                                x.NombreSuperLikes, x.DateCreation, x.PseudoAuteur)).ToList(),
                    postesPlusSuperlikes.Select(x =>
                            new Stat_Post_BLL(idInserer, x.Titre, x.NombreCommentaires, x.NombreVues, x.NombreLikes,
                                x.NombreSuperLikes, x.DateCreation, x.PseudoAuteur)).ToList(),
                    postesPlusCommentes.Select(x =>
                            new Stat_Post_BLL(idInserer, x.Titre, x.NombreCommentaires, x.NombreVues, x.NombreLikes,
                                x.NombreSuperLikes, x.DateCreation, x.PseudoAuteur)).ToList(),
                    postesPlusVus.Select(x =>
                            new Stat_Post_BLL(idInserer, x.Titre, x.NombreCommentaires, x.NombreVues, x.NombreLikes,
                                x.NombreSuperLikes, x.DateCreation, x.PseudoAuteur)).ToList()
                );
            }

            // Ajout de la déclaration de retour par défaut
            return null;
        }

        public IEnumerable<Stats_BLL> GetAll()
        {
            List<Stats_DAL> Stats = _statsDal.GetAll().ToList();
            
            List<Stats_BLL> stats = new List<Stats_BLL>();
            
            foreach (var item in Stats)
            {
                IEnumerable<Stat_Compte_DAL> statPost = _statComptePostantleplus.GetstatCompteById(item.Id);

                IEnumerable<Stat_Compte_DAL> statCommentaires = _statCompteCommentantleplus.GetstatCompteById(item.Id);
                
                IEnumerable<Stat_Ville_DAL> statVille = _statVilleDal.GetVilleByID(item.Id);
                
                IEnumerable<Stat_Post_DAL> statPostPlusLikes = _postesPlusLikes.GetStatPostByid(item.Id);
                
                IEnumerable<Stat_Post_DAL> statPostSuperlikes = _postesPlusSuperlikes.GetStatPostByid(item.Id);
                
                IEnumerable<Stat_Post_DAL> statPostCommentes = _postesPlusCommentes.GetStatPostByid(item.Id);
                
                IEnumerable<Stat_Post_DAL> statPostVus = _postesPlusVus.GetStatPostByid(item.Id);
                

                stats.Add(new Stats_BLL(item.Id, item.DateDebut, item.DateFin,
                    item.NbrCreaCmpt, item.NbrConnCmpt, item.NbrCreaPost, item.NbrCommMpost,
                    item.NbrVueMpost, item.NbrLikeMpost,
                    new List<Stat_Compte_BLL>(statPost.Select(x =>
                            new Stat_Compte_BLL(x.Id, x.IdStats, x.Pseudo, x.NombrePosts, x.NombreCommentaires))
                        .ToList()),
                    new List<Stat_Compte_BLL>(statCommentaires.Select(x =>
                            new Stat_Compte_BLL(x.Id, x.IdStats, x.Pseudo, x.NombrePosts, x.NombreCommentaires))
                        .ToList()),
                    new List<Stat_Ville_BLL>(statVille.Select(x =>
                            new Stat_Ville_BLL(x.Id, x.IdStats, x.Nom, x.NombrePosts, x.NombreCommentaires,
                                x.NombreVues, x.NombreLikes)).ToList()),
                    new List<Stat_Post_BLL>(statPostPlusLikes.Select(x =>
                            new Stat_Post_BLL(x.Id, x.IdStats, x.Titre, x.NombreCommentaires, x.NombreVues,
                                x.NombreLikes, x.NombreSuperlikes, x.DateCreation, x.PseudoAuteur)).ToList()),
                    new List<Stat_Post_BLL>(statPostSuperlikes.Select(x =>
                            new Stat_Post_BLL(x.Id, x.IdStats, x.Titre, x.NombreCommentaires, x.NombreVues,
                                x.NombreLikes, x.NombreSuperlikes, x.DateCreation, x.PseudoAuteur)).ToList()),
                    new List<Stat_Post_BLL>(statPostCommentes.Select(x =>
                            new Stat_Post_BLL(x.Id, x.IdStats, x.Titre, x.NombreCommentaires, x.NombreVues,
                                x.NombreLikes, x.NombreSuperlikes, x.DateCreation, x.PseudoAuteur)).ToList()),
                    new List<Stat_Post_BLL>(statPostVus.Select(x =>
                            new Stat_Post_BLL(x.Id, x.IdStats, x.Titre, x.NombreCommentaires, x.NombreVues,
                                x.NombreLikes, x.NombreSuperlikes, x.DateCreation, x.PseudoAuteur)).ToList())
                    
                ));
            }

            return stats;
        }
        
        //methode pour supprimer une statistique
        public void Delete(int id)
        {
            _statsDal.DeleteStats(id);
        }
    }
}