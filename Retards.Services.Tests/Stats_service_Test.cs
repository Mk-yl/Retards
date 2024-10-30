using Retards.DTO;
using Retards.Services;
using Moq;
using Retards.BLL;
using Retards.DAL.BDD;

namespace Retards.Services.Tests;

public class Stats_service_Test
{
    // on test la méthode GetStatCompteDto avec des mocks
    [Fact]
    public void Stats_service_GetStatCompteDto()
    {
        List<Stat_Compte_BLL> ListStat_Compte_BLL = new List<Stat_Compte_BLL>
        {
            new Stat_Compte_BLL(1,2,"pseudo1", 32,32),
            new Stat_Compte_BLL(2,3,"pseudo2", 32,32),
            new Stat_Compte_BLL(3,4,"pseudo3", 32,32)
        };
        List<Stat_Ville_BLL> ListStat_Ville_BLL = new List<Stat_Ville_BLL>
        {
            new Stat_Ville_BLL(1,1, "Paris", 32, 32,2,3),
            new Stat_Ville_BLL(2,2, "Lyon", 32, 32,2,3),
            new Stat_Ville_BLL(3,3, "Marseille", 32, 32,2,3)
        };
        
        List<Stat_Post_BLL> ListStat_Post_BLL = new List<Stat_Post_BLL>
        {
            new Stat_Post_BLL(1,2,"titre1", 32,32,2,3,new DateTime(2022,08,06),"pseudo1"),
            new Stat_Post_BLL(2,3,"titre2", 32,32,2,3,new DateTime(2022,08,06),"pseudo2"),
            new Stat_Post_BLL(3,4,"titre3", 32,32,2,3,new DateTime(2022,08,06),"pseudo3")
        };


        var mockDepot = new Mock<IStats_Depot<Stats_BLL>>();
        mockDepot.Setup(m => m.GetStatBetweenDates(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
            .Returns(new Stats_BLL(new DateTime(2022, 1, 1), new DateTime(2022, 4, 4), 10, 23, 12, 5, 6, 7,
                ListStat_Compte_BLL,
                ListStat_Compte_BLL,
                ListStat_Ville_BLL,
                ListStat_Post_BLL,
                ListStat_Post_BLL,
                ListStat_Post_BLL,
                ListStat_Post_BLL
            ));

// Arrange
        Stats_service service = new Stats_service(mockDepot.Object);

// Act
        Stats_DTO stats = service.GetStatCompteDto(new DateTime(2022, 1, 1), new DateTime(2022, 4, 4));

// Assert
        Assert.NotNull(stats);
        Assert.Equal(new DateTime(2022, 1, 1), stats.DateDebut);
        Assert.Equal(new DateTime(2022, 4, 4), stats.DateFin);
        Assert.Equal(10, stats.NbrCreaCmpt);
        Assert.Equal(23, stats.NbrConnCmpt);
        Assert.Equal(12, stats.NbrCreaPost);
        Assert.Equal(5, stats.NbrCommMpost);
        Assert.Equal(6, stats.NbrVueMpost);
        Assert.Equal(7, stats.NbrLikeMpost);
        // verifie le nombre d'element dans les liste
        Assert.NotEmpty(stats.ComptesPostantLePlus);
        Assert.Equal(3, stats.ComptesCommentantLePlus.Count);
        Assert.Equal(3, stats.VillesActives.Count);
        Assert.NotEmpty(stats.PostsLesPlusLikes);
        Assert.NotEmpty(stats.PostsLesPlusSuperlikes);
        Assert.NotEmpty(stats.PostsLesPlusCommentes);
        Assert.NotEmpty(stats.PostsLesPlusVus);
        mockDepot.Verify(d => d.GetStatBetweenDates(It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Once);
    }

    // test la methode GetAllStats avec des mocks

    [Fact]
    public void Stats_service_GetAllStats()
    {
        
        List<Stat_Compte_BLL> ListStat_Compte_BLL = new List<Stat_Compte_BLL>
        {
            new Stat_Compte_BLL(1,2,"pseudo1", 32,32),
            new Stat_Compte_BLL(2,3,"pseudo2", 32,32),
            new Stat_Compte_BLL(3,4,"pseudo3", 32,32)
        };
        List<Stat_Ville_BLL> ListStat_Ville_BLL = new List<Stat_Ville_BLL>
        {
            new Stat_Ville_BLL(1,1, "Paris", 32, 32,2,3),
            new Stat_Ville_BLL(2,2, "Lyon", 32, 32,2,3),
            new Stat_Ville_BLL(3,3, "Marseille", 32, 32,2,3)
        };
        
        List<Stat_Post_BLL> ListStat_Post_BLL = new List<Stat_Post_BLL>
        {
            new Stat_Post_BLL(1,2,"titre1", 32,32,2,3,new DateTime(2022,08,06),"pseudo1"),
            new Stat_Post_BLL(2,3,"titre2", 32,32,2,3,new DateTime(2022,08,06),"pseudo2"),
            new Stat_Post_BLL(3,4,"titre3", 32,32,2,3,new DateTime(2022,08,06),"pseudo3")
        };

        var mockDepot = new Mock<IStats_Depot<Stats_BLL>>();
        mockDepot.Setup(m => m.GetAll())
            .Returns(new List<Stats_BLL>
            {
                new Stats_BLL(new DateTime(2022, 1, 1), new DateTime(2022, 4, 4), 10, 23, 12, 5, 6, 7,
                     ListStat_Compte_BLL,
                     ListStat_Compte_BLL,
                     ListStat_Ville_BLL,
                    ListStat_Post_BLL,
                    ListStat_Post_BLL,
                    ListStat_Post_BLL,
                    ListStat_Post_BLL
                )
            });

        // Arrange
        Stats_service service = new Stats_service(mockDepot.Object);

        // Act
        IEnumerable<Stats_DTO> stats = service.GetAllStats();

        // Assert
        Assert.NotNull(stats);
        Assert.NotEmpty(stats);
        Assert.Single(stats);
        Assert.Equal(new DateTime(2022, 1, 1), stats.First().DateDebut);
        Assert.Equal(new DateTime(2022, 4, 4), stats.First().DateFin);
        Assert.Equal(10, stats.First().NbrCreaCmpt);
        Assert.Equal(23, stats.First().NbrConnCmpt);
        Assert.Equal(12, stats.First().NbrCreaPost);
            Assert.Equal(5, stats.First().NbrCommMpost);
        Assert.Equal(6, stats.First().NbrVueMpost);
        // verifie le nombre d'element dans les liste
        Assert.Equal(3, stats.First().ComptesCommentantLePlus.Count);
        mockDepot.Verify(d => d.GetAll(), Times.Once);
    }
}
            