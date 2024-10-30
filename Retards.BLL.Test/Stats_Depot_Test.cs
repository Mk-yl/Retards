using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using Retards.BLL;
using Retards.DAL.API;
using Retards.DAL.BDD;
using Retards.DTO;

namespace Retards.BLL.Test
{
    public class Stats_Depot_Test
    {
        // Tester la méthode GetStatBetweenDates de la classe Stats_Depot avec des mocks
        [Fact]
        public void Stats_Depot_GetStatBetweenDates()
        {
            var dateDebut = new DateTime(2021, 05, 06);
            var dateFin = new DateTime(2021, 08, 06);

            var mock = new Mock<Stats_DAL_Depot>();
            mock.Setup(m => m.GetBetweenDates(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns(new Stats_DAL(1, dateDebut, dateFin, 1, 2, 3, 4, 5, 6));
            Stats_Depot depot = new Stats_Depot(mock.Object);

// Act

            Stats_BLL stats = depot.GetStatBetweenDates(dateDebut, dateFin);


// Assert
            Assert.NotNull(stats);
            Assert.Equal(1, stats.Id);
            Assert.Equal(dateDebut, stats.DateDebut);
            Assert.Equal(dateFin, stats.DateFin);
            Assert.Equal(1, stats.NbrCreaCmpt);
            Assert.Equal(2, stats.NbrConnCmpt);
            Assert.Equal(3, stats.NbrCreaPost);
            Assert.Equal(4, stats.NbrCommMpost);
            Assert.Equal(5, stats.NbrVueMpost);
            Assert.Equal(6, stats.NbrLikeMpost);
            mock.Verify(m => m.GetBetweenDates(dateDebut, dateFin), Times.Once);
        }


        // Tester la méthode GetAll de la classe Stats_Depot avec des mocks
        [Fact]
        public void Stats_Depot_GetAll()
        {
            var mock = new Mock<Stats_DAL_Depot>();
            mock.Setup(m => m.GetAll())
                .Returns(new List<Stats_DAL>
                {
                    new Stats_DAL(1, new DateTime(2021, 05, 06), new DateTime(2021, 08, 06), 1, 2, 3, 4, 5, 6),
                    new Stats_DAL(2, new DateTime(2021, 05, 06), new DateTime(2021, 08, 06), 1, 2, 3, 4, 5, 6)
                });
            Stats_Depot depot = new Stats_Depot(mock.Object);

            // Act
            IEnumerable<Stats_BLL> stats = depot.GetAll();

            // Assert
            Assert.NotNull(stats);
            Assert.Collection(stats,
                item =>
                {
                    Assert.Equal(1, item.Id);
                    Assert.Equal(new DateTime(2021, 05, 06), item.DateDebut);
                    Assert.Equal(new DateTime(2021, 08, 06), item.DateFin);
                    Assert.Equal(1, item.NbrCreaCmpt);
                    Assert.Equal(2, item.NbrConnCmpt);
                    Assert.Equal(3, item.NbrCreaPost);
                    Assert.Equal(4, item.NbrCommMpost);
                    Assert.Equal(5, item.NbrVueMpost);
                    Assert.Equal(6, item.NbrLikeMpost);
                },
                item =>
                {
                    Assert.Equal(2, item.Id);
                    Assert.Equal(new DateTime(2021, 05, 06), item.DateDebut);
                    Assert.Equal(new DateTime(2021, 08, 06), item.DateFin);
                    Assert.Equal(1, item.NbrCreaCmpt);
                    Assert.Equal(2, item.NbrConnCmpt);
                    Assert.Equal(3, item.NbrCreaPost);
                    Assert.Equal(4, item.NbrCommMpost);
                    Assert.Equal(5, item.NbrVueMpost);
                    Assert.Equal(6, item.NbrLikeMpost);
                });
            mock.Verify(m => m.GetAll(), Times.Once);
        }
    }
}