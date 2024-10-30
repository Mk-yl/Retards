namespace Retards.DAL.BDD.Tests;

public class Depot_DAL_test
{
    [Fact]
    public void Depot_DAL_OuvrirConnexion()
    {
        // arrange
        Depot_DAL <Stats_DAL> depot = new Stats_DAL_Depot();
        var conn = new System.Data.SqlClient.SqlConnection();
        var commande = new System.Data.SqlClient.SqlCommand();
        
        // act
        depot.OuvrirConnexion(conn, commande);
        
        // assert
        Assert.Equal(conn, commande.Connection);
        Assert.Equal(System.Data.ConnectionState.Open, depot.ConnectionState);
        Assert.Equal(System.Data.ConnectionState.Open, conn.State);
        
        
    }
        
    [Fact]
    public void Depot_DAL_FermerConnexion()
    {
        // arrange
        Depot_DAL <Stats_DAL> depot = new Stats_DAL_Depot();
        var conn = new System.Data.SqlClient.SqlConnection();
        var commande = new System.Data.SqlClient.SqlCommand();
        depot.OuvrirConnexion(conn, commande);
        
        // act
        depot.FermerConnexion();
        
        // assert
        Assert.Equal(System.Data.ConnectionState.Closed, depot.ConnectionState);
        Assert.Equal(System.Data.ConnectionState.Closed, conn.State);
        
        
        
       
    }
}