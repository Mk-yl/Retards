namespace Retards.BLL;

public interface IStats_Depot <T>
{
    T GetStatBetweenDates(DateTime dateDebut, DateTime dateFin);
    IEnumerable<T> GetAll();
    void Delete(int id);
    
}
