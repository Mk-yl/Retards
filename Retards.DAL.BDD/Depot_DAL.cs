using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace Retards.DAL.BDD;

public abstract class Depot_DAL<Type_DAL> : IDepot_DAL<Type_DAL>
{
    private string chaineConnexion;
        
    protected SqlConnection Connection { get; set; } 
        
    public ConnectionState ConnectionState => Connection.State;
        
    protected SqlCommand Commande { get; set; } 
        
    protected Depot_DAL()
    {
        var builder = new ConfigurationBuilder();
        var config = builder.AddJsonFile("app.json", false , true).Build();
        chaineConnexion =  config.GetConnectionString("default");
            
    }
        
    protected void OuvrirConnexion()
    {
        OuvrirConnexion(new SqlConnection(chaineConnexion), new SqlCommand());
    }
        
    public void OuvrirConnexion(SqlConnection connection, SqlCommand commande)
    {
        Connection = connection;
        Connection.ConnectionString = chaineConnexion;
        Commande = commande;
        Commande.Connection = Connection;
        Connection.Open();
    }
        
        
    public void FermerConnexion()
    {
        Connection.Close();
        Connection.Dispose();
        Commande.Dispose();
            
    }
    

    public abstract Type_DAL Insert(Type_DAL entity);
    public abstract Type_DAL? GetById(int id);
    public abstract IEnumerable<Type_DAL> GetAll();

    public abstract Type_DAL GetBetweenDates(DateTime dateDebut, DateTime dateFin);
    
 
    
}