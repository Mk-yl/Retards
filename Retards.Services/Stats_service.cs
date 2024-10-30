using System;
using System.Collections.Generic;
using Retards.BLL;
using Retards.DAL.BDD;
using Retards.DTO;



namespace Retards.Services
{
    public class Stats_service : IStats_service <Stats_DTO>
    {
        private  IStats_Depot<Stats_BLL> depot;
        
        
        public Stats_service()
            :this(new Stats_Depot())
        {
            
        }
        
        public Stats_service(IStats_Depot<Stats_BLL> depot)
        {
            this.depot = depot;
        }
        
        

        public Stats_DTO GetStatCompteDto(DateTime dateDebut, DateTime dateFin)
        {
            var statCompte = depot.GetStatBetweenDates(dateDebut, dateFin);
            var ComptesPostantLePlus = new List<Stat_Compte_DTO>();
            var ComptesCommentantLePlus = new List<Stat_Compte_DTO>();
            var VillesActives = new List<Stat_Ville_DTO>();
            var postsLesPlusLikes = new List<Stat_Post_DTO>();
            var postsLesPlusSuperlikes = new List<Stat_Post_DTO>();
            var postsLesPlusCommentes = new List<Stat_Post_DTO>();
            var postsLesPlusVus = new List<Stat_Post_DTO>();

            
            foreach (var statPost in statCompte.ComptePostantPLus)
            {
                ComptesPostantLePlus.Add(new Stat_Compte_DTO
                {
                    
                    Id = statPost.Id,
                    IdStats = statPost.IdStats,
                    Pseudo = statPost.Pseudo,
                    NombrePosts = statPost.NombrePosts,
                    NombreCommentaires = statPost.NombreCommentaires
                });
            }

            foreach (var statPost in statCompte.CompteCommentantPLus)
            {
                ComptesCommentantLePlus.Add(new Stat_Compte_DTO
                {
                    
                    Id = statPost.Id,
                    IdStats = statPost.IdStats,
                    Pseudo = statPost.Pseudo,
                    NombrePosts = statPost.NombrePosts,
                    NombreCommentaires = statPost.NombreCommentaires
                });
            }
            
            foreach (var statVille in statCompte.VilleActives)
            {
                VillesActives.Add(new Stat_Ville_DTO
                {
                    Id = statVille.Id,
                    IdStats = statVille.IdStats,
                    Nom = statVille.Nom,
                    NombrePosts = statVille.NombrePosts,
                    NombreCommentaires = statVille.NombreCommentaires,
                    NombreVues = statVille.NombreVues,
                    NombreLikes = statVille.NombreLikes
                });
            }
            
            foreach (var statPost in statCompte.PostesPlusLikes)
            {
                postsLesPlusLikes.Add(new Stat_Post_DTO
                {
                    Id = statPost.Id,
                    IdStats = statPost.IdStats,
                    Titre = statPost.Titre,
                    NombreCommentaires = statPost.NombreCommentaires,
                    NombreVues = statPost.NombreVues,
                    NombreLikes = statPost.NombreLikes,
                    NombreSuperlikes = statPost.NombreSuperlikes,
                    DateCreation = statPost.DateCreation,
                    PseudoAuteur = statPost.PseudoAuteur
                });
            }
            
            foreach (var statPost in statCompte.PostesPlusSuperlikes)
            {
                postsLesPlusSuperlikes.Add(new Stat_Post_DTO
                {
                    Id = statPost.Id,
                    IdStats = statPost.IdStats,
                    Titre = statPost.Titre,
                    NombreCommentaires = statPost.NombreCommentaires,
                    NombreVues = statPost.NombreVues,
                    NombreLikes = statPost.NombreLikes,
                    NombreSuperlikes = statPost.NombreSuperlikes,
                    DateCreation = statPost.DateCreation,
                    PseudoAuteur = statPost.PseudoAuteur
                });
            }
            
            foreach (var statPost in statCompte.PostesPlusCommentes)
            {
                postsLesPlusCommentes.Add(new Stat_Post_DTO
                {
                    Id = statPost.Id,
                    IdStats = statPost.IdStats,
                    Titre = statPost.Titre,
                    NombreCommentaires = statPost.NombreCommentaires,
                    NombreVues = statPost.NombreVues,
                    NombreLikes = statPost.NombreLikes,
                    NombreSuperlikes = statPost.NombreSuperlikes,
                    DateCreation = statPost.DateCreation,
                    PseudoAuteur = statPost.PseudoAuteur
                });
            }
            
            foreach (var statPost in statCompte.PostesPlusVus)
            {
                postsLesPlusVus.Add(new Stat_Post_DTO
                {
                    Id = statPost.Id,
                    IdStats = statPost.IdStats,
                    Titre = statPost.Titre,
                    NombreCommentaires = statPost.NombreCommentaires,
                    NombreVues = statPost.NombreVues,
                    NombreLikes = statPost.NombreLikes,
                    NombreSuperlikes = statPost.NombreSuperlikes,
                    DateCreation = statPost.DateCreation,
                    PseudoAuteur = statPost.PseudoAuteur
                });
            }

            
            return new Stats_DTO
            {
                Id = statCompte.Id,
                DateDebut = statCompte.DateDebut,
                DateFin = statCompte.DateFin,
                NbrCreaCmpt = statCompte.NbrCreaCmpt,
                NbrConnCmpt = statCompte.NbrConnCmpt,
                NbrCreaPost = statCompte.NbrCreaPost,
                NbrCommMpost = statCompte.NbrCommMpost,
                NbrVueMpost = statCompte.NbrVueMpost,
                NbrLikeMpost = statCompte.NbrLikeMpost,
                ComptesPostantLePlus = ComptesPostantLePlus,
                ComptesCommentantLePlus = ComptesCommentantLePlus,
                VillesActives = VillesActives,
                PostsLesPlusLikes = postsLesPlusLikes,
                PostsLesPlusSuperlikes = postsLesPlusSuperlikes,
                PostsLesPlusCommentes = postsLesPlusCommentes,
                PostsLesPlusVus = postsLesPlusVus
            };
        }
        
        public IEnumerable<Stats_DTO> GetAllStats()
        {
            var stats = depot.GetAll();
            var statsDto = new List<Stats_DTO>();
            foreach (var stat in stats)
            {
                var ComptesPostantLePlus = new List<Stat_Compte_DTO>();
                var ComptesCommentantLePlus = new List<Stat_Compte_DTO>();
                var VillesActives = new List<Stat_Ville_DTO>();
                var postsLesPlusLikes = new List<Stat_Post_DTO>();
                var postsLesPlusSuperlikes = new List<Stat_Post_DTO>();
                var postsLesPlusCommentes = new List<Stat_Post_DTO>();
                var postsLesPlusVus = new List<Stat_Post_DTO>();

            
                foreach (var statPost in stat.ComptePostantPLus)
                {
                    ComptesPostantLePlus.Add(new Stat_Compte_DTO
                    {
                    
                        Id = statPost.Id,
                        IdStats = statPost.IdStats,
                        Pseudo = statPost.Pseudo,
                        NombrePosts = statPost.NombrePosts,
                        NombreCommentaires = statPost.NombreCommentaires
                    });
                }

                foreach (var statPost in stat.CompteCommentantPLus)
                {
                    ComptesCommentantLePlus.Add(new Stat_Compte_DTO
                    {
                    
                        Id = statPost.Id,
                        IdStats = statPost.IdStats,
                        Pseudo = statPost.Pseudo,
                        NombrePosts = statPost.NombrePosts,
                        NombreCommentaires = statPost.NombreCommentaires
                    });
                }
                
                foreach (var statVille in stat.VilleActives)
                {
                    VillesActives.Add(new Stat_Ville_DTO
                    {
                        Id = statVille.Id,
                        IdStats = statVille.IdStats,
                        Nom = statVille.Nom,
                        NombrePosts = statVille.NombrePosts,
                        NombreCommentaires = statVille.NombreCommentaires,
                        NombreVues = statVille.NombreVues,
                        NombreLikes = statVille.NombreLikes
                    });
                }
                
                foreach (var statPost in stat.PostesPlusLikes)
                {
                    postsLesPlusLikes.Add(new Stat_Post_DTO
                    {
                        Id = statPost.Id,
                        IdStats = statPost.IdStats,
                        Titre = statPost.Titre,
                        NombreCommentaires = statPost.NombreCommentaires,
                        NombreVues = statPost.NombreVues,
                        NombreLikes = statPost.NombreLikes,
                        NombreSuperlikes = statPost.NombreSuperlikes,
                        DateCreation = statPost.DateCreation,
                        PseudoAuteur = statPost.PseudoAuteur
                    });
                }
                
                foreach (var statPost in stat.PostesPlusSuperlikes)
                {
                    postsLesPlusSuperlikes.Add(new Stat_Post_DTO
                    {
                        Id = statPost.Id,
                        IdStats = statPost.IdStats,
                        Titre = statPost.Titre,
                        NombreCommentaires = statPost.NombreCommentaires,
                        NombreVues = statPost.NombreVues,
                        NombreLikes = statPost.NombreLikes,
                        NombreSuperlikes = statPost.NombreSuperlikes,
                        DateCreation = statPost.DateCreation,
                        PseudoAuteur = statPost.PseudoAuteur
                    });
                }
                
                foreach (var statPost in stat.PostesPlusCommentes)
                {
                    postsLesPlusCommentes.Add(new Stat_Post_DTO
                    {
                        Id = statPost.Id,
                        IdStats = statPost.IdStats,
                        Titre = statPost.Titre,
                        NombreCommentaires = statPost.NombreCommentaires,
                        NombreVues = statPost.NombreVues,
                        NombreLikes = statPost.NombreLikes,
                        NombreSuperlikes = statPost.NombreSuperlikes,
                        DateCreation = statPost.DateCreation,
                        PseudoAuteur = statPost.PseudoAuteur
                    });
                }
                
                foreach (var statPost in stat.PostesPlusVus)
                {
                    postsLesPlusVus.Add(new Stat_Post_DTO
                    {
                        Id = statPost.Id,
                        IdStats = statPost.IdStats,
                        Titre = statPost.Titre,
                        NombreCommentaires = statPost.NombreCommentaires,
                        NombreVues = statPost.NombreVues,
                        NombreLikes = statPost.NombreLikes,
                        NombreSuperlikes = statPost.NombreSuperlikes,
                        DateCreation = statPost.DateCreation,
                        PseudoAuteur = statPost.PseudoAuteur
                    });
                }

            
                statsDto.Add(new Stats_DTO
                {
                    Id = stat.Id,
                    DateDebut = stat.DateDebut,
                    DateFin = stat.DateFin,
                    NbrCreaCmpt = stat.NbrCreaCmpt,
                    NbrConnCmpt = stat.NbrConnCmpt,
                    NbrCreaPost = stat.NbrCreaPost,
                    NbrCommMpost = stat.NbrCommMpost,
                    NbrVueMpost = stat.NbrVueMpost,
                    NbrLikeMpost = stat.NbrLikeMpost,
                    ComptesPostantLePlus = ComptesPostantLePlus,
                    ComptesCommentantLePlus = ComptesCommentantLePlus,
                    VillesActives = VillesActives,
                    PostsLesPlusLikes = postsLesPlusLikes,
                    PostsLesPlusSuperlikes = postsLesPlusSuperlikes,
                    PostsLesPlusCommentes = postsLesPlusCommentes,
                    PostsLesPlusVus = postsLesPlusVus
                });
            }

            return statsDto;
        }
        
        // supprimer une statistique
        public void DeleteStat(int id)
        {
            depot.Delete(id);
        }
        
    }
}