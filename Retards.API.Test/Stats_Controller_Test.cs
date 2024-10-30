using Microsoft.Extensions.Logging;
using Retards.Services;
using Retards.DTO;
using moq = Moq;

namespace Retards.API.Test;

public class Stats_Controller_Test
{
    [Fact]
    public void Stat_controller_GetStats()
    {
        // Arrange
        var expectedDateDebut = new DateTime(2024, 4, 22); // Remplacez par la date de début attendue
        var expectedDateFin = new DateTime(2024, 4, 29); // Remplacez par la date de fin attendue

        // Arrange
        var mockService = new moq.Mock<IStats_service<Stats_DTO>>();
        mockService.Setup(s => s.GetStatCompteDto(moq.It.IsAny<DateTime>(), moq.It.IsAny<DateTime>()))
            .Returns(new Stats_DTO
            {
                Id = 1,
                DateDebut = expectedDateDebut, // Date de début quelconque
                DateFin = expectedDateFin, // Date de fin quelconque
                NbrCreaCmpt = 100, // Nombre de créations de comptes
                NbrConnCmpt = 80, // Nombre de connexions de comptes
                NbrCreaPost = 50, // Nombre de créations de posts
                NbrCommMpost = 20, // Nombre de commentaires moyen postés
                NbrVueMpost = 30, // Nombre de vues moyen postés
                NbrLikeMpost = 40, // Nombre de likes moyen postés
                ComptesPostantLePlus = new List<Stat_Compte_DTO>
                {
                    // Ajouter des données pour les comptes postant le plus
                    new Stat_Compte_DTO { Id = 1, Pseudo = "User1", NombrePosts = 5, NombreCommentaires = 10 },
                    new Stat_Compte_DTO { Id = 2, Pseudo = "user2", NombrePosts = 8, NombreCommentaires = 15 }
                    // Ajoutez plus si nécessaire
                },
                ComptesCommentantLePlus = new List<Stat_Compte_DTO>
                {
                    // Ajouter des données pour les comptes commentant le plus
                    new Stat_Compte_DTO { Pseudo = "user3", NombrePosts = 5, NombreCommentaires = 30 },
                    new Stat_Compte_DTO { Pseudo = "user4", NombrePosts = 3, NombreCommentaires = 25 }
                    // Ajoutez plus si nécessaire
                },
                VillesActives = new List<Stat_Ville_DTO>
                {
                    // Ajouter des données pour les villes actives
                    new Stat_Ville_DTO
                    {
                        Id = 2, Nom = "Paris", NombrePosts = 10, NombreCommentaires = 20, NombreLikes = 29,
                        NombreVues = 10
                    },
                    new Stat_Ville_DTO
                    {
                        Id = 1, Nom = "Lyon", NombrePosts = 8, NombreCommentaires = 15, NombreLikes = 20, NombreVues = 5
                    }
                    // Ajoutez plus si nécessaire
                },
                PostsLesPlusLikes = new List<Stat_Post_DTO>
                {
                    // Ajouter des données pour les posts les plus likés
                    new Stat_Post_DTO
                    {
                        Id = 1, NombreLikes = 10, NombreCommentaires = 20, NombreVues = 30, NombreSuperlikes = 5,
                        DateCreation = DateTime.Now.AddDays(-1), PseudoAuteur = "User1", Titre = "Post1"
                    },
                    new Stat_Post_DTO
                    {
                        Id = 2, NombreLikes = 8, NombreCommentaires = 15, NombreVues = 25, NombreSuperlikes = 3,
                        DateCreation = DateTime.Now.AddDays(-2), PseudoAuteur = "User2", Titre = "Post2"
                    }
                    // Ajoutez plus si nécessaire
                },
                PostsLesPlusSuperlikes = new List<Stat_Post_DTO>
                {
                    // Ajouter des données pour les posts les plus superlikés
                    new Stat_Post_DTO
                    {
                        Id = 1, NombreLikes = 10, NombreCommentaires = 20, NombreVues = 30, NombreSuperlikes = 5,
                        DateCreation = DateTime.Now.AddDays(-1), PseudoAuteur = "User1", Titre = "Post1"
                    },
                    new Stat_Post_DTO
                    {
                        Id = 2, NombreLikes = 8, NombreCommentaires = 15, NombreVues = 25, NombreSuperlikes = 3,
                        DateCreation = DateTime.Now.AddDays(-2), PseudoAuteur = "User2", Titre = "Post2"
                    }
                    // Ajoutez plus si nécessaire
                },
                PostsLesPlusCommentes = new List<Stat_Post_DTO>
                {
                    // Ajouter des données pour les posts les plus commentés
                    new Stat_Post_DTO
                    {
                        Id = 1, NombreLikes = 10, NombreCommentaires = 20, NombreVues = 30, NombreSuperlikes = 5,
                        DateCreation = DateTime.Now.AddDays(-1), PseudoAuteur = "User1", Titre = "Post1"
                    },
                    new Stat_Post_DTO
                    {
                        Id = 2, NombreLikes = 8, NombreCommentaires = 15, NombreVues = 25, NombreSuperlikes = 3,
                        DateCreation = DateTime.Now.AddDays(-2), PseudoAuteur = "User2", Titre = "Post2"
                    }
                    // Ajoutez plus si nécessaire
                },
                PostsLesPlusVus = new List<Stat_Post_DTO>
                {
                    // Ajouter des données pour les posts les plus vus
                    new Stat_Post_DTO
                    {
                        Id = 1, NombreLikes = 10, NombreCommentaires = 20, NombreVues = 30, NombreSuperlikes = 5,
                        DateCreation = DateTime.Now.AddDays(-1), PseudoAuteur = "User1", Titre = "Post1"
                    },
                    new Stat_Post_DTO
                    {
                        Id = 2, NombreLikes = 8, NombreCommentaires = 15, NombreVues = 25, NombreSuperlikes = 3,
                        DateCreation = DateTime.Now.AddDays(-2), PseudoAuteur = "User2", Titre = "Post2"
                    }
                    // Ajoutez plus si nécessaire
                }
            });

        var controller = new Stats_Controller(new moq.Mock<ILogger<Stats_Controller>>().Object, mockService.Object);

        // Act
        var s = controller.GetStats(DateTime.Now.AddDays(-7), DateTime.Now);

        // Assert
        Assert.NotNull(s);
        Assert.Equal(1, s.Id);
        Assert.Equal(expectedDateDebut, s.DateDebut);
        Assert.Equal(expectedDateFin, s.DateFin);
        Assert.Equal(100, s.NbrCreaCmpt);
        Assert.Equal(80, s.NbrConnCmpt);
        Assert.Equal(50, s.NbrCreaPost);
        Assert.Equal(20, s.NbrCommMpost);
        Assert.Equal(30, s.NbrVueMpost);
        Assert.Equal(40, s.NbrLikeMpost);
        Assert.Equal(2, s.ComptesPostantLePlus.Count);
        Assert.Equal(2, s.ComptesCommentantLePlus.Count);
        Assert.Equal(2, s.VillesActives.Count);
        Assert.Equal(2, s.PostsLesPlusLikes.Count);
        Assert.Equal(2, s.PostsLesPlusSuperlikes.Count);
        Assert.Equal(2, s.PostsLesPlusCommentes.Count);
        Assert.Equal(2, s.PostsLesPlusVus.Count);
        mockService.Verify(s => s.GetStatCompteDto(moq.It.IsAny<DateTime>(), moq.It.IsAny<DateTime>()), moq.Times.Once);
    }

    // test le GetAll qui n'a pas de parametre 
    [Fact]
    public void Stat_controller_GetAll()
    {
        // Arrange
        var mockService = new moq.Mock<IStats_service<Stats_DTO>>();
        mockService.Setup(s => s.GetAllStats())
            .Returns(new List<Stats_DTO>
            {
                new Stats_DTO
                {
                    Id = 1,
                    DateDebut = new DateTime(2024, 4, 22), // Date de début quelconque
                    DateFin = new DateTime(2024, 4, 29), // Date de fin quelconque
                    NbrCreaCmpt = 100, // Nombre de créations de comptes
                    NbrConnCmpt = 80, // Nombre de connexions de comptes
                    NbrCreaPost = 50, // Nombre de créations de posts
                    NbrCommMpost = 20, // Nombre de commentaires moyen postés
                    NbrVueMpost = 30, // Nombre de vues moyen postés
                    NbrLikeMpost = 40, // Nombre de likes moyen postés
                    ComptesPostantLePlus = new List<Stat_Compte_DTO>
                    {
                        // Ajouter des données pour les comptes postant le plus
                        new Stat_Compte_DTO { Id = 1, Pseudo = "User1", NombrePosts = 5, NombreCommentaires = 10 },
                        new Stat_Compte_DTO { Id = 2, Pseudo = "user2", NombrePosts = 8, NombreCommentaires = 15 }
                        // Ajoutez plus si nécessaire
                    },
                    ComptesCommentantLePlus = new List<Stat_Compte_DTO>
                    {
                        // Ajouter des données pour les comptes commentant le plus
                        new Stat_Compte_DTO { Pseudo = "user3", NombrePosts = 5, NombreCommentaires = 30 },
                        new Stat_Compte_DTO { Pseudo = "user4", NombrePosts = 3, NombreCommentaires = 25 }
                        // Ajoutez plus si nécessaire
                    },
                    VillesActives = new List<Stat_Ville_DTO>
                    {
                        // Ajouter des données pour les villes actives
                        new Stat_Ville_DTO
                        {
                            Id = 2, Nom = "Paris", NombrePosts = 32, NombreCommentaires = 20, NombreLikes = 29,
                            NombreVues = 10
                        },
                        new Stat_Ville_DTO
                        {
                            Id = 1, Nom = "Lyon", NombrePosts = 8, NombreCommentaires = 15, NombreLikes = 20,
                            NombreVues = 5
                        }

                    },
                    PostsLesPlusLikes = new List<Stat_Post_DTO>
                    {
                        new Stat_Post_DTO()
                        {
                            Id = 1, NombreLikes = 10, NombreCommentaires = 20, NombreVues = 30, NombreSuperlikes = 5,
                            DateCreation = DateTime.Now.AddDays(-1), PseudoAuteur = "psdeiu1"
                        },
                        new Stat_Post_DTO()
                        {
                            Id = 2, NombreLikes = 8, NombreCommentaires = 15, NombreVues = 25, NombreSuperlikes = 3,
                            DateCreation = DateTime.Now.AddDays(-2), PseudoAuteur = "psdeiu2"
                        }
                    },
                    PostsLesPlusSuperlikes = new List<Stat_Post_DTO>
                    {
                        new Stat_Post_DTO()
                        {
                            Id = 1, NombreLikes = 10, NombreCommentaires = 20, NombreVues = 30, NombreSuperlikes = 5,
                            DateCreation = DateTime.Now.AddDays(-1), PseudoAuteur = "psdeiu1"
                        },
                        new Stat_Post_DTO()
                        {
                            Id = 2, NombreLikes = 8, NombreCommentaires = 15, NombreVues = 25, NombreSuperlikes = 3,
                            DateCreation = DateTime.Now.AddDays(-2), PseudoAuteur = "psdeiu2"
                        }
                    },
                    PostsLesPlusCommentes = new List<Stat_Post_DTO>
                    {
                        new Stat_Post_DTO()
                        {
                            Id = 1, NombreLikes = 10, NombreCommentaires = 20, NombreVues = 30, NombreSuperlikes = 5,
                            DateCreation = DateTime.Now.AddDays(-1), PseudoAuteur = "psdeiu1"
                        },
                        new Stat_Post_DTO()
                        {
                            Id = 2, NombreLikes = 8, NombreCommentaires = 15, NombreVues = 25, NombreSuperlikes = 3,
                            DateCreation = DateTime.Now.AddDays(-2), PseudoAuteur = "psdeiu2"
                        }
                    },
                    PostsLesPlusVus = new List<Stat_Post_DTO>
                    {
                        new Stat_Post_DTO()
                        {
                            Id = 1, NombreLikes = 10, NombreCommentaires = 20, NombreVues = 30, NombreSuperlikes = 5,
                            DateCreation = DateTime.Now.AddDays(-1), PseudoAuteur = "psdeiu1"
                        },
                        new Stat_Post_DTO()
                        {
                            Id = 2, NombreLikes = 8, NombreCommentaires = 15, NombreVues = 25, NombreSuperlikes = 3,
                            DateCreation = DateTime.Now.AddDays(-2), PseudoAuteur = "psdeiu2"
                        }
                    }
                },

            });
        var controller = new Stats_Controller(new moq.Mock<ILogger<Stats_Controller>>().Object, mockService.Object);

        // Act
        var s = controller.GetAll();

        // Assert
        Assert.NotNull(s);
        Assert.Collection(s,
            item =>
            {
                Assert.Equal(1, item.Id);
                Assert.Equal(new DateTime(2024, 4, 22), item.DateDebut);
                Assert.Equal(new DateTime(2024, 4, 29), item.DateFin);
                Assert.Equal(100, item.NbrCreaCmpt);
                Assert.Equal(80, item.NbrConnCmpt);
                Assert.Equal(50, item.NbrCreaPost);
                Assert.Equal(20, item.NbrCommMpost);
                Assert.Equal(30, item.NbrVueMpost);
                Assert.Equal(40, item.NbrLikeMpost);
                Assert.Equal(2, item.ComptesPostantLePlus.Count);
                Assert.Equal(2, item.ComptesCommentantLePlus.Count);
                Assert.Equal(2, item.VillesActives.Count);
                Assert.Equal(2, item.PostsLesPlusLikes.Count);
                Assert.Equal(2, item.PostsLesPlusSuperlikes.Count);
                Assert.Equal(2, item.PostsLesPlusCommentes.Count);
                Assert.Equal(2, item.PostsLesPlusVus.Count);
            });
        mockService.Verify(s => s.GetAllStats(), moq.Times.Once);

    }


}
   
        