using Retards.DTO;

namespace Retards.Services;

public interface IStats_service <T>
{
    T GetStatCompteDto(DateTime dateDebut, DateTime dateFin);
    IEnumerable<T> GetAllStats();
    
    void DeleteStat(int id);
    
}