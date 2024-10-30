namespace Retards.DAL.BDD.Tests;

public class stats_DAL_tests
{
        [Fact]
        public void Depot_DAL_Insert()
        {
            // Arrange
            Depot_DAL<Stats_DAL> depot = new Stats_DAL_Depot();
            Stats_DAL entity = new Stats_DAL(new DateTime(2022, 1, 1), new DateTime(2022, 4, 4), 10, 23, 12, 5, 6, 7);
            
            // Act
            var result = depot.Insert(entity);
            
            // Assert
            Assert.NotNull(result);
            
        }
        
        [Fact]
        public void getById()
        {
            // Arrange
            Depot_DAL<Stats_DAL> depot = new Stats_DAL_Depot();
            Stats_DAL entity = new Stats_DAL(new DateTime(2022, 5, 1), new DateTime(2022, 8, 2), 13, 23, 12, 5, 6, 7);
            var result = depot.Insert(entity);
            
            // Act
            var result2 = depot.GetById(result.Id);
            
            // Assert
            Assert.NotNull(result2);
            Assert.Equal(result.Id, result2.Id);
            Assert.Equal(result.DateDebut, result2.DateDebut);
            Assert.Equal(result.DateFin, result2.DateFin);
            
            
        }
        
        [Fact]
        public void GetAll()
        {
            // Arrange
            Depot_DAL<Stats_DAL> depot = new Stats_DAL_Depot();
            Stats_DAL entity = new Stats_DAL(new DateTime(2022, 10, 1), new DateTime(2022, 11, 21), 13, 23, 12, 5, 6, 7);
            var result = depot.Insert(entity);
            
            // Act
            var result2 = depot.GetAll();
            
            // Assert
            Assert.NotNull(result2);
            Assert.NotEmpty(result2);
            Assert.Contains(result2, item => item.DateDebut == entity.DateDebut && item.DateFin == entity.DateFin && item.NbrCreaCmpt == entity.NbrCreaCmpt);
            
        }
        
        [Fact]
        public void GetBetweenDates()
        {
            // Arrange
            Depot_DAL<Stats_DAL> depot = new Stats_DAL_Depot();
            Stats_DAL entity = new Stats_DAL(new DateTime(2023, 10, 8), new DateTime(2023, 12, 30), 13, 23, 12, 5, 6, 7);
            var result = depot.Insert(entity);
    
            // Act
            var result2 = depot.GetBetweenDates(new DateTime(2023, 10, 8), new DateTime(2023, 12, 30));
    
            // Assert
            Assert.NotNull(result2);
            Assert.Equal(entity.Id, result2.Id);
            Assert.Equal(entity.DateDebut, result2.DateDebut);
            Assert.Equal(entity.DateFin, result2.DateFin);
            Assert.Equal(entity.NbrCreaCmpt, result2.NbrCreaCmpt);
            Assert.Equal(entity.NbrConnCmpt, result2.NbrConnCmpt);
            Assert.Equal(entity.NbrCreaPost, result2.NbrCreaPost);
            Assert.Equal(entity.NbrCommMpost, result2.NbrCommMpost);
            Assert.Equal(entity.NbrVueMpost, result2.NbrVueMpost);
            Assert.Equal(entity.NbrLikeMpost, result2.NbrLikeMpost);
            
            
        }

        
        
        
        
}